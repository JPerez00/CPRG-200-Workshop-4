using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200.TravelExperts.Data
{
    /*
     * Purpose: Data access class for Packages
     * Authors: Group 5
     * Date Created: 02/2021
     */
    public static class PackageDB
    {
        /// <summary>
        /// Katrina Spencer: Retrieves package info with given id
        /// </summary>
        /// <param name="pkgId">id of package to get</param>
        /// <returns>package object</returns>
        public static Package GetPackage(int pkgId)
        {
            Package pkg = null;
            // connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission " +
                               "FROM Packages " +
                               "WHERE PackageId = @PackageId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", pkgId);
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (dr.Read()) // if data
                        {
                            pkg = new Package();
                            pkg.PackageId = (int)dr["PackageId"];
                            pkg.PkgName = (string)dr["PkgName"];
                            pkg.PkgBasePrice = Convert.ToDecimal(dr["PkgBasePrice"]);

                            // need to determine if it is DBNull and set
                            int colSD = dr.GetOrdinal("PkgStartDate"); // column number of PkgStartDate
                            if (dr.IsDBNull(colSD)) // if reader contains DBNull in this column
                                pkg.PkgStartDate = null; // make null in the object
                            else // if not null
                                pkg.PkgStartDate = (DateTime)dr["PkgStartDate"];

                            int colED = dr.GetOrdinal("PkgEndDate"); // column number of PkgEndDate
                            if (dr.IsDBNull(colED)) // if reader contains DBNull in this column
                                pkg.PkgEndDate = null; // make null in the object
                            else // if not null
                                pkg.PkgEndDate = (DateTime)dr["PkgEndDate"];

                            int colDesc = dr.GetOrdinal("PkgDesc"); // column number of PkgDesc
                            if (dr.IsDBNull(colDesc)) // if reader contains DBNull in this column
                                pkg.PkgDesc = null; // make null in the object
                            else // if not null
                                pkg.PkgDesc = (string)dr["PkgDesc"];

                            int colAC = dr.GetOrdinal("PkgAgencyCommission"); // column number of PkgAgencyCommission
                            if (dr.IsDBNull(colAC)) // if reader contains DBNull in this column
                                pkg.PkgAgencyCommission = null; // make null in the object
                            else // if not null
                                pkg.PkgAgencyCommission = Convert.ToDecimal(dr["PkgAgencyCommission"]);
                        }
                    }
                }
            }
            return pkg;
        }
        /// <summary>
        /// Katrina Spencer: List of package ids for combobox
        /// </summary>
        /// <returns>list of package ids</returns>
        public static List<int> GetPackageIds()
        {
            List<int> packages = new List<int>(); // empty
            int pkg;
            // connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT PackageId " +
                               "FROM Packages " +
                               "ORDER BY PackageId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) // while there is data
                        {
                            pkg = Convert.ToInt32(dr["PackageId"]);
                            packages.Add(pkg);
                        }
                    }
                }
            }
            return packages;
        }
        /// <summary>
        /// Angelito: Adds a new package
        /// </summary>
        /// <param name="pkg">new package info</param>
        /// <returns>new package id</returns>
        public static int AddPackage(Package pkg)
        {
            int pkgId = 0;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string insertStatement =
                    "INSERT INTO Packages (PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                    "OUTPUT INSERTED.PackageId " +
                    "VALUES(@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    // Added consideration for Null values -Katrina
                    cmd.Parameters.AddWithValue("@PkgName", pkg.PkgName);
                    Console.WriteLine("Package name in databse to be inserted "+pkg.PkgName);

                    if (pkg.PkgStartDate == null)
                        cmd.Parameters.AddWithValue("@PkgStartDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgStartDate", (DateTime)pkg.PkgStartDate);

                    if (pkg.PkgEndDate == null)
                        cmd.Parameters.AddWithValue("@PkgEndDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgEndDate", (DateTime)pkg.PkgEndDate);

                    if (pkg.PkgDesc == null)
                        cmd.Parameters.AddWithValue("@PkgDesc", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgDesc", (string)pkg.PkgDesc);

                    cmd.Parameters.AddWithValue("@PkgBasePrice", pkg.PkgBasePrice);

                    if (pkg.PkgAgencyCommission == null)
                        cmd.Parameters.AddWithValue("@PkgAgencyCommission", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgAgencyCommission", (decimal)pkg.PkgAgencyCommission);

                    // open connection
                    connection.Open();
                    pkgId = (int)cmd.ExecuteScalar(); // returns one value
                }
            }
            return pkgId;
        }

        /// <summary>
        /// Angelito: Updates package info
        /// </summary>
        /// <param name="oldPkg">old package info</param>
        /// <param name="newPkg">new package info</param>
        /// <returns>success indicator</returns>
        public static bool UpdatePackage(Package oldPkg, Package newPkg)
        {
            // added consideration for Null values -Katrina
            bool result = false; // no success yet
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement = "UPDATE Packages SET " +
                    "PkgName = @NewPkgName, " +
                    "PkgStartDate = @NewPkgStartDate, " +
                    "PkgEndDate = @NewPkgEndDate, " +
                    "PkgDesc = @NewPkgDesc, " +
                    "PkgBasePrice = @NewPkgBasePrice, " +
                    "PkgAgencyCommission = @NewPkgAgencyCommission " +
                    "WHERE PackageId = @OldPackageId " + // identifies package
                    "AND PkgName = @OldPkgName " +
                    // PkgStartDate Null option -Katrina
                    "AND (PkgStartDate = @OldPkgStartDate " +
                    "OR PkgStartDate IS NULL " +
                    "AND @OldPkgStartDate IS NULL) " +
                    // PkgEndDate Null option -Katrina
                    "AND (PkgEndDate = @OldPkgEndDate " +
                    "OR PkgEndDate IS NULL " +
                    "AND @OldPkgEndDate IS NULL) " +
                    // PkgDesc Null option -Katrina
                    "AND (PkgDesc = @OldPkgDesc " +
                    "OR PkgDesc IS NULL " +
                    "AND @OldPkgDesc IS NULL) " +
                    "AND PkgBasePrice = @OldPkgBasePrice " +
                    // PkgAgencyCommission Null option -Katrina
                    "AND (PkgAgencyCommission = @OldPkgAgencyCommission " +
                    "OR PkgAgencyCommission IS NULL " +
                    "AND @OldPkgAgencyCommission IS NULL)";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    // added consideration for Null values -Katrina
                    cmd.Parameters.AddWithValue("@NewPkgName", newPkg.PkgName);

                    if (newPkg.PkgStartDate == null) // if new PkgStartDate is null
                        cmd.Parameters.AddWithValue("@NewPkgStartDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@NewPkgStartDate", (DateTime)newPkg.PkgStartDate);

                    if (newPkg.PkgEndDate == null) // if new PkgEndDate is null
                        cmd.Parameters.AddWithValue("@NewPkgEndDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@NewPkgEndDate", (DateTime)newPkg.PkgEndDate);

                    // PkgDesc and PkgBasePrice can't be null when modifying
                    cmd.Parameters.AddWithValue("@NewPkgDesc", newPkg.PkgDesc);
                    cmd.Parameters.AddWithValue("@NewPkgBasePrice", newPkg.PkgBasePrice);

                    if (newPkg.PkgAgencyCommission == null) // if new PkgAgencyCommission is null
                        cmd.Parameters.AddWithValue("@NewPkgAgencyCommission", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@NewPkgAgencyCommission", (decimal)newPkg.PkgAgencyCommission);

                    cmd.Parameters.AddWithValue("@OldPackageId", oldPkg.PackageId);
                    cmd.Parameters.AddWithValue("@OldPkgName", oldPkg.PkgName);

                    if (oldPkg.PkgStartDate == null) // if old PkgStartDate is null
                        cmd.Parameters.AddWithValue("@OldPkgStartDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OldPkgStartDate", (DateTime)oldPkg.PkgStartDate);

                    if (oldPkg.PkgEndDate == null) // if old PkgEndDate is null
                        cmd.Parameters.AddWithValue("@OldPkgEndDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OldPkgEndDate", (DateTime)oldPkg.PkgEndDate);

                    if (oldPkg.PkgDesc == null) // if old PkgDesc is null
                        cmd.Parameters.AddWithValue("@OldPkgDesc", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OldPkgDesc", (string)oldPkg.PkgDesc);

                    cmd.Parameters.AddWithValue("@OldPkgBasePrice", oldPkg.PkgBasePrice);

                    if (oldPkg.PkgAgencyCommission == null) // if old PkgAgencyCommission is null
                        cmd.Parameters.AddWithValue("@OldPkgAgencyCommission", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OldPkgAgencyCommission", (decimal)oldPkg.PkgAgencyCommission);

                    // open connection
                    connection.Open();
                    // execute UPDATE command
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0) // if row(s) affected
                        result = true;
                }
            }
            return result;
        }
    }
}
