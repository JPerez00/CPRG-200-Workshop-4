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
    public partial class frmAddModifyPackage : Form
    {
        public frmAddModifyPackage()
        {
            InitializeComponent();
        }

        public bool addPackage; // true if Add, and false if Modify -Katrina
        public Package currentPkg; // frmMain sets current package -Katrina
        public Package package = new Package();

        /// <summary>
        /// Katrina: Displays current package data when form loads
        /// </summary>
        private void frmAddModifyPackage_Load(object sender, EventArgs e)
        {
            if (addPackage) // if this is Add -Katrina
            {
                this.Text = "Add Package";
            }
            else // Modify -Katrina
            {
                this.Text = "Modify Package";
                DisplayCurrentPkg();
            }
        }

        /// <summary>
        /// Katrina: Displays current package if modify
        /// </summary>
        private void DisplayCurrentPkg()
        {
            PkgIdTextBox.Text = currentPkg.PackageId.ToString();
            PkgNameTextBox.Text = currentPkg.PkgName.ToString();
            PkgBasePriceTextBox.Text = currentPkg.PkgBasePrice.ToString();
            // if start date is null -Katrina
            if (currentPkg.PkgStartDate == null)
                pkgStartDatePicker.Text = "";
            else
            {
                DateTime startDate = (DateTime)currentPkg.PkgStartDate;
                pkgStartDatePicker.Text = startDate.ToShortDateString();
            }
            // if end date is null -Katrina
            if (currentPkg.PkgEndDate == null)
                pkgEndDatePicker.Text = "";
            else
            {
                DateTime endDate = (DateTime)currentPkg.PkgEndDate;
                pkgEndDatePicker.Text = endDate.ToShortDateString();
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
                PkgAgencyCommissionTextBox.Text = commission.ToString();
            }
        }
        /// <summary>
        /// Katrina: Saves changes to add or modify
        /// Katrina: Uses validation to check for valid dates, present strings, and number values
        /// </summary>
        private void PkgSaveButton_Click(object sender, EventArgs e)
        {
            // check if valid before accepting changes -Katrina
            if (IsValidDates() && IsValidPkgData() && IsValidPrices())
            {
                Console.WriteLine("Dates are valid");
                if (addPackage) // if this is Add -Katrina
                {
                    this.PutPackageData();
                    try
                    {
                        package.PackageId = PackageDB.AddPackage(package);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else // this is Modify -Katrina
                {
                    // build Package object with the new data -Katrina
                    // Package newPkg = new Package();
                    package.PackageId = currentPkg.PackageId;
                    this.PutPackageData();

                    try // try to update -Katrina
                    {
                        if (!PackageDB.UpdatePackage(currentPkg, package)) // failed -Katrina
                        {
                            MessageBox.Show("Another user has updated or deleted current package", "Concurrency Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            currentPkg = package;
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
        /// All package info for add/modify
        /// </summary>
        private void PutPackageData()
        {
            // can't enter empty string for name
            package.PkgName = PkgNameTextBox.Text;
            // can't enter empty string for description
            package.PkgDesc = PkgDescTextBox.Text;
            // can't enter empty string for base price
            package.PkgBasePrice = Convert.ToDecimal(PkgBasePriceTextBox.Text);

            // if start date is null
            if (pkgStartDatePicker.Text == "")
                package.PkgStartDate = null;
            else
                package.PkgStartDate = Convert.ToDateTime(pkgStartDatePicker.Text);
            // if end date is null
            if (pkgEndDatePicker.Text == "")
                package.PkgEndDate = null;
            else
                package.PkgEndDate = Convert.ToDateTime(pkgEndDatePicker.Text);
            // if agency commission is null
            if (PkgAgencyCommissionTextBox.Text == "")
                package.PkgAgencyCommission = null;
            else
                package.PkgAgencyCommission = Convert.ToDecimal(PkgAgencyCommissionTextBox.Text);

        }

        /// <summary>
        /// Katrina: Checks if any date values are null before verifying if end date is later than start date and if in correct format
        /// </summary>
        /// <returns>if valid or not</returns>
        private bool IsValidDates()
        {
            bool valid = true; // empty is valid
            DateTime startDate;
            DateTime endDate;

            if (pkgStartDatePicker.Text != "" && pkgEndDatePicker.Text != "") // if dates not empty
            {
                // for Start Date input
                if (DateTime.TryParse(pkgStartDatePicker.Text, out startDate)) // if valid date
                {
                    endDate = Convert.ToDateTime(pkgEndDatePicker.Text);
                    // if start date is greater than end date
                    if (endDate <= startDate)
                    {
                        valid = false;
                        MessageBox.Show("Start Date must be earlier than End Date", "Data Error");
                        pkgStartDatePicker.Focus();
                    }
                }
                else // if invalid date
                {
                    valid = false;
                    MessageBox.Show("Please enter Start Date in format MM/DD/YYYY", "Data Error");
                    pkgStartDatePicker.Focus();
                }
                // for End Date input
                if (DateTime.TryParse(pkgEndDatePicker.Text, out endDate)) // if valid date
                {
                    startDate = Convert.ToDateTime(pkgStartDatePicker.Text);
                    // if start date is greater than end date
                    if (startDate >= endDate)
                    {
                        valid = false;
                    }
                }
                else // if invalid date
                {
                    valid = false;
                    MessageBox.Show("Please enter End Date in format MM/DD/YYYY", "Data Error");
                    pkgStartDatePicker.Focus();
                }
            }
            return valid;
        }
        /// <summary>
        /// Katrina: Checks if agency commission is lower than base price
        /// </summary>
        private bool IsValidPrices()
        {
            bool valid = true;
            decimal basePrice;
            decimal commPrice;
            if (PkgAgencyCommissionTextBox != null) // if commission is not null
            {
                commPrice = Convert.ToDecimal(PkgAgencyCommissionTextBox.Text);
                basePrice = Convert.ToDecimal(PkgBasePriceTextBox.Text);
                if (commPrice > basePrice)
                {
                    valid = false;
                    MessageBox.Show("Agency Commission must be less than the Base Price", "Data Error");
                    PkgAgencyCommissionTextBox.Focus();
                }
            }
            return valid;
        }

        /// <summary>
        /// Katrina: Validity of pkg input data
        /// </summary>
        private bool IsValidPkgData()
        {
            return
                Validator.IsPresent(PkgNameTextBox) &&
                Validator.IsPresent(PkgDescTextBox) &&
                Validator.IsPresent(PkgBasePriceTextBox) &&
                Validator.IsDecimal(PkgBasePriceTextBox) &&
                (PkgAgencyCommissionTextBox.Text == "" || Validator.IsDecimal(PkgAgencyCommissionTextBox));
        }
        /// <summary>
        /// Katrina: Closes add/modify package form
        /// </summary>
        private void PkgCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
            
    }
}
