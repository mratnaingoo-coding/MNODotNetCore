using MNODotNetCore.shared;

namespace MNODotNetCore.WinFormsAppSQLInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperServices _dapperServices;
        public Form1()
        {
            InitializeComponent();
            _dapperServices = new DapperServices(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // It will happen the sql injection.
           /* string query = $"select * from Tbl_User where email = '{txtEmail.Text.Trim()}' and password = '{txtPassword.Text.Trim()}'";
           */ 
            string query = $"select * from Tbl_User where email = @Email and password = @Password";
            var model = _dapperServices.QueryFirstOrDefault<UserModel>(query, new
            {
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim()
            });
            if(model is null)
            {
                MessageBox.Show("User doesn't exist.");
            }
            MessageBox.Show("Is Admin: " + model.Email);
        }
    }
    public class UserModel
    {
        public string Email { get; set;}
        public bool IsAdmin { get; set;}
    }
}
