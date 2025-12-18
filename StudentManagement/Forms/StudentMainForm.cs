using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace StudentManagement.Forms
{
    public partial class StudentMainForm : Form
    {
        private int _studentId;
        private string _username;
        public StudentMainForm(int studentId, string username)
        {
            _studentId = studentId;
            _username = username;
            InitializeComponent();
            LoadProfileAndAttendance();
        }

        private void LoadProfileAndAttendance()
        {
            using var db = new DataAccess();
            var dtProfile = db.GetTable("SELECT FirstName, LastName, Class, RollNo FROM Students WHERE StudentID = ?", new OleDbParameter("@p1", _studentId));
            if (dtProfile.Rows.Count == 1)
            {
                var r = dtProfile.Rows[0];
                lblName.Text = $"{r["FirstName"]} {r["LastName"]} - Class: {r["Class"]} - Roll: {r["RollNo"]}";
            }

            var dt = db.GetTable("SELECT Date, Status, MarkedBy FROM Attendance WHERE StudentID = ? ORDER BY Date DESC", new OleDbParameter("@p1", _studentId));
            dgvMyAttendance.DataSource = dt;

            int total = dt.Rows.Count;
            int present = 0;
            foreach (System.Data.DataRow row in dt.Rows) if (row["Status"].ToString() == "Present") present++;
            lblSummary.Text = $"Total: {total}, Present: {present}, Absent: {total - present}";
        }
    }
}
