namespace StudentManagement.Forms
{
    partial class AddEditStudentForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtRoll = new System.Windows.Forms.TextBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // controls basic placement
            this.txtFirst.Location = new System.Drawing.Point(12,12); this.txtFirst.Size = new System.Drawing.Size(260,23);
            this.txtLast.Location = new System.Drawing.Point(12,42); this.txtLast.Size = new System.Drawing.Size(260,23);
            this.txtClass.Location = new System.Drawing.Point(12,72); this.txtClass.Size = new System.Drawing.Size(260,23);
            this.txtRoll.Location = new System.Drawing.Point(12,102); this.txtRoll.Size = new System.Drawing.Size(260,23);
            this.dtpDOB.Location = new System.Drawing.Point(12,132); this.dtpDOB.Size = new System.Drawing.Size(260,23);
            this.txtContact.Location = new System.Drawing.Point(12,162); this.txtContact.Size = new System.Drawing.Size(260,23);
            this.txtEmail.Location = new System.Drawing.Point(12,192); this.txtEmail.Size = new System.Drawing.Size(260,23);
            this.btnSave.Location = new System.Drawing.Point(12,222); this.btnSave.Size = new System.Drawing.Size(260,28);
            this.btnSave.Text = "Save"; this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.ClientSize = new System.Drawing.Size(300,270);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.txtLast);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.txtRoll);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnSave);
            this.Text = "Add / Edit Student";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtRoll;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSave;
    }
}
