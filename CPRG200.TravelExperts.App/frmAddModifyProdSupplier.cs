using CPRG200.TravelExperts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPRG200.TravelExperts.App
{
    public partial class frmAddModifyProdSupplier : Form
    {
        public bool addProductSupplier; // true if Add, and false if Modify
        public ProductSupplier currentProdSup; // frmMain sets current package
        public ProductSupplier productSupplier = new ProductSupplier();

        public List<int> prodSupId;
        List<Product> prodId;
        List<Supplier> supId;

        public frmAddModifyProdSupplier()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Jorge: On load, Add or Modify form
        /// </summary>
        private void frmAddModifyProdSupplier_Load(object sender, EventArgs e)
        {
            //prodId = ProductSupplierDB.GetProductIdsForProdSup();
            prodId = ProductDB.GetAllProducts();
            productIdComboBox.DataSource = prodId;
            productIdComboBox.DisplayMember = "ProdName";
            productIdComboBox.ValueMember = "ProductId";

            //supId = ProductSupplierDB.GetSupplierIdsForProdSup();
            supId = SupplierDB.GetAllSuppliers();
            supplierIdComboBox.DataSource = supId;
            supplierIdComboBox.DisplayMember = "SupName";
            supplierIdComboBox.ValueMember = "SupplierId";

            if (addProductSupplier) // if this is Add
            {
                this.Text = "Add Product Supplier";
                DisplayCurrentProdSupplier();
            }
            else // modify
            {
                this.Text = "Modify Product Supplier";
                DisplayCurrentProdSupplier();
            }
        }
        /// <summary>
        /// Jorge: Display current product supplier based on add or modify
        /// </summary>
        private void DisplayCurrentProdSupplier()
        {
            if (addProductSupplier == false) //if modify
            {
                Console.WriteLine(currentProdSup.ProductId);
                prodSupplierIdTextBox.Text = currentProdSup.ProductSupplierId.ToString();
                // product id can be null
                if (currentProdSup.ProductId == null)
                    productIdComboBox.Text = "";
                else
                // product id can be null
                if (currentProdSup.ProductId == null)
                    productIdComboBox.Text = "";
                else
                    productIdComboBox.Text = currentProdSup.ProdName.ToString();
                // supplier id can be null
                if (currentProdSup.SupplierId == null)
                    supplierIdComboBox.Text = "";
                else
                    supplierIdComboBox.Text = currentProdSup.SupName.ToString();
            }
            else // if add
            {
                prodSupplierIdTextBox.Text = (prodSupId[prodSupId.Count - 1] + 1).ToString();
            }
        }
        /// <summary>
        /// Jorge: Save new prod sup data based on add or modify
        /// </summary>
        private void ProdSupplierSaveButton_Click(object sender, EventArgs e)
        {
            if (addProductSupplier)
            {
                this.PutProdSupplierData();
                try
                {
                    productSupplier.ProductSupplierId = ProductSupplierDB.AddProductSupplier(productSupplier);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
            else // this is Modify
            {
                productSupplier.ProductId = currentProdSup.ProductId;
                productSupplier.SupplierId = currentProdSup.SupplierId;
                productSupplier.ProductSupplierId = currentProdSup.ProductSupplierId;
                this.PutProdSupplierData();

                try // try to update
                {
                    if (!ProductSupplierDB.UpdateProductSupplier(currentProdSup, productSupplier)) // failed
                    {
                        MessageBox.Show("Another user has updated or deleted current product supplier", "Concurrency Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        currentProdSup = ProductSupplierDB.GetProductSupplier(productSupplier.ProductSupplierId);
                        Console.WriteLine(currentProdSup.ProdName);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while updating: " + ex.Message, ex.GetType().ToString());
                }
            }
        }
        /// <summary>
        /// Jorge: Puts product supplier data into product supplier object
        /// </summary>
        private void PutProdSupplierData()
        {
            if (productIdComboBox.Text == "")
                productSupplier.ProductId = null;
            else
                productSupplier.ProductId = Convert.ToInt32(productIdComboBox.SelectedValue);

            if (supplierIdComboBox.Text == "")
                productSupplier.SupplierId = null;
            else
                productSupplier.SupplierId = Convert.ToInt32(supplierIdComboBox.SelectedValue);
        }
        /// <summary>
        /// Katrina: Closes add/modify prod sup form
        /// </summary>
        private void ProdSupplierCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
