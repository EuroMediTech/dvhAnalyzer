using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using DVHAnalyzer;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS
{
  public class Script
  {
    public Script() { }

    public void Execute(ScriptContext context /*, System.Windows.Window window*/ )
    {
      PlanSetup planSetup = context.PlanSetup;
      PlanSum psum = context.PlanSumsInScope.FirstOrDefault();
      StructureSet structureSet;
      bool isPlanSum = false;
      string psumName = null;

      // If there's no selected plan with calculated dose throw an exception
      if (planSetup == null && psum == null)
      {
        throw new ApplicationException("Please open a calculated plan/planSum before using this script.");
      }
      else if (planSetup != null)
      {
        if (planSetup.Dose == null)
          throw new ApplicationException("Please open a calculated plan before using this script.");

        structureSet = planSetup.StructureSet;
      }
      else
      {
        if (psum.Dose == null)
          throw new ApplicationException("Please open a calculated plansum before using this script.");

        isPlanSum = true;

        if (context.PlanSumsInScope.Count() > 1)
        {
          List<String> psumList = new List<String>();
          foreach (var sum in context.PlanSumsInScope)
          {
            psumList.Add(String.Format("{0}/{1}", sum.Course.Id, sum.Id));
          }
          psumName = Form5.ShowMiniForm(psumList);
          structureSet = context.Patient.Courses.First(c => c.Id == psumName.Split('/')[0]).PlanSums.First(ps => ps.Id == psumName.Split('/')[1]).StructureSet;
        }
        else
        {
          structureSet = psum.StructureSet;
          psumName = psum.Course.Id + '/' + psum.Id;
        }
      }

      // Retrieve StructureSet
      if (structureSet == null)
        throw new ApplicationException("The selected plan does not reference a StructureSet.");

      Form1 window;

      if (!isPlanSum)
      {
        window = new Form1(context);
      }
      else
      {
        window = new Form1(context, true, psumName);
      }
      window.ShowDialog();
    }
  }
}