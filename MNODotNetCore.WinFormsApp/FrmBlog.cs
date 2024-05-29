using MNODotNetCore.shared;
using MNODotNetCore.WinFormsApp.Model;
using MNODotNetCore.WinFormsApp.Queries;
using System.Data.SqlClient;
using System.Data;

namespace MNODotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperServices _dapperService;
        private readonly int _blogId;
        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperServices(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }
        public FrmBlog(int BlogId)
        {
            InitializeComponent();
            _blogId = BlogId;
            _dapperService = new DapperServices(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var model = _dapperService.QueryFirstOrDefault<BlogModel>("SELECT * FROM tbl_blog WHERE BlogID = @BlogID", new { BlogID = _blogId });

            txtTitle.Text = model.BlogTitle;
            txtAuthor.Text = model.BlogAuthor;
            txtContent.Text = model.BlogContent;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel();
                blog.BlogTitle = txtTitle.Text.Trim();
                blog.BlogAuthor = txtAuthor.Text.Trim();
                blog.BlogContent = txtContent.Text.Trim();

                int result = _dapperService.Execute(BlogQuery.CreateQuery, blog);
                string message = result > 0 ? "Saving successful." : "Saving fail.";
                var msgBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, msgBoxIcon);

                if (result > 0) clearControls();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.ToString());
            }
        }

        private void clearControls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }

        private void FrmBlog_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                var item = new BlogModel
                {
                    BlogID = _blogId,
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim()
                };
                string query = @"UPDATE [dbo].[tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogID = @BlogID";

                int result = _dapperService.Execute(query,item);
                string message = result > 0 ? "Updating success." : "Updating fail.";
                MessageBox.Show(message);

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
