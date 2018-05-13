using System.ComponentModel;
using System.Windows.Forms;

namespace BBMS
{
    partial class RequestsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestsForm));
            this.requestsGrid = new System.Windows.Forms.DataGridView();
            this.badBloodGrid = new System.Windows.Forms.DataGridView();
            this.reqButton = new System.Windows.Forms.Button();
            this.thrButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.requestsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.badBloodGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // requestsGrid
            // 
            this.requestsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requestsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsGrid.Location = new System.Drawing.Point(17, 16);
            this.requestsGrid.Margin = new System.Windows.Forms.Padding(4);
            this.requestsGrid.Name = "requestsGrid";
            this.requestsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.requestsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.requestsGrid.Size = new System.Drawing.Size(1207, 305);
            this.requestsGrid.TabIndex = 1;
            this.requestsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.requestsGrid_CellContentClick);
            // 
            // badBloodGrid
            // 
            this.badBloodGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.badBloodGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.badBloodGrid.Location = new System.Drawing.Point(17, 365);
            this.badBloodGrid.Margin = new System.Windows.Forms.Padding(4);
            this.badBloodGrid.Name = "badBloodGrid";
            this.badBloodGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.badBloodGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.badBloodGrid.Size = new System.Drawing.Size(1207, 317);
            this.badBloodGrid.TabIndex = 2;
            // 
            // reqButton
            // 
            this.reqButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reqButton.Location = new System.Drawing.Point(17, 329);
            this.reqButton.Margin = new System.Windows.Forms.Padding(4);
            this.reqButton.Name = "reqButton";
            this.reqButton.Size = new System.Drawing.Size(1207, 28);
            this.reqButton.TabIndex = 3;
            this.reqButton.Text = "Respond to a request";
            this.reqButton.UseVisualStyleBackColor = true;
            this.reqButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // thrButton
            // 
            this.thrButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thrButton.Location = new System.Drawing.Point(17, 690);
            this.thrButton.Margin = new System.Windows.Forms.Padding(4);
            this.thrButton.Name = "thrButton";
            this.thrButton.Size = new System.Drawing.Size(1207, 28);
            this.thrButton.TabIndex = 4;
            this.thrButton.Text = "Throw Bag";
            this.thrButton.UseVisualStyleBackColor = true;
            this.thrButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(392, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Waiting For Blood Requests ...";
            // 
            // RequestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1240, 764);
            this.Controls.Add(this.thrButton);
            this.Controls.Add(this.reqButton);
            this.Controls.Add(this.badBloodGrid);
            this.Controls.Add(this.requestsGrid);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RequestsForm";
            this.Text = "Request Control";
            this.Load += new System.EventHandler(this.RequestsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.requestsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.badBloodGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView requestsGrid;
        private DataGridView badBloodGrid;
        private Button reqButton;
        private Button thrButton;
        private Label label1;
    }
}