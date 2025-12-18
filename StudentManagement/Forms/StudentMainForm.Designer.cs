namespace StudentManagement.Forms
{
    partial class StudentMainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.dgvMyAttendance = new System.Windows.Forms.DataGridView();
            this.lblSummary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.lblName.Location = new System.Drawing.Point(12,12); this.lblName.Size = new System.Drawing.Size(600,23);
            this.dgvMyAttendance.Location = new System.Drawing.Point(12,48); this.dgvMyAttendance.Size = new System.Drawing.Size(760,360);
            this.lblSummary.Location = new System.Drawing.Point(12,420); this.lblSummary.Size = new System.Drawing.Size(400,23);
            this.ClientSize = new System.Drawing.Size(800,460);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dgvMyAttendance);
            this.Controls.Add(this.lblSummary);
            this.Text = "Student - Attendance";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dgvMyAttendance;
        private System.Windows.Forms.Label lblSummary;
    }
}
