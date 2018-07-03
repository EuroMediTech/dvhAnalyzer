using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DVHAnalyzer
{
  public partial class Form3 : Form
  {
    public Form3()
    {
      InitializeComponent();

      // Default設定を入れておく
      textBox1.Text = @"C:\";
      textBox2.Text = @"C:\";

      string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      string path = String.Format(@"{0}\EMT", appdata);

      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }

      string setting = String.Format(@"{0}\settings.ini", path);

      if (File.Exists(setting))
      {
        using (StreamReader sr = new StreamReader(setting, Encoding.GetEncoding("shift-jis")))
        {
          while (sr.EndOfStream == false)
          {
            string[] line = sr.ReadLine().Split(' ');
            if (line[0] == "Template")
            {
              textBox1.Text = line[1];
            }
            else if (line[0] == "Export")
            {
              textBox2.Text = line[1];
            }
          }
        }
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      folderBrowserDialog1.Description = "Templateの保存先を指定してください";
      folderBrowserDialog1.SelectedPath = textBox1.Text;

      if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
      {
        textBox1.Text = folderBrowserDialog1.SelectedPath;
      }

    }

    private void button2_Click(object sender, EventArgs e)
    {
      folderBrowserDialog2.Description = "DVHデータのExport先を指定してください";
      folderBrowserDialog2.SelectedPath = textBox2.Text;

      if (folderBrowserDialog2.ShowDialog(this) == DialogResult.OK)
      {
        textBox2.Text = folderBrowserDialog2.SelectedPath;
      }

    }

    private void button3_Click(object sender, EventArgs e)
    {
      string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      string path = String.Format(@"{0}\EMT", appdata);
      string setting = String.Format(@"{0}\settings.ini", path);

      using (StreamWriter sw = new StreamWriter(setting, false, Encoding.GetEncoding("Shift-JIS")))
      {
        sw.WriteLine(String.Format("Template {0}", textBox1.Text));
        sw.WriteLine(String.Format("Export {0}", textBox2.Text));
      }

      MessageBox.Show("設定を保存しました。");
    }

    private void button4_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
