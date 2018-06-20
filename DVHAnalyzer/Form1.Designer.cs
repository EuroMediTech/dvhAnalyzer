namespace DVHAnalyzer
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.button_delete = new System.Windows.Forms.Button();
      this.button_add = new System.Windows.Forms.Button();
      this.button_calc = new System.Windows.Forms.Button();
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.label_mu = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.button_close = new System.Windows.Forms.Button();
      this.button_export = new System.Windows.Forms.Button();
      this.button_save = new System.Windows.Forms.Button();
      this.button_open = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
      this.Column_structure = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column_dv = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column_dvvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column_dvunit = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column_unit = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column_space = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column_result = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column_textunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.button_close);
      this.splitContainer1.Panel2.Controls.Add(this.button_export);
      this.splitContainer1.Panel2.Controls.Add(this.button_save);
      this.splitContainer1.Panel2.Controls.Add(this.button_open);
      this.splitContainer1.Size = new System.Drawing.Size(741, 614);
      this.splitContainer1.SplitterDistance = 524;
      this.splitContainer1.SplitterWidth = 6;
      this.splitContainer1.TabIndex = 0;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.button_delete);
      this.splitContainer2.Panel1.Controls.Add(this.button_add);
      this.splitContainer2.Panel1.Controls.Add(this.button_calc);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
      this.splitContainer2.Size = new System.Drawing.Size(741, 524);
      this.splitContainer2.SplitterDistance = 59;
      this.splitContainer2.TabIndex = 1;
      // 
      // button_delete
      // 
      this.button_delete.Location = new System.Drawing.Point(476, 17);
      this.button_delete.Name = "button_delete";
      this.button_delete.Size = new System.Drawing.Size(115, 36);
      this.button_delete.TabIndex = 4;
      this.button_delete.Text = "Delete Row";
      this.button_delete.UseVisualStyleBackColor = true;
      this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
      // 
      // button_add
      // 
      this.button_add.Location = new System.Drawing.Point(349, 17);
      this.button_add.Name = "button_add";
      this.button_add.Size = new System.Drawing.Size(121, 36);
      this.button_add.TabIndex = 3;
      this.button_add.Text = "Add Row";
      this.button_add.UseVisualStyleBackColor = true;
      this.button_add.Click += new System.EventHandler(this.button_add_Click);
      // 
      // button_calc
      // 
      this.button_calc.Location = new System.Drawing.Point(597, 17);
      this.button_calc.Name = "button_calc";
      this.button_calc.Size = new System.Drawing.Size(141, 36);
      this.button_calc.TabIndex = 2;
      this.button_calc.Text = "Calculate DVH";
      this.button_calc.UseVisualStyleBackColor = true;
      this.button_calc.Click += new System.EventHandler(this.button_calc_Click);
      // 
      // splitContainer3
      // 
      this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer3.Location = new System.Drawing.Point(0, 0);
      this.splitContainer3.Name = "splitContainer3";
      this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer3.Panel1
      // 
      this.splitContainer3.Panel1.Controls.Add(this.dataGridView1);
      // 
      // splitContainer3.Panel2
      // 
      this.splitContainer3.Panel2.Controls.Add(this.label_mu);
      this.splitContainer3.Panel2.Controls.Add(this.label1);
      this.splitContainer3.Size = new System.Drawing.Size(741, 461);
      this.splitContainer3.SplitterDistance = 430;
      this.splitContainer3.TabIndex = 2;
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AllowUserToResizeRows = false;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_structure,
            this.Column_dv,
            this.Column_dvvalue,
            this.Column_dvunit,
            this.Column_unit,
            this.Column_space,
            this.Column_result,
            this.Column_textunit});
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.RowTemplate.Height = 30;
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.dataGridView1.Size = new System.Drawing.Size(741, 430);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
      // 
      // label_mu
      // 
      this.label_mu.AutoSize = true;
      this.label_mu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_mu.Location = new System.Drawing.Point(647, 0);
      this.label_mu.Name = "label_mu";
      this.label_mu.Size = new System.Drawing.Size(0, 21);
      this.label_mu.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(568, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(73, 21);
      this.label1.TabIndex = 1;
      this.label1.Text = "Total MU";
      // 
      // button_close
      // 
      this.button_close.Location = new System.Drawing.Point(617, 42);
      this.button_close.Name = "button_close";
      this.button_close.Size = new System.Drawing.Size(112, 35);
      this.button_close.TabIndex = 3;
      this.button_close.Text = "Close";
      this.button_close.UseVisualStyleBackColor = true;
      this.button_close.Click += new System.EventHandler(this.button_close_Click);
      // 
      // button_export
      // 
      this.button_export.Location = new System.Drawing.Point(617, 0);
      this.button_export.Name = "button_export";
      this.button_export.Size = new System.Drawing.Size(112, 36);
      this.button_export.TabIndex = 2;
      this.button_export.Text = "Export";
      this.button_export.UseVisualStyleBackColor = true;
      this.button_export.Click += new System.EventHandler(this.button_export_Click);
      // 
      // button_save
      // 
      this.button_save.Location = new System.Drawing.Point(461, 0);
      this.button_save.Name = "button_save";
      this.button_save.Size = new System.Drawing.Size(141, 36);
      this.button_save.TabIndex = 1;
      this.button_save.Text = "Save as Template";
      this.button_save.UseVisualStyleBackColor = true;
      this.button_save.Click += new System.EventHandler(this.button_save_Click);
      // 
      // button_open
      // 
      this.button_open.Location = new System.Drawing.Point(314, 0);
      this.button_open.Name = "button_open";
      this.button_open.Size = new System.Drawing.Size(141, 36);
      this.button_open.TabIndex = 0;
      this.button_open.Text = "Open Template";
      this.button_open.UseVisualStyleBackColor = true;
      this.button_open.Click += new System.EventHandler(this.button_open_Click);
      // 
      // Column_structure
      // 
      this.Column_structure.FillWeight = 106.599F;
      this.Column_structure.HeaderText = "Structure";
      this.Column_structure.Name = "Column_structure";
      this.Column_structure.Sorted = true;
      // 
      // Column_dv
      // 
      this.Column_dv.FillWeight = 97.63348F;
      this.Column_dv.HeaderText = "Dose/Volume";
      this.Column_dv.Items.AddRange(new object[] {
            "V",
            "D",
            "Dmax",
            "Dmean",
            "Dmin"});
      this.Column_dv.Name = "Column_dv";
      // 
      // Column_dvvalue
      // 
      this.Column_dvvalue.FillWeight = 97.63348F;
      this.Column_dvvalue.HeaderText = "Value";
      this.Column_dvvalue.Name = "Column_dvvalue";
      this.Column_dvvalue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column_dvunit
      // 
      this.Column_dvunit.FillWeight = 50F;
      this.Column_dvunit.HeaderText = "In_Unit";
      this.Column_dvunit.Items.AddRange(new object[] {
            "Gy",
            "cc",
            "%"});
      this.Column_dvunit.Name = "Column_dvunit";
      // 
      // Column_unit
      // 
      this.Column_unit.FillWeight = 60F;
      this.Column_unit.HeaderText = "Out_Unit";
      this.Column_unit.Items.AddRange(new object[] {
            "Gy",
            "cc",
            "%"});
      this.Column_unit.Name = "Column_unit";
      // 
      // Column_space
      // 
      this.Column_space.FillWeight = 10F;
      this.Column_space.HeaderText = "";
      this.Column_space.Name = "Column_space";
      this.Column_space.ReadOnly = true;
      this.Column_space.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column_space.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column_result
      // 
      this.Column_result.FillWeight = 97.63348F;
      this.Column_result.HeaderText = "Result";
      this.Column_result.Name = "Column_result";
      this.Column_result.ReadOnly = true;
      this.Column_result.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column_textunit
      // 
      this.Column_textunit.FillWeight = 30F;
      this.Column_textunit.HeaderText = "";
      this.Column_textunit.Name = "Column_textunit";
      this.Column_textunit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(741, 614);
      this.Controls.Add(this.splitContainer1);
      this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "DVH Analyzer";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel2.ResumeLayout(false);
      this.splitContainer3.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
      this.splitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Button button_open;
    private System.Windows.Forms.Button button_save;
    private System.Windows.Forms.Button button_calc;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.Button button_export;
    private System.Windows.Forms.Button button_add;
    private System.Windows.Forms.Button button_delete;
    private System.Windows.Forms.SplitContainer splitContainer3;
    private System.Windows.Forms.Label label_mu;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    private System.Windows.Forms.Button button_close;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column_structure;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column_dv;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column_dvvalue;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column_dvunit;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column_unit;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column_space;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column_result;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column_textunit;
  }
}