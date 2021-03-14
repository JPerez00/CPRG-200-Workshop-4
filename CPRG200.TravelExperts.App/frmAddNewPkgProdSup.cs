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
    public partial class frmAddNewPkgProdSup : Form
    {
        public Package currentPkg;
        List<PackageProductSupplier> newProdSups = null;
        List<int> prodSupIds = null;

        public frmAddNewPkgProdSup()
        {
            InitializeComponent();
        }

        private void frmAddNewPkgProdSup_Load(object sender, EventArgs e)
        {
            this.Text = "Add New Product Supplier to Package";
            packageIdTextBox.Text = currentPkg.PackageId.ToString();
            prodSupIds = PackageProductSupplierDB.GetNewProductSupplierIds(currentPkg.PackageId);
            productSupplierIdComboBox.DataSource = prodSupIds;
            newProdSups = PackageProductSupplierDB.GetNewProductsSuppliers(currentPkg.PackageId);
            productSupplierDataGridView.DataSource = newProdSups;
        }

        private void SavePkgProdSup_Click(object sender, EventArgs e)
        {
            try
            {
                PackageProductSupplierDB.AddPackageProductSupplier(currentPkg.PackageId, Convert.ToInt32(productSupplierIdComboBox.SelectedValue));
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnClosePkgProdSup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
