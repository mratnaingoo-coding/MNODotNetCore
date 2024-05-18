using MNODotNetCore.shared;
using MNODotNetCore.WinFormsApp.Model;
using MNODotNetCore.WinFormsApp.Queries;

namespace MNODotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperServices _dapper;

        public FrmBlog()
        {
            InitializeComponent();
            _dapper = new DapperServices (ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel ();
                blog.BlogTitle = txtTitle.Text.Trim();
                blog.BlogAuthor = txtAuthor.Text.Trim();
                blog.BlogContent = txtContent.Text.Trim();

                int result =  _dapper.Execute(BlogQuery.CreateQuery, blog);
                string message = result > 0 ? "Saving successful." : "Saving fail.";
                var msgBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog",MessageBoxButtons.OK, msgBoxIcon);

                if(result > 0) clearControls();
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
    }
}
