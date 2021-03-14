
namespace CPRG200.TravelExperts.App
{
    partial class frmAddModifySupplier
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
            System.Windows.Forms.Label supNameLabel;
            System.Windows.Forms.Label supplierIdLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddModifySupplier));
            this.SupplierCloseButton = new System.Windows.Forms.Button();
            this.SupplierSaveButton = new System.Windows.Forms.Button();
            this.SupNameTextBox = new System.Windows.Forms.TextBox();
            this.SupplierIdTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            supNameLabel = new System.Windows.Forms.Label();
            supplierIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // supNameLabel
            // 
            supNameLabel.AutoSize = true;
            supNameLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            supNameLabel.Location = new System.Drawing.Point(27, 88);
            supNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            supNameLabel.Name = "supNameLabel";
            supNameLabel.Size = new System.Drawing.Size(66, 21);
            supNameLabel.TabIndex = 12;
            supNameLabel.Text = "Name:";
            // 
            // supplierIdLabel
            // 
            supplierIdLabel.AutoSize = true;
            supplierIdLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            supplierIdLabel.Location = new System.Drawing.Point(27, 44);
            supplierIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            supplierIdLabel.Name = "supplierIdLabel";
            supplierIdLabel.Size = new System.Drawing.Size(102, 21);
            supplierIdLabel.TabIndex = 14;
            supplierIdLabel.Text = "Supplier ID:";
            // 
            // SupplierCloseButton
            // 
            this.SupplierCloseButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.SupplierCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SupplierCloseButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierCloseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SupplierCloseButton.Location = new System.Drawing.Point(358, 151);
            this.SupplierCloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.SupplierCloseButton.Name = "SupplierCloseButton";
            this.SupplierCloseButton.Size = new System.Drawing.Size(81, 40);
            this.SupplierCloseButton.TabIndex = 2;
            this.SupplierCloseButton.Text = "&Close";
            this.SupplierCloseButton.UseVisualStyleBackColor = false;
            this.SupplierCloseButton.Click += new System.EventHandler(this.SupplierCloseButton_Click);
            // 
            // SupplierSaveButton
            // 
            this.SupplierSaveButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.SupplierSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SupplierSaveButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierSaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SupplierSaveButton.Location = new System.Drawing.Point(243, 151);
            this.SupplierSaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SupplierSaveButton.Name = "SupplierSaveButton";
            this.SupplierSaveButton.Size = new System.Drawing.Size(81, 40);
            this.SupplierSaveButton.TabIndex = 1;
            this.SupplierSaveButton.Text = "&Save";
            this.SupplierSaveButton.UseVisualStyleBackColor = false;
            this.SupplierSaveButton.Click += new System.EventHandler(this.SupplierSaveButton_Click);
            // 
            // SupNameTextBox
            // 
            this.SupNameTextBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupNameTextBox.Location = new System.Drawing.Point(147, 85);
            this.SupNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SupNameTextBox.Name = "SupNameTextBox";
            this.SupNameTextBox.Size = new System.Drawing.Size(304, 28);
            this.SupNameTextBox.TabIndex = 0;
            this.SupNameTextBox.Tag = "Supplier Name";
            // 
            // SupplierIdTextBox
            // 
            this.SupplierIdTextBox.Enabled = false;
            this.SupplierIdTextBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierIdTextBox.Location = new System.Drawing.Point(147, 41);
            this.SupplierIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SupplierIdTextBox.Name = "SupplierIdTextBox";
            this.SupplierIdTextBox.Size = new System.Drawing.Size(105, 28);
            this.SupplierIdTextBox.TabIndex = 15;
            this.SupplierIdTextBox.Tag = "Supplier ID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(393, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 80;
            this.pictureBox1.TabStop = false;
            // 
            // frmAddModifySupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(479, 228);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SupplierCloseButton);
            this.Controls.Add(this.SupplierSaveButton);
            this.Controls.Add(supNameLabel);
            this.Controls.Add(this.SupNameTextBox);
            this.Controls.Add(supplierIdLabel);
            this.Controls.Add(this.SupplierIdTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddModifySupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddModifySupplier";
            this.Load += new System.EventHandler(this.frmAddModifySupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SupplierCloseButton;
        private System.Windows.Forms.Button SupplierSaveButton;
        private System.Windows.Forms.TextBox SupNameTextBox;
        private System.Windows.Forms.TextBox SupplierIdTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}