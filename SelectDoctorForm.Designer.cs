using System.Windows.Forms;

namespace BBMS
{
    partial class SelectDoctorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.doctorsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // doctorsGrid
            // 
            this.doctorsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doctorsGrid.Location = new System.Drawing.Point(0, 50);
            this.doctorsGrid.Name = "doctorsGrid";
            this.doctorsGrid.RowTemplate.Height = 24;
            this.doctorsGrid.Size = new System.Drawing.Size(867, 187);
            this.doctorsGrid.TabIndex = 0;
            this.doctorsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.doctorsGrid_CellContentClick);
            this.doctorsGrid.MouseClick += new MouseEventHandler(this.doctorsGrid_MouseClick);
            // 
            // SelectDoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 237);
            this.Controls.Add(this.doctorsGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectDoctorForm";
            this.Text = "SelectDoctorForm";
            this.Load += new System.EventHandler(this.SelectDoctorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.doctorsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView doctorsGrid;
    }
}