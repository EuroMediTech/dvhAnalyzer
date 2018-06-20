using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace DVHAnalyzer
{
  public partial class Form2 : Form
  {

    public List<List<String>> _returnList;

    public Form2()
    {
      InitializeComponent();


    }

    static public List<List<String>> ShowMiniForm(List<String> strList, StructureSet ss)
    {
      Form2 f = new Form2();


      foreach (Structure structure in ss.Structures)
      {
        if (!structure.IsEmpty)
          f.Column_plan.Items.Add(structure.Id);
      }

      IEnumerable<String> stnames = strList.Distinct();

      int i = 0;
      foreach (String st in stnames)
      {
        f.dataGridView1.Rows.Add();
        f.dataGridView1[0, i].Value = st;
        i++;
      }

      int j = 0;
      for (j = 0; j<i; j++)
      {
        foreach(Structure s in ss.Structures)
        {
          if (s.Id == Convert.ToString(f.dataGridView1[0, j].Value) && !s.IsEmpty)
          {
            f.dataGridView1[1, j].Value = s.Id;
          }
        }
      }

      List<List<String>> returnList = new List<List<String>>();

      f.ShowDialog();
      returnList = f._returnList;
      f.Dispose();

      return returnList;
    }

    private void button_ok_Click(object sender, EventArgs e)
    {
      List<List<String>> returnList = new List<List<String>>();
      for (int j = 0; j < dataGridView1.Rows.Count; j++)
      {
        returnList.Add(new List<String> { Convert.ToString(dataGridView1[0, j].Value), Convert.ToString(dataGridView1[1, j].Value)});
      }
      this._returnList = returnList;
      this.Close();
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (dataGridView1.Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewComboBoxColumn)))
      {
        dataGridView1.BeginEdit(true);
        DataGridViewComboBoxEditingControl edt = dataGridView1.EditingControl as DataGridViewComboBoxEditingControl;
        edt.DroppedDown = true;
      }
    }
  }
}
