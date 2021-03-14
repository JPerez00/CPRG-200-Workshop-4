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
    public partial class frmAddModifySupplier : Form
    {
        public frmAddModifySupplier()
        {
            InitializeComponent();
        }

        public bool addSupplier; // true if Add, and false if Modify -Katrina
        public Supplier currentSup; // frmMain sets current supplier -Katrina
        public Supplier supplier = new Supplier();

        public List<int> supIDs;

        /// <summary>
        /// Angelito: On load, Add or Modify
        /// </summary>
        private void frmAddModifySupplier_Load(object sender, EventArgs e)
        {
            if (addSupplier) // if this is Add
            {
                this.Text = "Add Supplier";
                //auto generate supplierId by getting last supplierId and adding 1
                DisplayCurrentSupplier();
            }
            else // Modify
            {
                this.Text = "Modify Supplier";
                DisplayCurrentSupplier();
            }
        }

        /// <summary>
        /// Angelito: Display current supplier based on add or modify
        /// </summary>
        private void DisplayCurrentSupplier()
        {
            if (addSupplier == false) //if modify
            {
                SupplierIdTextBox.Text = currentSup.SupplierId.ToString();

                if (currentSup.SupName == null)
                    SupNameTextBox.Text = "";
                else
                    SupNameTextBox.Text = currentSup.SupName;
            }
            else // if add
            {
                SupplierIdTextBox.Text = (supIDs[supIDs.Count - 1] + 1).ToString();
            }
        }

        /// <summary>
        /// Angelito: Save based on add or modify
        /// </summary>
        private void SupplierSaveButton_Click(object sender, EventArgs e)
        {
            if(addSupplier)
            {
                this.PutSupplierData();
                try
                {
                    supplier.SupplierId = SupplierDB.AddSupplier(supplier);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
            else // this is Modify
            {
                // build Supplier object with the new data //Package newPkg = new Package();
                supplier.SupplierId = currentSup.SupplierId;
                this.PutSupplierData();

                try // try to update
                {
                    if (!SupplierDB.UpdateSupplier(currentSup, supplier)) //failed
                    {
                        MessageBox.Show("Another user has updated or deleted current supplier", "Concurrency Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        currentSup = supplier;
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
        /// Angelito: Puts supplier data to empty supplier object to save
        /// </summary>
        private void PutSupplierData()
        {
            supplier.SupplierId = Convert.ToInt32(SupplierIdTextBox.Text);

            if (SupNameTextBox.Text == "")
                supplier.SupName = null;
            else
                supplier.SupName = SupNameTextBox.Text;
        }

        private void SupplierCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
