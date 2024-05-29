using Dapper;
using MNODotNetCore.shared;
using MNODotNetCore.WinFormsApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNODotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperServices _dapper;/*
        private const int _edit = 1;
        private const int _delete = 2;*/
        public FrmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false; // support just giving column only.
            _dapper = new DapperServices(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }
        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }
        private void BlogList()
        {
            List<BlogModel> lst = _dapper.Query<BlogModel>("select * from tbl_blog");
            dgvData.DataSource = lst;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int columnIndex = e.ColumnIndex
            //int rowIndex = e.RowIndex
            if (e.RowIndex == -1) return;
            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);
/*
            #region If Case
            if (e.ColumnIndex == (Int32)EnumFrmControlType.Edit)
            {
                FrmBlog frm = new FrmBlog(blogId);
                frm.ShowDialog();

                BlogList();

            }else if(e.ColumnIndex == (Int32)EnumFrmControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure to delete?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
                DeleteBlog(blogId);
            }
            #endregion
*/
            #region Switch Case
            int index = e.ColumnIndex;
            EnumFrmControlType enumFrmControlType = (EnumFrmControlType)index;
            switch (enumFrmControlType)
            {
                case EnumFrmControlType.Edit:
                    FrmBlog frm = new FrmBlog(blogId);
                    frm.ShowDialog();

                    BlogList();
                    break;
                case EnumFrmControlType.Delete:
                    var dialogResult = MessageBox.Show("Are you sure to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult != DialogResult.Yes) return;
                    DeleteBlog(blogId);
                    break;
                default:
                    MessageBox.Show("Invalid & Try again!");
                    break; 
            };

            #endregion
        }
        private void DeleteBlog(int id)
        {
            string query = @"DELETE FROM tbl_blog WHERE BlogID = @BlogID";

            int result = _dapper.Execute(query, new { BlogId = id });
            string message = result > 0 ? "Deleting success." : "Deleting fail.";
            MessageBox.Show(message);
            BlogList();
        }
    }
}
