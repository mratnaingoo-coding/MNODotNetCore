using MNODotNetCore.shared;
using MNODotNetCore.WinFormsApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNODotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperServices _dapper;
        public FrmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false; // support just giving column only.
            _dapper = new DapperServices(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }
        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            List<BlogModel> lst = _dapper.Query<BlogModel>("select * from tbl_blog");
            dgvData.DataSource = lst;
        }
    }
}
