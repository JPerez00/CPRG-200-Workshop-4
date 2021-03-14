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
    public partial class frmAddModifyProducts : Form
    {
        public bool addProduct; // true if Add, and false if Modify -Katrina
        public Product currentProd; // frmMain sets current product -Katrina
        public Product product = new Product();

        public List<int> prodIds;

        public frmAddModifyProducts()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Katrina: On-load, Add or Modify
        /// </summary>
        private void frmAddModifyProducts_Load(object sender, EventArgs e)
        {
            if (addProduct) // if this is Add
            {
                this.Text = "Add Product";
                //auto generate supplierId by getting last supplierId and adding 1
                DisplayCurrentProduct();
            }
            else // Modify
            {
                this.Text = "Modify Product";
                DisplayCurrentProduct();
            }
        }
        /// <summary>
        /// Katrina: Display current product based on add or modify
        /// </summary>
        private void DisplayCurrentProduct()
        {
            if (addProduct == false) //if modify
            {
                productIdTextBox.Text = currentProd.ProductId.ToString();
                prodNameTextBox.Text = currentProd.ProdName;
            }
            else // if add
            {
                productIdTextBox.Text = (prodIds[prodIds.Count - 1] + 1).ToString();
            }
        }

        private void ProdSaveButton_Click(object sender, EventArgs e)
        {
            // check if valid before accepting changes -Katrina
            if (Validator.IsPresent(prodNameTextBox))
            {
                if (addProduct) // if Add
                {
                    this.PutProductData();
                    try
                    {
                        product.ProductId = ProductDB.AddProduct(product);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else // if Modify
                {
                    product.ProductId = currentProd.ProductId;
                    this.PutProductData();

                    try // try to update
                    {
                        if (!ProductDB.UpdateProduct(currentProd, product)) // failed
                        {
                            MessageBox.Show("Another user has updated or deleted current product", "Concurrency Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            currentProd = product;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while updating: " + ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }
        /// <summary>
        /// Katrina: Puts new product data into product object
        /// </summary>
        private void PutProductData()
        {
            product.ProductId = Convert.ToInt32(productIdTextBox.Text);
            product.ProdName = prodNameTextBox.Text;
        }
        /// <summary>
        /// Katrina: Closes add/modify product form
        /// </summary>
        private void ProdCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
