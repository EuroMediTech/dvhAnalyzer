namespace DVHAnalyzer
{
  partial class Form3
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.button1 = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.button2 = new System.Windows.Forms.Button();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.groupBox1.Location = new System.Drawing.Point(33, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(663, 72);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Template Directory";
      // 
      // textBox1
      // 
      this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.textBox1.Location = new System.Drawing.Point(144, 32);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(513, 27);
      this.textBox1.TabIndex = 0;
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.button1.Location = new System.Drawing.Point(27, 27);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(111, 33);
      this.button1.TabIndex = 1;
      this.button1.Text = "Set Directory";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.textBox2);
      this.groupBox2.Controls.Add(this.button2);
      this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.groupBox2.Location = new System.Drawing.Point(33, 90);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(663, 72);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Export Directory";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(27, 28);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(111, 33);
      this.button2.TabIndex = 0;
      this.button2.Text = "Set Directory";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // textBox2
      // 
      this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.textBox2.Location = new System.Drawing.Point(144, 32);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(513, 27);
      this.textBox2.TabIndex = 1;
      // 
      // button3
      // 
      this.button3.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.button3.Location = new System.Drawing.Point(468, 171);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(106, 28);
      this.button3.TabIndex = 2;
      this.button3.Text = "Save";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button4
      // 
      this.button4.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.button4.Location = new System.Drawing.Point(584, 171);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(106, 28);
      this.button4.TabIndex = 3;
      this.button4.Text = "Close";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // Form3
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(708, 211);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "Form3";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Settings";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
  }
}