using System;
using System.Windows.Forms;

namespace CustomComboDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Dynamically created controls.
            
            // Create grid view control.
            DataGridView gridView = new DataGridView();
            gridView.BorderStyle = BorderStyle.None;
            gridView.Columns.Add("Column1", "Column 1");
            gridView.Columns.Add("Column2", "Column 2");
            gridView.Columns.Add("Column3", "Column 3");
            gridView.Columns.Add("Column4", "Column 4");
            gridView.Columns.Add("Column5", "Column 5");
            this.customComboBox1.DropDownControl = gridView;

            // Create user control.
            UserControl1 userControl = new UserControl1();
            userControl.BorderStyle = BorderStyle.None;
            this.customComboBox2.DropDownControl = userControl;

            // Create rich textbox control.
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.BorderStyle = BorderStyle.None;
            this.customComboBox3.DropDownControl = richTextBox;
        }

        void customComboBox1_DropDown(object sender, System.EventArgs e)
        {
            label1.Text = "Combo Box 1 Opened";
        }

        void customComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            label1.Text = "Combo Box 1 Closed";
        }

        void customComboBox2_DropDown(object sender, System.EventArgs e)
        {
            label1.Text = "Combo Box 2 Opened";
        }

        void customComboBox2_DropDownClosed(object sender, EventArgs e)
        {
            label1.Text = "Combo Box 2 Closed";
        }

        void customComboBox3_DropDown(object sender, System.EventArgs e)
        {
            label1.Text = "Combo Box 3 Opened";
        }

        void customComboBox3_DropDownClosed(object sender, EventArgs e)
        {
            label1.Text = "Combo Box 3 Closed";
        }
    }
}
