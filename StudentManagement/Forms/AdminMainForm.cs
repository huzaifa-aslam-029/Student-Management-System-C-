using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace StudentManagement.Forms
{
    public partial class AdminMainForm : Form
    {
        private string _adminUser;
        public AdminMainForm(string adminUser)
        {
            _adminUser = adminUser;
            InitializeComponent();
            LoadStudents();
            LoadClasses();
        }

        private void LoadStudents()
        {
            using var db = new DataAccess();
            dgvStudents.DataSource = db.GetTable("SELECT StudentID, FirstName, LastName, Class, RollNo FROM Students");
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            var f = new AddEditStudentForm();
            if (f.ShowDialog() == DialogResult.OK) LoadStudents();
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvStudents.CurrentRow.Cells["StudentID"].Value);
            var f = new AddEditStudentForm(id);
            if (f.ShowDialog() == DialogResult.OK) LoadStudents();
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvStudents.CurrentRow.Cells["StudentID"].Value);
            if (MessageBox.Show("Delete student?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using var db = new DataAccess();
                db.Execute("DELETE FROM Students WHERE StudentID=?", new OleDbParameter("@p1", id));
                db.Execute("DELETE FROM Users WHERE StudentID=?", new OleDbParameter("@p1", id));
                db.Execute("DELETE FROM Attendance WHERE StudentID=?", new OleDbParameter("@p1", id));
                LoadStudents();
            }
        }

        private void btnLoadAttendance_Click(object? sender, EventArgs e)
        {
            string cls = cbClass.Text;
            using var db = new DataAccess();
            DataTable dt;
            if (string.IsNullOrEmpty(cls) || cls == "All")
                dt = db.GetTable("SELECT StudentID, FirstName & ' ' & LastName AS FullName FROM Students ORDER BY RollNo");
            else
                dt = db.GetTable("SELECT StudentID, FirstName & ' ' & LastName AS FullName FROM Students WHERE Class = ? ORDER BY RollNo", new OleDbParameter("@p1", cls));
            dt.Columns.Add("Present", typeof(bool));
            foreach (DataRow r in dt.Rows) r["Present"] = false;
            dgvAttendance.DataSource = dt;
        }

        private void btnSaveAttendance_Click(object? sender, EventArgs e)
        {
            DateTime date = dtpDate.Value.Date;
            using var db = new DataAccess();
            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
                bool present = Convert.ToBoolean(row.Cells["Present"].Value);
                string status = present ? "Present" : "Absent";
                object exists = db.ExecuteScalar("SELECT COUNT(*) FROM Attendance WHERE StudentID = ? AND [Date] = ?", new OleDbParameter("@p1", studentId), new OleDbParameter("@p2", date));
                int cnt = Convert.ToInt32(exists);
                if (cnt > 0)
                {
                    db.Execute("UPDATE Attendance SET Status = ?, MarkedBy = ? WHERE StudentID = ? AND [Date] = ?",
                        new OleDbParameter("@p1", status),
                        new OleDbParameter("@p2", _adminUser),
                        new OleDbParameter("@p3", studentId),
                        new OleDbParameter("@p4", date));
                }
                else
                {
                    db.Execute("INSERT INTO Attendance (StudentID, [Date], Status, MarkedBy) VALUES (?, ?, ?, ?)",
                        new OleDbParameter("@p1", studentId),
                        new OleDbParameter("@p2", date),
                        new OleDbParameter("@p3", status),
                        new OleDbParameter("@p4", _adminUser));
                }
            }
            MessageBox.Show("Attendance saved.");
        }

        private void LoadClasses()
        {
            using var db = new DataAccess();
            var dt = db.GetTable("SELECT DISTINCT Class FROM Students");
            cbClass.Items.Clear();
            cbClass.Items.Add("All");
            foreach (DataRow r in dt.Rows) cbClass.Items.Add(r["Class"].ToString());
            cbClass.SelectedIndex = 0;
        }
    }
}
