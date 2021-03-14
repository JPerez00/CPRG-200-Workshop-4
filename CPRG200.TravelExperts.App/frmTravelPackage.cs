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


/* CPRG 200 Workshop 2 - Group 5
 * Build an application that uses the travel experts database.
 * The agents need to add/edit travel packages.  This function must allow the user to enter data for the package, and select from a product list to add products to the package.
 
The application will also require simple add/edit access for maintaining the product, suppliers, and product_suppliers data.

The tables that will be used by this part of the project are:
1.	Packages
2.	Products
3.	Products_suppliers
4.	Suppliers
5.	Packages_products_suppliers

Make sure that you validate the data before creating the package.
a)	the Agency Commission cannot be greater than the Base Price
b)	the Package End Date must be later than Package Start Date
c)	Package Name and Package Description cannot be null

 * Group Members: Jorge Perez
 *                Katrina Spencer
 *                Angelito Tuguinay
 *                Jetlyn Jhoy Sarmiento
 * Date: Feb 13, 2021.
 */

namespace CPRG200.TravelExperts.App
{
    public partial class frmTravelPackage : Form
    {
        
        Package currentPkg = null; // current package -Katrina
        List<int> packageIds = null; // all package ids -Katrina
        List<PackageProductSupplier> currentPkgProdSup = null; // current pkg prod sup -Katrina

        List<int> supplierIds = null; // all supplier ids -Angelito
        Supplier currentSup = null; // current supplier -Angelito

        List<int> productIds = null; // all product ids -Katrina
        Product currentProd = null; // current product -Katrina

        List<int> productSupplierIds = null; // all prod sup ids -Jorge
        ProductSupplier currentProdSup = null; // current prod sup -Jorge

        public frmTravelPackage()
        {
            InitializeComponent();
        }

        /* -----------------------------
           PACKAGE TAB - KATRINA SPENCER 
           ----------------------------- */

