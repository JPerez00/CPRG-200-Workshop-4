using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200.TravelExperts.Data
{
    /*
     * Purpose: Data access class for Suppliers
     * Authors: Group 5
     * Date Created: 02/2021
     */
    public static class SupplierDB
    {
        /// <summary>
        /// Katrina Spencer: Retrieves list of suppliers
        /// </summary>
        /// <returns>suppliers</returns>
        public static List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>(); // empty
            Supplier sup;
            // connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT SupplierId, SupName " +
                               "FROM Suppliers " +
                               "ORDER BY SupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) // while there is data
                        {
                            sup = new Supplier();
                            sup.SupplierId = (int)dr["SupplierId"];
                            sup.SupName = (string)dr["SupName"];
                            suppliers.Add(sup);
                        }
                    }
                }
            }
            return suppliers;
        }
        /// <summary>
        /// Katrina Spencer: Retrieves supplier info with given id
        /// </summary>
        /// <param name="supId">id of supplier to get</param>
        /// <returns>supplier object</returns>
        public static Supplier GetSupplier(int supId)
        {
            Supplier sup = null;
            // connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT SupplierId, SupName " +
                               "FROM Suppliers " +
                               "WHERE SupplierId = @SupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supId);
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (dr.Read()) // if data
                        {
                            sup = new Supplier();
                            sup.SupplierId = (int)dr["SupplierId"];

                            // determine if it is DBNull and set
                            int col = dr.GetOrdinal("SupName"); // column number of SupName
                            if (dr.IsDBNull(col)) // if reader contains DBNull in this column
                                sup.SupName = null; // make null in the object
                            else // if not null
                                sup.SupName = (string)(dr["SupName"]);
                        }
                    }
                }
            }
            return sup;
        }
        /// <summary>
        /// Katrina Spencer: Updates supplier info
        /// </summary>
        /// <param name="oldSup">old supplier info</param>
        /// <param name="newSup">new supplier info</param>
        /// <returns>success indicator</returns>
        public static bool UpdateSupplier(Supplier oldSup, Supplier newSup)
        {
            bool result = false; // no success yet
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement = "UPDATE Suppliers " +
                                         "SET SupName = @NewSupName " +
                                         "WHERE SupplierId = @OldSupplierId " + // identifies supplier
                                         "AND (SupName = @OldSupName " +
                                         "OR SupName IS NULL " +
                                         "AND @OldSupName IS NULL)";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    if (newSup.SupName == null) // if new SupName is null
                        cmd.Parameters.AddWithValue("@NewSupName", DBNull.Value); // set DBNull
                    else
                        cmd.Parameters.AddWithValue("NewSupName", (string)newSup.SupName);

                    cmd.Parameters.AddWithValue("@OldSupplierId", oldSup.SupplierId);

                    if (oldSup.SupName == null) // if old SupName is null
                        cmd.Parameters.AddWithValue("@OldSupName", DBNull.Value); // set DBNull
                    else
                        cmd.Parameters.AddWithValue("@OldSupName", (string)oldSup.SupName);

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
        /// <summary>
        /// Katrina Spencer: Adds a new supplier
        /// </summary>
        /// <param name="sup">new supplier info</param>
        /// <returns>new supplier id</returns>
        public static int AddSupplier(Supplier sup)
        {
            int supId = 0;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string insertStatement = "INSERT INTO Suppliers (SupName, SupplierId) " +
                                         "OUTPUT INSERTED.SupplierId " + // returns single value
                                         "VALUES(@SupName, @SupplierId)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", sup.SupplierId);
                    if (sup.SupName == null)
                        cmd.Parameters.AddWithValue("@SupName", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@SupName", (string)sup.SupName);

                    // open connection
                    connection.Open();
                    supId = (int)cmd.ExecuteScalar(); // returns one value
                }
            }
            return supId;
        }

        /// <summary>
        /// Angelito: List of supplier ids for combobox
        /// </summary>
        /// <returns></returns>
        public static List<int> GetSupplierIds()
        {
            List<int> supplierIds = new List<int>(); //Empty suppliers
            int supId;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT SupplierId " +
                               "FROM Suppliers " +
                               "ORDER BY SupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) // while there is data
                        {
                            supId = Convert.ToInt32(dr["SupplierId"]);
                            supplierIds.Add(supId);
                        }
                    }
                }
            }
            return supplierIds;
        }
    } // class
} // namespace
