
namespace CPRG200.TravelExperts.App
{
    partial class frmAddNewPkgProdSup
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
            System.Windows.Forms.Label packageIdLabel;
            System.Windows.Forms.Label productSupplierIdLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewPkgProdSup));
            this.productSupplierDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageProductSupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SavePkgProdSup = new System.Windows.Forms.Button();
            this.btnClosePkgProdSup = new System.Windows.Forms.Button();
            this.packageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.packageIdTextBox = new System.Windows.Forms.TextBox();
            this.productSupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productSupplierIdComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            packageIdLabel = new System.Windows.Forms.Label();
            productSupplierIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageProductSupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // packageIdLabel
            // 
            packageIdLabel.AutoSize = true;
            packageIdLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            packageIdLabel.Location = new System.Drawing.Point(27, 31);
            packageIdLabel.Name = "packageIdLabel";
            packageIdLabel.Size = new System.Drawing.Size(114, 21);
            packageIdLabel.TabIndex = 3;
            packageIdLabel.Text = "Package ID:";
            // 
            // productSupplierIdLabel
            // 
            productSupplierIdLabel.AutoSize = true;
            productSupplierIdLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            productSupplierIdLabel.Location = new System.Drawing.Point(332, 31);
            productSupplierIdLabel.Name = "productSupplierIdLabel";
            productSupplierIdLabel.Size = new System.Drawing.Size(173, 21);
            productSupplierIdLabel.TabIndex = 5;
            productSupplierIdLabel.Text = "Product Supplier ID:";
            // 
            // productSupplierDataGridView
            // 
            this.productSupplierDataGridView.AutoGenerateColumns = false;
            this.productSupplierDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productSupplierDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7});
            this.productSupplierDataGridView.DataSource = this.packageProductSupplierBindingSource;
            this.productSupplierDataGridView.Location = new System.Drawing.Point(31, 84);
            this.productSupplierDataGridView.Name = "productSupplierDataGridView";
            this.productSupplierDataGridView.RowHeadersWidth = 51;
            this.productSupplierDataGridView.RowTemplate.Height = 24;
            this.productSupplierDataGridView.Size = new System.Drawing.Size(840, 348);
            this.productSupplierDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProductSupplierId";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Supplier Id";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ProductId";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "Product Id";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ProdName";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn6.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SupplierId";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn5.HeaderText = "Supplier Id";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SupName";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn7.HeaderText = "Supplier Name";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 220;
            // 
            // packageProductSupplierBindingSource
            // 
            this.packageProductSupplierBindingSource.DataSource = typeof(CPRG200.TravelExperts.Data.PackageProductSupplier);
            // 
            // SavePkgProdSup
            // 
            this.SavePkgProdSup.BackColor = System.Drawing.Color.DodgerBlue;
            this.SavePkgProdSup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SavePkgProdSup.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavePkgProdSup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SavePkgProdSup.Location = new System.Drawing.Point(674, 455);
            this.SavePkgProdSup.Name = "SavePkgProdSup";
            this.SavePkgProdSup.Size = new System.Drawing.Size(81, 40);
            this.SavePkgProdSup.TabIndex = 1;
            this.SavePkgProdSup.Text = "&Save";
            this.SavePkgProdSup.UseVisualStyleBackColor = false;
            this.SavePkgProdSup.Click += new System.EventHandler(this.SavePkgProdSup_Click);
            // 
            // btnClosePkgProdSup
            // 
            this.btnClosePkgProdSup.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClosePkgProdSup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClosePkgProdSup.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosePkgProdSup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClosePkgProdSup.Location = new System.Drawing.Point(801, 455);
            this.btnClosePkgProdSup.Name = "btnClosePkgProdSup";
            this.btnClosePkgProdSup.Size = new System.Drawing.Size(81, 40);
            this.btnClosePkgProdSup.TabIndex = 2;
            this.btnClosePkgProdSup.Text = "&Close";
            this.btnClosePkgProdSup.UseVisualStyleBackColor = false;
            this.btnClosePkgProdSup.Click += new System.EventHandler(this.btnClosePkgProdSup_Click);
            // 
            // packageBindingSource
            // 
            this.packageBindingSource.DataSource = typeof(CPRG200.TravelExperts.Data.Package);
            // 
            // packageIdTextBox
            // 
            this.packageIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PackageId", true));
            this.packageIdTextBox.Enabled = false;
            this.packageIdTextBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packageIdTextBox.Location = new System.Drawing.Point(156, 28);
            this.packageIdTextBox.Name = "packageIdTextBox";
            this.packageIdTextBox.Size = new System.Drawing.Size(100, 28);
            this.packageIdTextBox.TabIndex = 4;
            this.packageIdTextBox.Tag = "Package ID";
            // 
            // productSupplierBindingSource
            // 
            this.productSupplierBindingSource.DataSource = typeof(CPRG200.TravelExperts.Data.ProductSupplier);
            // 
            // productSupplierIdComboBox
            // 
            this.productSupplierIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productSupplierBindingSource, "ProductSupplierId", true));
            this.productSupplierIdComboBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productSupplierIdComboBox.FormattingEnabled = true;
            this.productSupplierIdComboBox.Location = new System.Drawing.Point(527, 28);
            this.productSupplierIdComboBox.Name = "productSupplierIdComboBox";
            this.productSupplierIdComboBox.Size = new System.Drawing.Size(100, 29);
            this.productSupplierIdComboBox.TabIndex = 0;
            this.productSupplierIdComboBox.Tag = "Product Supplier ID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(818, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 81;
            this.pictureBox1.TabStop = false;
            // 
            // frmAddNewPkgProdSup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(908, 511);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(productSupplierIdLabel);
            this.Controls.Add(this.productSupplierIdComboBox);
            this.Controls.Add(packageIdLabel);
            this.Controls.Add(this.packageIdTextBox);
            this.Controls.Add(this.btnClosePkgProdSup);
            this.Controls.Add(this.SavePkgProdSup);
            this.Controls.Add(this.productSupplierDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddNewPkgProdSup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddNewPkgProdSup";
            this.Load += new System.EventHandler(this.frmAddNewPkgProdSup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageProductSupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource packageProductSupplierBindingSource;
        private System.Windows.Forms.DataGridView productSupplierDataGridView;
        private System.Windows.Forms.Button SavePkgProdSup;
        private System.Windows.Forms.Button btnClosePkgProdSup;
        private System.Windows.Forms.BindingSource packageBindingSource;
        private System.Windows.Forms.TextBox packageIdTextBox;
        private System.Windows.Forms.BindingSource productSupplierBindingSource;
        private System.Windows.Forms.ComboBox productSupplierIdComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}