        /// <summary>
        /// Katrina: Loads combobox list of package, product, product-supplier, and supplier ids on-load
        /// </summary>
        private void frmTravelPackage_Load(object sender, EventArgs e)
        {
            this.Text = "Travel Experts Form";
            RefreshPkgComboBox();
            RefreshSupComboBox();
            RefreshProdComboBox();
            RefreshProdSupComboBox();
        }
        /// <summary>
        ///  Katrina: Refreshes/loads package combobox for on-load, adds, and updates
        /// </summary>
        private void RefreshPkgComboBox(bool lastIndex = false)
        {
            int selectIndex = 0;
            packageIds = PackageDB.GetPackageIds();

            if (packageIds.Count > 0) // if there are packages -Katrina
            {
                PkgIdComboBox.DataSource = packageIds;

                if (lastIndex == true)
                {
                    selectIndex = PkgIdComboBox.Items.Count - 1;
                }

                PkgIdComboBox.SelectedIndex = selectIndex; // triggers selectedindexchanged -Katrina
            }
            else // no packages -Katrina
            {
                MessageBox.Show("There are no packages. Add a package in the database and restart the application ", "Empty Load");
                Application.Exit();
            }
        }
        /// <summary>
        /// Katrina: Package selection changes
        /// </summary>
        private void PkgIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(PkgIdComboBox.SelectedValue);
            try
            {
                currentPkg = PackageDB.GetPackage(selectedId);
                DisplayCurrentPkgData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while retrieving package with selected ID: " + ex.Message,
                    ex.GetType().ToString());
            }
        }
        /// <summary>
        /// Katrina: Displays the current selected package
        /// </summary>
        private void DisplayCurrentPkgData()
        {
            if (currentPkg != null)
            {
                PkgNameTextBox.Text = currentPkg.PkgName;
                PkgBasePriceTextBox.Text = currentPkg.PkgBasePrice.ToString("c");
                // if start date is null -Katrina
                if (currentPkg.PkgStartDate == null)
                    pkgStartDateDateTimePicker.Text = "";
                else
                {
                    DateTime startDate = (DateTime)currentPkg.PkgStartDate;
                    pkgStartDateDateTimePicker.Text = startDate.ToShortDateString();
                }
                // if end date is null -Katrina
                if (currentPkg.PkgEndDate == null)
                    pkgEndDateDateTimePicker.Text = "";
                else
                {
                    DateTime endDate = (DateTime)currentPkg.PkgEndDate;
                    pkgEndDateDateTimePicker.Text = endDate.ToShortDateString();
                }
                // if description is null -Katrina
                if (currentPkg.PkgDesc == null)
                    PkgDescTextBox.Text = "";
                else
                {
                    string desc = (string)currentPkg.PkgDesc;
                    PkgDescTextBox.Text = desc;
                }
                // if agency commission is null -Katrina
                if (currentPkg.PkgAgencyCommission == null)
                    PkgAgencyCommissionTextBox.Text = "";
                else
                {
                    decimal commission = (decimal)currentPkg.PkgAgencyCommission;
                    PkgAgencyCommissionTextBox.Text = commission.ToString("c");
                }
                // get current package product supplier details -Katrina
                currentPkgProdSup = PackageProductSupplierDB.GetProductsSuppliersByPackageId(currentPkg.PackageId);
                packageProductSupplierDataGridView.DataSource = currentPkgProdSup;
            }
            else
                MessageBox.Show("This package does not exist. Please try again.");
        }
        /// <summary>
        /// Katrina: Opens form for adding new package and displays new added data on main form
        /// </summary>
        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            frmAddModifyPackage addForm = new frmAddModifyPackage();
            addForm.addPackage = true;
            DialogResult result = addForm.ShowDialog(); // displays new modal form -Katrina
            if (result == DialogResult.OK)
            {
                currentPkg = addForm.package;
                PkgIdComboBox.Text = currentPkg.PackageId.ToString();
                this.DisplayCurrentPkgData();
                RefreshPkgComboBox(true);
                MessageBox.Show("New package has been added.");
            }
        }
        /// <summary>
        /// Katrina: Opens form for modifying package info and displays new modified data on main form
        /// </summary>
        private void btnModPackage_Click(object sender, EventArgs e)
        {
            frmAddModifyPackage updateForm = new frmAddModifyPackage();
            updateForm.addPackage = false;
            updateForm.currentPkg = currentPkg; // set current package on update form -Katrina
            DialogResult result = updateForm.ShowDialog(); // display second form modal -Katrina
            if (result == DialogResult.OK)
            {
                currentPkg = updateForm.currentPkg; // receive current pkg from update form -Katrina     
            }
            else if (result == DialogResult.Retry)
            {
                currentPkg = PackageDB.GetPackage(currentPkg.PackageId);
            }
            DisplayCurrentPkgData();
        }
        /// <summary>
        /// Katrina: Opens form for adding new product supplier to selected package
        /// </summary>
        private void btnNewProducts_Click(object sender, EventArgs e)
        {
            frmAddNewPkgProdSup newProdForm = new frmAddNewPkgProdSup();
            newProdForm.currentPkg = currentPkg;
            DialogResult result = newProdForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.DisplayCurrentPkgData();
                MessageBox.Show("New product supplier has been added to the package.");
            }
        }
        /// <summary>
        /// Katrina: Terminates application from packages tab
        /// </summary>
        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        /* -----------------------
           SUPPLIER TAB - ANGELITO 
           ----------------------- */

        /// <summary>
        /// Angelito: Refresh supplier combo box
        /// </summary>
        private void RefreshSupComboBox(bool lastIndex = false)
        {
            int selectIndex = 0;
            supplierIds = SupplierDB.GetSupplierIds();

            if (supplierIds.Count > 0) // if there are suppliers
            {
                supplierIdComboBox.DataSource = supplierIds;

                if (lastIndex == true)
                {
                    selectIndex = supplierIdComboBox.Items.Count - 1;
                }

                supplierIdComboBox.SelectedIndex = selectIndex; // triggers selectedindexchanged
            }
            else // no suppliers
            {
                MessageBox.Show("There are no suppliers. Add a supplier in the database and restart the application ", "Empty Load");
                Application.Exit();
            }
        }
        /// <summary>
        /// Angelito: Display current supplier 
        /// </summary>
        private void DisplayCurrentSupData()
        {
            if (currentSup != null)
            {
                // can't be null -Katrina
                supplierIdComboBox.Text = currentSup.SupplierId.ToString();
                // supplier name may be null -Katrina
                if (currentSup.SupName == null)
                    supNameTextBox.Text = "";
                else
                    supNameTextBox.Text = currentSup.SupName;
            }
            else
                MessageBox.Show("This supplier does not exist. Please try again.");
        }
        // Exit application from supplier tab -Katrina
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Angelito: SupplierId combobox index change 
        /// </summary>
        private void SupplierIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(supplierIdComboBox.SelectedValue);
            try
            {
                currentSup = SupplierDB.GetSupplier(selectedId);
                DisplayCurrentSupData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while retrieving supplier with selected ID: " + ex.Message,
                    ex.GetType().ToString());
            }
            
        }
        /// <summary>
        /// Angelito: ADD Supplier
        /// </summary>
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            frmAddModifySupplier addForm = new frmAddModifySupplier();
            addForm.addSupplier = true;
            addForm.supIDs = supplierIds;
            DialogResult result = addForm.ShowDialog(); // displays new modal form
            if (result == DialogResult.OK)
            {
                currentSup = addForm.supplier;
                supplierIdComboBox.Text = currentSup.SupplierId.ToString();
                this.DisplayCurrentSupData();
                RefreshSupComboBox(true);
                MessageBox.Show("New supplier has been added.");
            }
        }
        /// <summary>
        /// Angelito: Edit Supplier data
        /// </summary>
        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            frmAddModifySupplier addForm = new frmAddModifySupplier();
            addForm.addSupplier = false;
            addForm.currentSup = currentSup;
            DialogResult result = addForm.ShowDialog(); //display frmAddModifySupplier
            if(result == DialogResult.OK)
            {
                currentSup = addForm.currentSup;
                MessageBox.Show("Successfully modified supplier: " + currentSup.SupplierId.ToString());
            }
            this.DisplayCurrentSupData();
        }



        /* -----------------------------
           PRODUCT TAB - KATRINA SPENCER         
           ----------------------------- */

        /// <summary>
        /// Katrina: Refreshes product combobox
        /// </summary>
        private void RefreshProdComboBox(bool lastIndex = false)
        {
            int selectIndex = 0;
            productIds = ProductDB.GetProductIds();

            if (productIds.Count > 0) // if there are products
            {
                productIdComboBox.DataSource = productIds;

                if (lastIndex == true)
                {
                    selectIndex = productIdComboBox.Items.Count - 1;
                }

                productIdComboBox.SelectedIndex = selectIndex; // triggers selectedindexchanged
            }
            else // no products
            {
                MessageBox.Show("There are no products. Add a product in the database and restart the application ", "Empty Load");
                Application.Exit();
            }
        }
        /// <summary>
        /// Katrina: Display current product
        /// </summary>
        private void DisplayCurrentProdData()
        {
            if (currentProd != null)
            {
                productIdComboBox.Text = currentProd.ProductId.ToString();
                prodNameTextBox.Text = currentProd.ProdName;
            }
            else
                MessageBox.Show("This product does not exist. Please try again.");
        }
        /// <summary>
        /// Katrna: Lists product information when product id is selected from combobox
        /// </summary>
        private void productIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(productIdComboBox.SelectedValue);
            try
            {
                currentProd = ProductDB.GetProduct(selectedId);
                DisplayCurrentProdData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while retrieving product with selected ID: " + ex.Message,
                    ex.GetType().ToString());
            }
        }
        /// <summary>
        /// Katrina: Opens form for adding new product info and displays added product on main form
        /// </summary>
        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            frmAddModifyProducts addForm = new frmAddModifyProducts();
            addForm.addProduct = true;
            addForm.prodIds = productIds;
            DialogResult result = addForm.ShowDialog(); // displays new modal form
            if (result == DialogResult.OK)
            {
                currentProd = addForm.product;
                productIdComboBox.Text = currentProd.ProductId.ToString();
                this.DisplayCurrentProdData();
                RefreshProdComboBox(true);
                MessageBox.Show("New product has been added.");
            }
        }
        /// <summary>
        /// Katrina: Opens form for modifying product info and displays new modified data on main form
        /// </summary>
        private void btnModifyProducts_Click(object sender, EventArgs e)
        {
            frmAddModifyProducts addForm = new frmAddModifyProducts();
            addForm.addProduct = false;
            addForm.currentProd = currentProd;
            DialogResult result = addForm.ShowDialog(); //display frmAddModifySupplier
            if (result == DialogResult.OK)
            {
                currentProd = addForm.currentProd;
                MessageBox.Show("Successfully modified product: " + currentProd.ProductId.ToString());
            }
            this.DisplayCurrentProdData();
        }
        /// <summary>
        /// Katrina: Terminates application from products tab
        /// </summary>
        private void btnExitProducts_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        /* ----------------------------------------------------
           PRODUCT SUPPLIER TAB - JORGE PEREZ
           ---------------------------------------------------- */

        /// <summary>
        /// Jorge: Refreshes prod sup combobox
        /// </summary>
        /// <param name="lastIndex"></param>
        private void RefreshProdSupComboBox(bool lastIndex = false)
        {
            int selectIndex = 0;
            productSupplierIds = ProductSupplierDB.GetProductSupplierIds();

            if (productSupplierIds.Count > 0) // if there are prod sups
            {
                prodSupplierIdComboBox.DataSource = productSupplierIds;

                if (lastIndex == true)
                {
                    selectIndex = prodSupplierIdComboBox.Items.Count - 1;
                }

                prodSupplierIdComboBox.SelectedIndex = selectIndex; // triggers selectedindexchanged
            }
            else // no packages
            {
                MessageBox.Show("There are no product suppliers. Add a product supplier in the database and restart the application ", "Empty Load");
                Application.Exit();
            }
        }
        /// <summary>
        /// Jorge: Display current product supplier data
        /// </summary>
        private void DisplayCurrentProdSupData()
        {
            if (currentProdSup != null)
            {
                prodSupplierIdComboBox.Text = currentProdSup.ProductSupplierId.ToString();
                // product id can be null
                if (currentProdSup.ProductId == null)
                    productIdTextBox.Text = "";
                else
                    productIdTextBox.Text = currentProdSup.ProductId.ToString();
                // supplier id can be null
                if (currentProdSup.SupplierId == null)
                    supplierIdTextBox.Text = "";
                else
                    supplierIdTextBox.Text = currentProdSup.SupplierId.ToString();
                // product name can be null
                if (currentProdSup.ProdName == null)
                    prodNameProdSupTextBox.Text = "";
                else
                    prodNameProdSupTextBox.Text = currentProdSup.ProdName.ToString();
                // supplier name can be null
                if (currentProdSup.SupName == null)
                    supNameProdSupTextBox.Text = "";
                else
                    supNameProdSupTextBox.Text = currentProdSup.SupName.ToString();                   
            }
            else
                MessageBox.Show("This product supplier does not exist. Please try again.");
        }
        /// <summary>
        /// Jorge: Lists product supplier information when prodsup id is selected from combobox
        /// </summary>
        private void prodSupplierIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(prodSupplierIdComboBox.SelectedValue);
            try
            {
                currentProdSup = ProductSupplierDB.GetProductSupplier(selectedId);
                DisplayCurrentProdSupData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while retrieving product supplier with selected ID: " + ex.Message,
                    ex.GetType().ToString());
            }
        }
        /// <summary>
        /// Katrina: Opens form for adding new product supplier info and displays added product supplier on main form
        /// </summary>
        private void btnAddProdSup_Click(object sender, EventArgs e)
        {
            frmAddModifyProdSupplier addForm = new frmAddModifyProdSupplier();
            addForm.addProductSupplier = true;
            addForm.prodSupId = productSupplierIds;
            DialogResult result = addForm.ShowDialog(); // displays new modal form
            if (result == DialogResult.OK)
            {
                currentProdSup = addForm.productSupplier;
                prodSupplierIdComboBox.Text = currentProdSup.ProductSupplierId.ToString();
                DisplayCurrentProdSupData();
                RefreshProdSupComboBox(true);
                MessageBox.Show("New product supplier has been added.");
            }
        }
        /// <summary>
        /// Jorge: Opens form for modifying product supplier info and displays new data on main form
        /// </summary>
        private void btnModProdSup_Click(object sender, EventArgs e)
        {
            frmAddModifyProdSupplier addForm = new frmAddModifyProdSupplier();
            addForm.addProductSupplier = false;
            addForm.currentProdSup = currentProdSup;
            
            DialogResult result = addForm.ShowDialog(); //display frmAddModifySupplier
            if (result == DialogResult.OK)
            {
                Console.WriteLine(addForm.productSupplier.ProdName);
                currentProdSup = addForm.currentProdSup;
                MessageBox.Show("Successfully modified product supplier: " + currentProdSup.ProductSupplierId.ToString());
            }
            this.DisplayCurrentProdSupData();
        }
        /// <summary>
        /// Jorge: Terminates application from the product suppliers tab
        /// </summary>
        private void btnExitProdSup_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
