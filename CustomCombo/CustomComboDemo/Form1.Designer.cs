namespace CustomComboDemo
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
            this.label1 = new System.Windows.Forms.Label();
            this.customComboBox3 = new CustomComboBox.CustomComboBox();
            this.customComboBox2 = new CustomComboBox.CustomComboBox();
            this.customComboBox1 = new CustomComboBox.CustomComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "DropDown and DropDownClosed Status";
            // 
            // customComboBox3
            // 
            this.customComboBox3.AllowResizeDropDown = true;
            this.customComboBox3.ControlSize = new System.Drawing.Size(121, 106);
            this.customComboBox3.DropDownControl = null;
            this.customComboBox3.DropSize = new System.Drawing.Size(121, 106);
            this.customComboBox3.FormattingEnabled = true;
            this.customComboBox3.Location = new System.Drawing.Point(12, 151);
            this.customComboBox3.Name = "customComboBox3";
            this.customComboBox3.Size = new System.Drawing.Size(329, 21);
            this.customComboBox3.TabIndex = 8;
            this.customComboBox3.Text = "Click arrow to view a rich text box...";
            this.customComboBox3.DropDown += new System.EventHandler(this.customComboBox3_DropDown);
            this.customComboBox3.DropDownClosed += new System.EventHandler(this.customComboBox3_DropDownClosed);
            // 
            // customComboBox2
            // 
            this.customComboBox2.AllowResizeDropDown = true;
            this.customComboBox2.ControlSize = new System.Drawing.Size(1, 1);
            this.customComboBox2.DropDownControl = null;
            this.customComboBox2.DropDownSizeMode = CustomComboBox.CustomComboBox.SizeMode.UseControlSize;
            this.customComboBox2.DropSize = new System.Drawing.Size(121, 106);
            this.customComboBox2.FormattingEnabled = true;
            this.customComboBox2.Location = new System.Drawing.Point(12, 92);
            this.customComboBox2.Name = "customComboBox2";
            this.customComboBox2.Size = new System.Drawing.Size(329, 21);
            this.customComboBox2.TabIndex = 7;
            this.customComboBox2.Text = "Click arrow to view a custom user control...";
            this.customComboBox2.DropDown += new System.EventHandler(this.customComboBox2_DropDown);
            this.customComboBox2.DropDownClosed += new System.EventHandler(this.customComboBox2_DropDownClosed);
            // 
            // customComboBox1
            // 
            this.customComboBox1.AllowResizeDropDown = false;
            this.customComboBox1.ControlSize = new System.Drawing.Size(320, 222);
            this.customComboBox1.DropDownControl = null;
            this.customComboBox1.DropDownSizeMode = CustomComboBox.CustomComboBox.SizeMode.UseDropDownSize;
            this.customComboBox1.DropSize = new System.Drawing.Size(420, 200);
            this.customComboBox1.FormattingEnabled = true;
            this.customComboBox1.Location = new System.Drawing.Point(12, 33);
            this.customComboBox1.Name = "customComboBox1";
            this.customComboBox1.Size = new System.Drawing.Size(329, 21);
            this.customComboBox1.TabIndex = 6;
            this.customComboBox1.Text = "Click arrow to view data grid...";
            this.customComboBox1.DropDown += new System.EventHandler(this.customComboBox1_DropDown);
            this.customComboBox1.DropDownClosed += new System.EventHandler(this.customComboBox1_DropDownClosed);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 193);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customComboBox3);
            this.Controls.Add(this.customComboBox2);
            this.Controls.Add(this.customComboBox1);
            this.Name = "Form1";
            this.Text = "Custom ComboBox Demonstration";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomComboBox.CustomComboBox customComboBox1;
        private CustomComboBox.CustomComboBox customComboBox2;
        private CustomComboBox.CustomComboBox customComboBox3;
        private System.Windows.Forms.Label label1;
    }
}

