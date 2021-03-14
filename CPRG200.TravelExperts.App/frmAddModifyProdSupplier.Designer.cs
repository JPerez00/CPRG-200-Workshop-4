
namespace CPRG200.TravelExperts.App
{
    partial class frmAddModifyProdSupplier
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
            System.Windows.Forms.Label productSupplierIdLabel;
            System.Windows.Forms.Label supplierIdLabel;
            System.Windows.Forms.Label productIdLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddModifyProdSupplier));
            this.prodSupplierIdTextBox = new System.Windows.Forms.TextBox();
            this.ProdSupplierCloseButton = new System.Windows.Forms.Button();
            this.ProdSupplierSaveButton = new System.Windows.Forms.Button();
            this.supplierIdComboBox = new System.Windows.Forms.ComboBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productIdComboBox = new System.Windows.Forms.ComboBox();
            this.productSupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            productSupplierIdLabel = new System.Windows.Forms.Label();
            supplierIdLabel = new System.Windows.Forms.Label();
            productIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // productSupplierIdLabel
            // 
            productSupplierIdLabel.AutoSize = true;
            productSupplierIdLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            productSupplierIdLabel.Location = new System.Drawing.Point(27, 44);
            productSupplierIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            productSupplierIdLabel.Name = "productSupplierIdLabel";
            productSupplierIdLabel.Size = new System.Drawing.Size(173, 21);
            productSupplierIdLabel.TabIndex = 43;
            productSupplierIdLabel.Text = "Product Supplier ID:";
            // 
            // supplierIdLabel
            // 
            supplierIdLabel.AutoSize = true;
            supplierIdLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            supplierIdLabel.Location = new System.Drawing.Point(27, 136);
            supplierIdLabel.Name = "supplierIdLabel";
            supplierIdLabel.Size = new System.Drawing.Size(79, 21);
            supplierIdLabel.TabIndex = 77;
            supplierIdLabel.Text = "Supplier:";
            // 
            // productIdLabel
            // 
            productIdLabel.AutoSize = true;
            productIdLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            productIdLabel.Location = new System.Drawing.Point(27, 87);
            productIdLabel.Name = "productIdLabel";
            productIdLabel.Size = new System.Drawing.Size(81, 21);
            productIdLabel.TabIndex = 78;
            productIdLabel.Text = "Product:";
            // 
            // prodSupplierIdTextBox
            // 
            this.prodSupplierIdTextBox.Enabled = false;
            this.prodSupplierIdTextBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodSupplierIdTextBox.Location = new System.Drawing.Point(212, 41);
            this.prodSupplierIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.prodSupplierIdTextBox.Name = "prodSupplierIdTextBox";
            this.prodSupplierIdTextBox.ReadOnly = true;
            this.prodSupplierIdTextBox.Size = new System.Drawing.Size(100, 28);
            this.prodSupplierIdTextBox.TabIndex = 49;
            this.prodSupplierIdTextBox.Tag = "Product Supplier ID";
            // 
            // ProdSupplierCloseButton
            // 
            this.ProdSupplierCloseButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.ProdSupplierCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProdSupplierCloseButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdSupplierCloseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ProdSupplierCloseButton.Location = new System.Drawing.Point(458, 190);
            this.ProdSupplierCloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.ProdSupplierCloseButton.Name = "ProdSupplierCloseButton";
            this.ProdSupplierCloseButton.Size = new System.Drawing.Size(81, 40);
            this.ProdSupplierCloseButton.TabIndex = 3;
            this.ProdSupplierCloseButton.Text = "&Close";
            this.ProdSupplierCloseButton.UseVisualStyleBackColor = false;
            this.ProdSupplierCloseButton.Click += new System.EventHandler(this.ProdSupplierCloseButton_Click);
            // 
            // ProdSupplierSaveButton
            // 
            this.ProdSupplierSaveButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.ProdSupplierSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProdSupplierSaveButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdSupplierSaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ProdSupplierSaveButton.Location = new System.Drawing.Point(345, 190);
            this.ProdSupplierSaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.ProdSupplierSaveButton.Name = "ProdSupplierSaveButton";
            this.ProdSupplierSaveButton.Size = new System.Drawing.Size(81, 40);
            this.ProdSupplierSaveButton.TabIndex = 2;
            this.ProdSupplierSaveButton.Text = "&Save";
            this.ProdSupplierSaveButton.UseVisualStyleBackColor = false;
            this.ProdSupplierSaveButton.Click += new System.EventHandler(this.ProdSupplierSaveButton_Click);
            // 
            // supplierIdComboBox
            // 
            this.supplierIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "SupplierId", true));
            this.supplierIdComboBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierIdComboBox.FormattingEnabled = true;
            this.supplierIdComboBox.Location = new System.Drawing.Point(212, 133);
            this.supplierIdComboBox.Name = "supplierIdComboBox";
            this.supplierIdComboBox.Size = new System.Drawing.Size(338, 29);
            this.supplierIdComboBox.TabIndex = 1;
            this.supplierIdComboBox.Tag = "Supplier ID";
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(CPRG200.TravelExperts.Data.Supplier);
            // 
            // productIdComboBox
            // 
            this.productIdComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.productIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productSupplierBindingSource, "ProductId", true));
            this.productIdComboBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productIdComboBox.FormattingEnabled = true;
            this.productIdComboBox.Location = new System.Drawing.Point(212, 84);
            this.productIdComboBox.Name = "productIdComboBox";
            this.productIdComboBox.Size = new System.Drawing.Size(200, 29);
            this.productIdComboBox.TabIndex = 0;
            this.productIdComboBox.Tag = "Product ID";
            // 
            // productSupplierBindingSource
            // 
            this.productSupplierBindingSource.DataSource = typeof(CPRG200.TravelExperts.Data.ProductSupplier);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(CPRG200.TravelExperts.Data.Product);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(486, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // frmAddModifyProdSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(575, 256);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(productIdLabel);
            this.Controls.Add(this.productIdComboBox);
            this.Controls.Add(supplierIdLabel);
            this.Controls.Add(this.supplierIdComboBox);
            this.Controls.Add(this.ProdSupplierCloseButton);
            this.Controls.Add(this.ProdSupplierSaveButton);
            this.Controls.Add(this.prodSupplierIdTextBox);
            this.Controls.Add(productSupplierIdLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddModifyProdSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddModifyProdSupplier";
            this.Load += new System.EventHandler(this.frmAddModifyProdSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox prodSupplierIdTextBox;
        private System.Windows.Forms.Button ProdSupplierCloseButton;
        private System.Windows.Forms.Button ProdSupplierSaveButton;
        private System.Windows.Forms.BindingSource productSupplierBindingSource;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.ComboBox supplierIdComboBox;
        private System.Windows.Forms.ComboBox productIdComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}