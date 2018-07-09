using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace DVHAnalyzer
{
  public partial class Form1 : Form
  {
    ScriptContext context { get; set; }
    PlanSetup planSetup { get; set; }
    StructureSet ss { get; set; }

    string setting = String.Format(@"{0}\EMT\settings.ini", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

    public Form1(ScriptContext _context)
    {
      InitializeComponent();
      context = _context;
      planSetup = context.PlanSetup;
      ss = planSetup.StructureSet;

      label5.Text = context.Patient.Id;
      label6.Text = String.Format("{0} {1}", context.Patient.LastName, context.Patient.FirstName);
      label7.Text = planSetup.Id;

      foreach (Structure structure in ss.Structures)
      {
        if (!structure.IsEmpty && structure.DicomType != "SUPPORT")
          Column_structure.Items.Add(structure.Id);
      }

    }

    private void button_add_Click(object sender, EventArgs e)
    {
      if (dataGridView1.RowCount == 0)
      {
        dataGridView1.Rows.Add();
      }
      else
      {
        int idx = dataGridView1.CurrentRow.Index;
        dataGridView1.Rows.Insert(idx + 1);
        dataGridView1[Column_structure.Index, idx + 1].Value = dataGridView1[Column_structure.Index, idx].Value;
      }
    }

    private void button_delete_Click(object sender, EventArgs e)
    {
      if (dataGridView1.RowCount > 0)
      {
        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
      }
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) return;

      if (dataGridView1.Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewComboBoxColumn)))
      {
        if (e.ColumnIndex == Column_dvunit.Index)
        {
          string dv = Convert.ToString(dataGridView1[Column_dv.Index, dataGridView1.CurrentRow.Index].Value);
          if (dv != "Dmax" && dv != "Dmean" && dv != "Dmin")
          {
            dataGridView1.BeginEdit(true);
            DataGridViewComboBoxEditingControl edt = dataGridView1.EditingControl as DataGridViewComboBoxEditingControl;
            edt.DroppedDown = true;
          }
        }
        else
        {
          dataGridView1.BeginEdit(true);
          DataGridViewComboBoxEditingControl edt = dataGridView1.EditingControl as DataGridViewComboBoxEditingControl;
          edt.DroppedDown = true;
        }
      }
    }

    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (dataGridView1.RowCount > 0)
      {
        if (e.ColumnIndex == Column_unit.Index)
        {
          dataGridView1[Column_textunit.Index, dataGridView1.CurrentRow.Index].Value = dataGridView1[Column_unit.Index, dataGridView1.CurrentRow.Index].Value;
        }

        if (e.ColumnIndex == Column_dv.Index)
        {
          string dv = Convert.ToString(dataGridView1[Column_dv.Index, dataGridView1.CurrentRow.Index].Value);
          if (dv == "Dmax" || dv == "Dmean" || dv == "Dmin")
          {
            dataGridView1[Column_dvvalue.Index, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[Column_dvvalue.Index, dataGridView1.CurrentRow.Index].ReadOnly = true;
            dataGridView1[Column_dvvalue.Index, dataGridView1.CurrentRow.Index].Style.BackColor = Color.LightGray;
            dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].ReadOnly = true;
            dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].Style.BackColor = Color.LightGray;
            if (Convert.ToString(dataGridView1[Column_unit.Index, dataGridView1.CurrentRow.Index].Value) == "cc")
            {
              dataGridView1[Column_unit.Index, dataGridView1.CurrentRow.Index].Value = "";
            }

            DataGridViewComboBoxCell unit_cell = dataGridView1[Column_unit.Index, dataGridView1.CurrentRow.Index] as DataGridViewComboBoxCell;
            unit_cell.Items.Clear();
            unit_cell.Items.Add("Gy");
            unit_cell.Items.Add("%");
          }
          else if (dv == "D" || dv == "DC")
          {
            dataGridView1[Column_dvvalue.Index, dataGridView1.CurrentRow.Index].ReadOnly = false;
            dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].ReadOnly = false;
            dataGridView1[Column_dvvalue.Index, dataGridView1.CurrentRow.Index].Style.BackColor = Color.White;
            dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].Style.BackColor = Color.White;
            if (Convert.ToString(dataGridView1[Column_unit.Index, dataGridView1.CurrentRow.Index].Value) == "cc")
            {
              dataGridView1[Column_unit.Index, dataGridView1.CurrentRow.Index].Value = "";
            }
            if (Convert.ToString(dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].Value) == "Gy")
            {
              dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].Value = "";
            }

            DataGridViewComboBoxCell unit_cell = dataGridView1[Column_unit.Index, dataGridView1.CurrentRow.Index] as DataGridViewComboBoxCell;
            unit_cell.Items.Clear();
            unit_cell.Items.Add("Gy");
            unit_cell.Items.Add("%");
            DataGridViewComboBoxCell dvunit_cell = dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index] as DataGridViewComboBoxCell;
            dvunit_cell.Items.Clear();
            dvunit_cell.Items.Add("cc");
            dvunit_cell.Items.Add("%");
          }
          else
          {
            dataGridView1[Column_dvvalue.Index, dataGridView1.CurrentRow.Index].ReadOnly = false;
            dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].ReadOnly = false;
            dataGridView1[Column_dvvalue.Index, dataGridView1.CurrentRow.Index].Style.BackColor = Color.White;
            dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].Style.BackColor = Color.White;
            if (Convert.ToString(dataGridView1[Column_unit.Index, dataGridView1.CurrentRow.Index].Value) == "Gy")
            {
              dataGridView1[Column_unit.Index, dataGridView1.CurrentRow.Index].Value = "";
            }
            if (Convert.ToString(dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].Value) == "cc")
            {
              dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index].Value = "";
            }
            DataGridViewComboBoxCell unit_cell = dataGridView1[Column_unit.Index, dataGridView1.CurrentRow.Index] as DataGridViewComboBoxCell;
            unit_cell.Items.Clear();
            unit_cell.Items.Add("cc");
            unit_cell.Items.Add("%");
            DataGridViewComboBoxCell dvunit_cell = dataGridView1[Column_dvunit.Index, dataGridView1.CurrentRow.Index] as DataGridViewComboBoxCell;
            dvunit_cell.Items.Clear();
            dvunit_cell.Items.Add("Gy");
            dvunit_cell.Items.Add("%");
          }
        }

        if (e.ColumnIndex == Column_dvvalue.Index |
            e.ColumnIndex == Column_criteria.Index |
            e.ColumnIndex == Column_tol.Index
            )
        {
          if (Convert.ToString(dataGridView1[e.ColumnIndex, e.RowIndex].Value) != "")
          {
            float dvvalue = 1;

            try
            {
              dvvalue = float.Parse(Convert.ToString(dataGridView1[e.ColumnIndex, e.RowIndex].Value));
            }
            catch (FormatException)
            {
              MessageBox.Show("数値を入力してください");
              dataGridView1[e.ColumnIndex, e.RowIndex].Value = "";
            }

            if (dvvalue <= 0)
            {
              MessageBox.Show("正の数を入力してください");
              dataGridView1[e.ColumnIndex, e.RowIndex].Value = "";
            }

          }
        }

        if (e.ColumnIndex != Column_result.Index & e.RowIndex == dataGridView1.CurrentRow.Index) 
        {
          dataGridView1[Column_result.Index, dataGridView1.CurrentRow.Index].Value = "";
          dataGridView1[Column_result.Index, dataGridView1.CurrentRow.Index].Style.BackColor = Color.White;
        }
      }

    }

    private string CaluculateDVH(DataGridViewRow row)
    {

      // Get MU
      if (label_mu.Text == "")
      {
        int MU = 0;
        var beams = planSetup.Beams;
        foreach (var beam in beams)
        {
          if (!beam.IsSetupField)
            MU += (int) Math.Round(beam.Meterset.Value * 10);
        }
        label_mu.Text = (1.0 * MU / 10).ToString("F1");
      }

      DataGridViewCellCollection row_cells = row.Cells;

      string struct_name = Convert.ToString(row_cells[Column_structure.Index].Value);
      string dv = Convert.ToString(row_cells[Column_dv.Index].Value);
      string dv_value = Convert.ToString(row_cells[Column_dvvalue.Index].Value);
      string dv_unit = Convert.ToString(row_cells[Column_dvunit.Index].Value);
      string unit = Convert.ToString(row_cells[Column_unit.Index].Value);
      string result = Convert.ToString(row_cells[Column_result.Index].Value);
      string sign = Convert.ToString(row_cells[Column_sign.Index].Value);
      string critria = Convert.ToString(row_cells[Column_criteria.Index].Value);
      string tol = Convert.ToString(row_cells[Column_tol.Index].Value);
      string value = "";
      bool isUnitDetermined = false;
      string doseUnit = "";

      string empty = "";
      if (result != "")
      {
        return result;
      }
      else if (struct_name == "" || dv == "" || unit == "")
      {
        return empty;
      }
      else
      {
        DoseValuePresentation doseAbs = DoseValuePresentation.Absolute;
        foreach (Structure s in ss.Structures)
        {

          if (s.Id == struct_name)
          {
            var volume = s.Volume;

            if (!isUnitDetermined)
            {
              DoseValue doseValue = planSetup.GetDVHCumulativeData(s, doseAbs, 0, 0.1).MaxDose;
              doseUnit = doseValue.UnitAsString;
              isUnitDetermined = true;
            }

            if (dv == "Dmax")
            {
              DoseValue doseValue;
              if (unit == "Gy")
              {
                doseValue = planSetup.GetDVHCumulativeData(s, doseAbs, 0, 0.1).MaxDose;
                value = doseUnit == "cGy" ? (doseValue.Dose / 100.0).ToString("F2") : doseValue.Dose.ToString("F2");
              }
              else
              {
                doseValue = planSetup.GetDVHCumulativeData(s, 0, 0, 0.1).MaxDose;
                value = doseValue.Dose.ToString("F2");
              }
            }
            else if (dv == "Dmean")
            {
              DoseValue doseValue;
              if (unit == "Gy")
              {
                doseValue = planSetup.GetDVHCumulativeData(s, doseAbs, 0, 0.1).MeanDose;
                value = doseUnit == "cGy" ? (doseValue.Dose / 100.0).ToString("F2") : doseValue.Dose.ToString("F2");
              }
              else
              {
                doseValue = planSetup.GetDVHCumulativeData(s, 0, 0, 0.1).MeanDose;
                value = doseValue.Dose.ToString("F2");
              }
            }
            else if (dv == "Dmin")
            {
              DoseValue doseValue;
              if (unit == "Gy")
              {
                doseValue = planSetup.GetDVHCumulativeData(s, doseAbs, 0, 0.1).MinDose;
                value = doseUnit == "cGy" ? (doseValue.Dose / 100.0).ToString("F2") : doseValue.Dose.ToString("F2");
              }
              else
              {
                doseValue = planSetup.GetDVHCumulativeData(s, 0, 0, 0.1).MinDose;
                value = doseValue.Dose.ToString("F2");
              }
            }
            else if (dv == "D" || dv == "DC")
            {
              double dx = double.Parse(dv_value);
              if (dv_unit == "" || dv_value == "")
              {
                return empty;
              }
              else if (dv_unit == "%")
              {
                if (dx <= 100.0)
                {
                  if (unit == "Gy")
                  {
                    if (dv == "D")
                    {
                      DoseValue doseValue = planSetup.GetDoseAtVolume(s, dx, 0, doseAbs);
                      value = doseUnit == "cGy" ? (doseValue.Dose / 100.0).ToString("F2") : doseValue.Dose.ToString("F2");
                    }
                    else if (dv == "DC")
                    {
                      DoseValue doseValue = planSetup.GetDoseAtVolume(s, 100 - dx, 0, doseAbs);
                      value = doseUnit == "cGy" ? (doseValue.Dose / 100.0).ToString("F2") : doseValue.Dose.ToString("F2");
                    }
                  }
                  else
                  {
                    if (dv == "D")
                    {
                      DoseValue doseValue = planSetup.GetDoseAtVolume(s, dx, 0, 0);
                      value = doseValue.Dose.ToString("F2");
                    }
                    else if (dv == "DC")
                    {
                      DoseValue doseValue = planSetup.GetDoseAtVolume(s, 100 - dx, 0, 0);
                      value = doseValue.Dose.ToString("F2");
                    }
                  }
                }
                else
                {
                  return empty;
                }
              }
              else
              {
                if (unit == "Gy")
                {
                  if (dv == "D")
                  {
                    DoseValue doseValue = planSetup.GetDoseAtVolume(s, dx, VolumePresentation.AbsoluteCm3, doseAbs);
                    value = doseUnit == "cGy" ? (doseValue.Dose / 100.0).ToString("F2") : doseValue.Dose.ToString("F2");
                  }
                  else if (dv == "DC")
                  {
                    DoseValue doseValue = planSetup.GetDoseAtVolume(s, volume - dx, VolumePresentation.AbsoluteCm3, doseAbs);
                    value = doseUnit == "cGy" ? (doseValue.Dose / 100.0).ToString("F2") : doseValue.Dose.ToString("F2");
                  }
                }
                else
                {
                  if (dv == "D")
                  {
                    DoseValue doseValue = planSetup.GetDoseAtVolume(s, dx, VolumePresentation.AbsoluteCm3, 0);
                    value = doseValue.Dose.ToString("F2");
                  }
                  else if (dv == "DC")
                  {
                    DoseValue doseValue = planSetup.GetDoseAtVolume(s, volume - dx, VolumePresentation.AbsoluteCm3, 0);
                    value = doseValue.Dose.ToString("F2");
                  }
                }
              }
            }
            else  // dv == "V" or "CV"
            {
              double vx = double.Parse(dv_value);
              if (dv_unit == "" || dv_value == "")
              {
                return empty;
              }
              else if (dv_unit == "%")
              {
                if (unit == "cc")
                {
                  DoseValue dose = new DoseValue(vx, DoseValue.DoseUnit.Percent);
                  double doseValue = planSetup.GetVolumeAtDose(s, dose, VolumePresentation.AbsoluteCm3);
                  if (dv == "V")
                  {
                    value = doseValue.ToString("F2");
                  }
                  else if (dv == "CV")
                  {
                    value = (volume - doseValue).ToString("F2");
                  }
                }
                else
                {
                  DoseValue dose = new DoseValue(vx, DoseValue.DoseUnit.Percent);
                  double doseValue = planSetup.GetVolumeAtDose(s, dose, VolumePresentation.Relative);
                  if (dv == "V")
                  {
                    value = doseValue.ToString("F2");
                  }
                  else if (dv == "CV")
                  {
                    value = (100.0 - doseValue).ToString("F2");
                  }
                }
              }
              else // dvunit == "Gy"
              {
                if (unit == "cc")
                {
                  DoseValue dose = doseUnit == "cGy" ? new DoseValue(vx * 100, DoseValue.DoseUnit.cGy) : new DoseValue(vx, DoseValue.DoseUnit.Gy);
                  double doseValue = planSetup.GetVolumeAtDose(s, dose, VolumePresentation.AbsoluteCm3);
                  if (dv == "V")
                  {
                    value = doseValue.ToString("F2");
                  }
                  else if (dv == "CV")
                  {
                    value = (volume - doseValue).ToString("F2");
                  }
                }
                else
                {
                  DoseValue dose = doseUnit == "cGy" ? new DoseValue(vx * 100, DoseValue.DoseUnit.cGy) : new DoseValue(vx, DoseValue.DoseUnit.Gy);
                  double doseValue = planSetup.GetVolumeAtDose(s, dose, VolumePresentation.Relative);
                  if (dv == "V")
                  {
                    value = doseValue.ToString("F2");
                  }
                  else if (dv == "CV")
                  {
                    value = (100.0 - doseValue).ToString("F2");
                  }
                }
              }
            }
          }
        }

        double compare = Convert.ToDouble(value);
        double diff;
        var ok_color = Color.LightGreen;
        var tol_color = Color.Yellow;
        var ng_color = Color.Red;

        // Compare to criterion
        if (sign != "" && critria != "")
        {
          diff = compare - Convert.ToDouble(critria);
          if (sign == "=")
          {
            if (Math.Abs(diff) < 0.01)
            {
              row.Cells[Column_result.Index].Style.BackColor = ok_color;
            }
            else
            {
              if (tol != "")
              {
                if (Math.Abs(diff) < Convert.ToDouble(tol))
                  row.Cells[Column_result.Index].Style.BackColor = tol_color;
                else
                  row.Cells[Column_result.Index].Style.BackColor = ng_color;
              }
              else
              {
                row.Cells[Column_result.Index].Style.BackColor = ng_color;
              }
            }

          }
          else if (sign == "<=")
          {
            if (diff <= 0)
            {
              row.Cells[Column_result.Index].Style.BackColor = ok_color;
            }
            else
            {
              if (tol != "")
              {
                if (diff <= Convert.ToDouble(tol))
                  row.Cells[Column_result.Index].Style.BackColor = tol_color;
                else
                  row.Cells[Column_result.Index].Style.BackColor = ng_color;
              }
              else
              {
                row.Cells[Column_result.Index].Style.BackColor = ng_color;
              }
            }
          }
          else if (sign == ">=")
          {
            if (diff >= 0)
            {
              row.Cells[Column_result.Index].Style.BackColor = ok_color;
            }
            else
            {
              if (tol != "")
              {
                if (diff >= -Convert.ToDouble(tol))
                  row.Cells[Column_result.Index].Style.BackColor = tol_color;
                else
                  row.Cells[Column_result.Index].Style.BackColor = ng_color;
              }
              else
              {
                row.Cells[Column_result.Index].Style.BackColor = ng_color;
              }
            }

          }
        }


        return value;
      }

    }

    private void OpenTemplate(String filename)
    {
      dataGridView1.Rows.Clear();
      TextFieldParser parser = new TextFieldParser(filename);
      parser.TextFieldType = FieldType.Delimited;
      parser.SetDelimiters(",");

      List<String> strList = new List<String>();

      while (!parser.EndOfData)
      {
        string[] row = parser.ReadFields();
        strList.Add(row[0]);
      }

      parser.Close();

      List<List<String>> returnedList = Form2.ShowMiniForm(strList, ss);

      TextFieldParser parser2 = new TextFieldParser(filename);
      parser2.TextFieldType = FieldType.Delimited;
      parser2.SetDelimiters(",");

      List<String> strList2 = new List<String>();
      int i = 0;
      int j = 0;
      while (!parser2.EndOfData)
      {
        string[] row = parser2.ReadFields();

        for (j = 0; j < returnedList.Count(); j++)
        {
          row[0] = row[0] == returnedList[j][0] ? returnedList[j][1] : row[0];
        }

        if (row[0] != "")
        {
          if (row.Length == 5)
          {
            row.CopyTo(row = new string[row.Length + 7], 0);
            row[7] = row[4];
            row[9] = "";
            row[10] = "";
            row[11] = "";
            dataGridView1.Rows.Add(row);
          }
          else if (row.Length == 8)
          {
            row.CopyTo(row = new string[row.Length + 4], 0);
            row[11] = row[7];
            row[10] = row[6];
            row[9] = row[5];
            row[7] = row[4];
            row[6] = "";
            row[5] = "";
            dataGridView1.Rows.Add(row);
          }
        }

        i++;
      }

      // Automatically calculate
      foreach (DataGridViewRow r in dataGridView1.Rows)
      {
        string dv = Convert.ToString(r.Cells[Column_dv.Index].Value);
        if (dv == "Dmax" || dv == "Dmean" || dv == "Dmin")
        {
          r.Cells[Column_dvvalue.Index].ReadOnly = true;
          r.Cells[Column_dvvalue.Index].Style.BackColor = Color.LightGray;
          r.Cells[Column_dvunit.Index].ReadOnly = true;
          r.Cells[Column_dvunit.Index].Style.BackColor = Color.LightGray;
        }

        r.Cells[Column_result.Index].Value = CaluculateDVH(r);
      }
    }

    private void SaveTemplate(String filename)
    {
      using(StreamWriter writer = new StreamWriter(filename))
      {
        int rowCount = dataGridView1.Rows.Count;

        if (rowCount > 0)
        {
          for (int i = 0; i < rowCount; i++)
          {
            List<String> strList = new List<String>();

            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
              if (j < 5 || j > 8)
              {
                strList.Add(Convert.ToString(dataGridView1[j, i].Value));
              }
            }
            String[] strArray = strList.ToArray();

            String strCSvData = String.Join(",", strArray);

            writer.WriteLine(strCSvData);
          }
        }
        else
        {
          writer.Write("");
        }
      }
    }

    private void SaveResults(String filename)
    {
      Encoding sjis = Encoding.GetEncoding("Shift-JIS");
      using(StreamWriter writer = new StreamWriter(filename, false, sjis))
      {
        int rowCount = dataGridView1.Rows.Count;

        if (rowCount > 0)
        {
          string head_id = String.Format("PID,{0}", context.Patient.Id);
          string head_name = String.Format("Name,{0} {1}", context.Patient.LastName, context.Patient.FirstName);

          writer.WriteLine(head_id);
          writer.WriteLine(head_name);

          List<String> header = new List<String>();

          header.Add("Structure");
          header.Add("Parameter");
          header.Add("DVH Value");
          header.Add("DVH Unit");
          header.Add("Judge");
          header.Add("Criteria");
          header.Add("Tolerance");

          String[] headerArray = header.ToArray();
          String headerCsvData = String.Join(",", headerArray);

          writer.WriteLine(headerCsvData);

          for (int i = 0; i < rowCount; i++)
          {
            List<String> strList = new List<String>();

            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
              if ((j < 1 || j > 5) && j != 8)
              {
                strList.Add(Convert.ToString(dataGridView1[j, i].Value));
              }
              else if (j == 1)
              {
                String parameter = String.Format("{0}{1}{2}",
                 dataGridView1[j, i].Value, dataGridView1[j + 1, i].Value, dataGridView1[j + 2, i].Value);
                strList.Add(parameter);
              }
            }

            String[] strArray = strList.ToArray();

            String strCSvData = String.Join(",", strArray);

            writer.WriteLine(strCSvData);
          }

          if (label_mu.Text != "")
          {
            List<String> strList = new List<String>();
            strList.Add("Total MU");
            strList.Add("");
            strList.Add(label_mu.Text);
            strList.Add("");
            String[] strArray = strList.ToArray();

            String strCSvData = String.Join(",", strArray);

            writer.WriteLine(strCSvData);
          }
        }
        else
        {
          writer.Write("");
        }
      }
    }

    private void button_calc_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow r in dataGridView1.Rows)
      {
        r.Cells[Column_result.Index].Value = CaluculateDVH(r);
      }
    }

    private void button_open_Click(object sender, EventArgs e)
    {
      if (File.Exists(setting))
      {
        using(StreamReader sr = new StreamReader(setting, Encoding.GetEncoding("shift-jis")))
        {
          while (sr.EndOfStream == false)
          {
            string[] line = sr.ReadLine().Split(' ');
            if (line[0] == "Template")
            {
              if (Directory.Exists(line[1]))
              {
                openFileDialog1.InitialDirectory = line[1];
              }
            }
          }
        }
      }
      // openFileDialog1.InitialDirectory = @"C:\";
      openFileDialog1.Filter = "CSV file|*.csv";
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        OpenTemplate(openFileDialog1.FileName);
      }
    }

    private void button_save_Click(object sender, EventArgs e)
    {
      if (File.Exists(setting))
      {
        using(StreamReader sr = new StreamReader(setting, Encoding.GetEncoding("shift-jis")))
        {
          while (sr.EndOfStream == false)
          {
            string[] line = sr.ReadLine().Split(' ');
            if (line[0] == "Template")
            {
              if (Directory.Exists(line[1]))
              {
                saveFileDialog1.InitialDirectory = line[1];
              }
            }
          }
        }
      }

      saveFileDialog1.Filter = "CSV file|*.csv";
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        SaveTemplate(saveFileDialog1.FileName);
      }
    }

    private void button_export_Click(object sender, EventArgs e)
    {
      if (File.Exists(setting))
      {
        using(StreamReader sr = new StreamReader(setting, Encoding.GetEncoding("shift-jis")))
        {
          while (sr.EndOfStream == false)
          {
            string[] line = sr.ReadLine().Split(' ');
            if (line[0] == "Export")
            {
              if (Directory.Exists(line[1]))
              {
                saveFileDialog2.InitialDirectory = line[1];
              }
            }
          }
        }
      }
      // saveFileDialog2.InitialDirectory = @"C:\";
      saveFileDialog2.Filter = "CSV file|*.csv";
      String pname = context.Patient.LastName;
      if (context.Patient.FirstName != "")
      {
        pname = pname + "_" + context.Patient.FirstName;
      }
      String file = context.Patient.Id + "_" + pname + "_" + planSetup.Id; // + DateTime.Now.ToString("yyyyMMddHHmm");
      saveFileDialog2.FileName = file;
      if (saveFileDialog2.ShowDialog() == DialogResult.OK)
      {
        SaveResults(saveFileDialog2.FileName);
      }
    }

    private void button_close_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.C && e.Control == true)
      {
        button_calc.Focus();
        button_calc.PerformClick();
      }
      else if (e.KeyCode == Keys.A && e.Control == true)
      {
        button_add.Focus();
        button_add.PerformClick();
      }
      else if (e.KeyCode == Keys.D && e.Control == true)
      {
        button_delete.Focus();
        button_delete.PerformClick();
      }
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      Form3 form3 = new Form3();
      form3.ShowDialog();
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
      Form4 form4 = new Form4();
      form4.ShowDialog();
    }
  }
}