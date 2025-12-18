namespace StudentManagement.Forms
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.btnLoadAttendance = new System.Windows.Forms.Button();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSaveAttendance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.Location = new System.Drawing.Point(12,12);
            this.dgvStudents.Size = new System.Drawing.Size(560,200);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(580,12);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(580,52);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(580,92);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbClass
            // 
            this.cbClass.Location = new System.Drawing.Point(12,220);
            this.cbClass.Size = new System.Drawing.Size(200,23);
            // 
            // btnLoadAttendance
            // 
            this.btnLoadAttendance.Location = new System.Drawing.Point(220,220);
            this.btnLoadAttendance.Text = "Load";
            this.btnLoadAttendance.Click += new System.EventHandler(this.btnLoadAttendance_Click);
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.Location = new System.Drawing.Point(12,260);
            this.dgvAttendance.Size = new System.Drawing.Size(560,200);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(580,220);
            // 
            // btnSaveAttendance
            // 
            this.btnSaveAttendance.Location = new System.Drawing.Point(580,260);
            this.btnSaveAttendance.Text = "Save Attendance";
            this.btnSaveAttendance.Click += new System.EventHandler(this.btnSaveAttendance_Click);
            // 
            // AdminMainForm
            // 
            this.ClientSize = new System.Drawing.Size(760,480);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.btnLoadAttendance);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnSaveAttendance);
            this.Text = "Admin - Student Management";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Button btnLoadAttendance;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSaveAttendance;
    }
}
