using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sa
{
    public partial class dgvNhom : Form
    {
        public dgvNhom()
        {
            InitializeComponent();
        }
        private string tukhoa = "";
        private void frmdsNhom_Load(object sender, EventArgs e)
        {
            loadDSN();
        }
        private void loadDSN()
        {
            string sql = "allNhom";
            List<CustomParameter> lstPara = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                }
            };
            dgc.DataSource = new Database().selectData(sql,lstPara);
        }

        private void dgc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
