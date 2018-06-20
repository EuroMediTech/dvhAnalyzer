using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using DVHAnalyzer;

namespace VMS.TPS
{
  public class Script
  {
    public Script()
    {
    }

    public void Execute(ScriptContext context /*, System.Windows.Window window*/)
    {
      PlanSetup planSetup = context.PlanSetup;

      // If there's no selected plan with calculated dose throw an exception
      if (planSetup == null || planSetup.Dose == null)
        throw new ApplicationException("Please open a calculated plan before using this script.");

      // Retrieve StructureSet
      StructureSet structureSet = planSetup.StructureSet;
      if (structureSet == null)
        throw new ApplicationException("The selected plan does not reference a StructureSet.");

      Form1 window = new Form1(context);
      window.ShowDialog();
    }
  }
}
