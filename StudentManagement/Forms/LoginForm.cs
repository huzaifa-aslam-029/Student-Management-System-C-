using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace StudentManagement.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            string u = txtUsername.Text.Trim();
            string p = SecurityHelper.HashPassword(txtPassword.Text.Trim());

            using var db = new DataAccess();
            var dt = db.GetTable(
                "SELECT Role, StudentID FROM Users WHERE Username=? AND PasswordHash=?",
                new OleDbParameter("@p1", u),
                new OleDbParameter("@p2", p)
            );

            if (dt.Rows.Count == 1)
            {
                string role = dt.Rows[0]["Role"].ToString() ?? "";
                if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    var f = new AdminMainForm(u);
                    f.Show();
                    this.Hide();
                }
                else
                {
                    int sid = dt.Rows[0]["StudentID"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["StudentID"]);
                    var f = new StudentMainForm(sid, u);
                    f.Show();
                    this.Hide();
                }
            }
            else
            {
                lblMsg.Text = "Invalid username or password";
            }
        }
    }
}
