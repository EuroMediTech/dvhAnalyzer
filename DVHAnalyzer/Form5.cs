using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DVHAnalyzer
{
  public partial class Form5 : Form
  {
    public string _selectedPlanSum;

    public Form5()
    {
      InitializeComponent();
    }

    static public string ShowMiniForm(List<String> strList)
    {
      Form5 f = new Form5();

      f.comboBox1.Items.AddRange(strList.ToArray());
      f.comboBox1.SelectedIndex = 0;

      f.ShowDialog();

      string selectedPlanSum = f._selectedPlanSum;

      f.Dispose();

      return selectedPlanSum;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string selectedPlanSum = Convert.ToString(comboBox1.SelectedItem);
      this._selectedPlanSum = selectedPlanSum;
      this.Close();
    }
  }
}
