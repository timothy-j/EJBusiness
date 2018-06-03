using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestControlLibrary
{
    public partial class UserControl1: UserControl
    {
        private EJData.CorporateEntities _db;
        private ToolStripControlHost m_host;
        private ToolStripDropDown m_dropDownStrip = new ToolStripDropDown();

        public UserControl1()
        {
            InitializeComponent();

            _db = EJData.DataHelpers.GetNewDbContext();
            bindingSource1.DataSource = _db.Parts.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridView DropDownGrid = new DataGridView();
            DropDownGrid.DataSource = bindingSource1;
            Button btn = new Button();
            this.Controls.Add(DropDownGrid);
            //if (m_host is null)
            //{
            //    m_host = new ToolStripControlHost(btn);
            //}
            //m_host.Width = btn.Width;
            ////m_host.Height = DropDownGrid.Height;
            //m_dropDownStrip.Items.Add(m_host);
            //m_dropDownStrip.Show();

            if (m_host is null)
            {
                m_host = new ToolStripControlHost(DropDownGrid);
            }
            m_host.Width = DropDownGrid.Width;
            //m_host.Height = DropDownGrid.Height;
            m_dropDownStrip.Items.Add(m_host);
            //m_dropDownStrip.Left = Me.PointToScreen(New Point With {.X = 0, .Y = Height}).X
            //m_dropDownStrip.Top = Me.PointToScreen(New Point With {.X = 0, .Y = Height}).Y
            //'m_dropDownStrip.Size = m_host.Size
            //'DropDownGrid.Invalidate()
            //'DropDownGrid.AutoGenerateColumns = True
            m_dropDownStrip.Show();
            //'DropDownGrid.DataSource.ResetBindings(False)
            //DropDownGrid.Invalidate();
            //DropDownGrid.Focus();
        }
    }
}
