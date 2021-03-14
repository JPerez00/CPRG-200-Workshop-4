
namespace CPRG200.TravelExperts.App
{
    partial class frmAddModifyProducts
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label prodNameLabel;
            System.Windows.Forms.Label productIdLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddModifyProducts));
            this.ProdCloseButton = new System.Windows.Forms.Button();
            this.ProdSaveButton = new System.Windows.Forms.Button();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prodNameTextBox = new System.Windows.Forms.TextBox();
            this.productIdTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            prodNameLabel = new System.Windows.Forms.Label();
            productIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // prodNameLabel
            // 
            prodNameLabel.AutoSize = true;
            prodNameLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            prodNameLabel.Location = new System.Drawing.Point(27, 88);
            prodNameLabel.Name = "prodNameLabel";
            prodNameLabel.Size = new System.Drawing.Size(66, 21);
            prodNameLabel.TabIndex = 81;
            prodNameLabel.Text = "Name:";
            // 
            // productIdLabel
            // 
            productIdLabel.AutoSize = true;
            productIdLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            productIdLabel.Location = new System.Drawing.Point(27, 44);
            productIdLabel.Name = "productIdLabel";
            productIdLabel.Size = new System.Drawing.Size(104, 21);
            productIdLabel.TabIndex = 82;
            productIdLabel.Text = "Product ID:";
            // 
            // ProdCloseButton
            // 
            this.ProdCloseButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.ProdCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProdCloseButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdCloseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ProdCloseButton.Location = new System.Drawing.Point(290, 146);
            this.ProdCloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.ProdCloseButton.Name = "ProdCloseButton";
            this.ProdCloseButton.Size = new System.Drawing.Size(81, 40);
            this.ProdCloseButton.TabIndex = 2;
            this.ProdCloseButton.Text = "&Close";
            this.ProdCloseButton.UseVisualStyleBackColor = false;
            this.ProdCloseButton.Click += new System.EventHandler(this.ProdCloseButton_Click);
            // 
            // ProdSaveButton
            // 
            this.ProdSaveButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.ProdSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProdSaveButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdSaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ProdSaveButton.Location = new System.Drawing.Point(174, 146);
            this.ProdSaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.ProdSaveButton.Name = "ProdSaveButton";
            this.ProdSaveButton.Size = new System.Drawing.Size(81, 40);
            this.ProdSaveButton.TabIndex = 1;
            this.ProdSaveButton.Text = "&Save";
            this.ProdSaveButton.UseVisualStyleBackColor = false;
            this.ProdSaveButton.Click += new System.EventHandler(this.ProdSaveButton_Click);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(CPRG200.TravelExperts.Data.Product);
            // 
            // prodNameTextBox
            // 
            this.prodNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ProdName", true));
            this.prodNameTextBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodNameTextBox.Location = new System.Drawing.Point(140, 85);
            this.prodNameTextBox.Name = "prodNameTextBox";
            this.prodNameTextBox.Size = new System.Drawing.Size(236, 28);
            this.prodNameTextBox.TabIndex = 0;
            this.prodNameTextBox.Tag = "Product Name";
            // 
            // productIdTextBox
            // 
            this.productIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ProductId", true));
            this.productIdTextBox.Enabled = false;
            this.productIdTextBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productIdTextBox.Location = new System.Drawing.Point(140, 41);
            this.productIdTextBox.Name = "productIdTextBox";
            this.productIdTextBox.Size = new System.Drawing.Size(100, 28);
            this.productIdTextBox.TabIndex = 83;
            this.productIdTextBox.Tag = "Product ID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(328, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 84;
            this.pictureBox1.TabStop = false;
            // 
            // frmAddModifyProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(414, 228);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(productIdLabel);
            this.Controls.Add(this.productIdTextBox);
            this.Controls.Add(prodNameLabel);
            this.Controls.Add(this.prodNameTextBox);
            this.Controls.Add(this.ProdCloseButton);
            this.Controls.Add(this.ProdSaveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddModifyProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddModifyProducts";
            this.Load += new System.EventHandler(this.frmAddModifyProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ProdCloseButton;
        private System.Windows.Forms.Button ProdSaveButton;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.TextBox prodNameTextBox;
        private System.Windows.Forms.TextBox productIdTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}