using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace StudentManagement.Forms
{
    public partial class AddEditStudentForm : Form
    {
        private int? _studentId;
        public AddEditStudentForm(int? studentId = null)
        {
            _studentId = studentId;
            InitializeComponent();
            if (_studentId.HasValue) LoadStudent(_studentId.Value);
        }

        private void LoadStudent(int id)
        {
            using var db = new DataAccess();
            var dt = db.GetTable("SELECT * FROM Students WHERE StudentID=?", new OleDbParameter("@p1", id));
            if (dt.Rows.Count == 1)
            {
                var r = dt.Rows[0];
                txtFirst.Text = r["FirstName"].ToString();
                txtLast.Text = r["LastName"].ToString();
                txtClass.Text = r["Class"].ToString();
                txtRoll.Text = r["RollNo"].ToString();
                dtpDOB.Value = r["DOB"] == DBNull.Value ? DateTime.Today : Convert.ToDateTime(r["DOB"]);
                txtContact.Text = r["Contact"].ToString();
                txtEmail.Text = r["Email"].ToString();
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            using var db = new DataAccess();
            if (_studentId.HasValue)
            {
                db.Execute("UPDATE Students SET FirstName=?, LastName=?, Class=?, RollNo=?, DOB=?, Contact=?, Email=? WHERE StudentID=?",
                    new OleDbParameter("@p1", txtFirst.Text.Trim()),
                    new OleDbParameter("@p2", txtLast.Text.Trim()),
                    new OleDbParameter("@p3", txtClass.Text.Trim()),
                    new OleDbParameter("@p4", txtRoll.Text.Trim()),
                    new OleDbParameter("@p5", dtpDOB.Value.Date),
                    new OleDbParameter("@p6", txtContact.Text.Trim()),
                    new OleDbParameter("@p7", txtEmail.Text.Trim()),
                    new OleDbParameter("@p8", _studentId.Value));
            }
            else
            {
                db.Execute("INSERT INTO Students (FirstName, LastName, [Class], RollNo, DOB, Contact, Email) VALUES (?, ?, ?, ?, ?, ?, ?)",
                    new OleDbParameter("@p1", txtFirst.Text.Trim()),
                    new OleDbParameter("@p2", txtLast.Text.Trim()),
                    new OleDbParameter("@p3", txtClass.Text.Trim()),
                    new OleDbParameter("@p4", txtRoll.Text.Trim()),
                    new OleDbParameter("@p5", dtpDOB.Value.Date),
                    new OleDbParameter("@p6", txtContact.Text.Trim()),
                    new OleDbParameter("@p7", txtEmail.Text.Trim()));
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
