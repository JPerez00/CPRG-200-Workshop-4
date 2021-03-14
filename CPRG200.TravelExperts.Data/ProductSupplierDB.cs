using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200.TravelExperts.Data
{
    /*
     * Purpose: Data access class for Products_Suppliers
     * Authors: Group 5
     * Date Created: 02/2021
     */
    public static class ProductSupplierDB
    {
        /// <summary>
        /// Katrina Spencer: Retrieves list of products-suppliers
        /// </summary>
        /// <returns>products-suppliers</returns>
        public static List<ProductSupplier> GetAllProductsSuppliers()
        {
            List<ProductSupplier> prodsSups = new List<ProductSupplier>(); // empty
            ProductSupplier prodSup;
            // connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT ProductSupplierId, ProductId, SupplierId " +
                               "FROM Products_Suppliers " +
                               "ORDER BY ProductSupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) // while there is data
                        {
                            prodSup = new ProductSupplier();
                            prodSup.ProductSupplierId = (int)dr["ProductSupplierId"];
                            prodSup.ProductId = (int)dr["ProductId"];
                            prodSup.SupplierId = (int)dr["ProdName"];
                            prodsSups.Add(prodSup);
                        }
                    }
                }
            }
            return prodsSups;
        }
        /// <summary>
        /// Katrina Spencer: Retrieves product-supplier info with given id
        /// </summary>
        /// <param name="prodSupId">id of product-supplier to get</param>
        /// <returns>product-supplier object</returns>
        public static ProductSupplier GetProductSupplier(int prodSupId)
        {
            ProductSupplier prodSup = null;
            // connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT ProductSupplierId, ps.ProductId, ProdName, ps.SupplierId, SupName " +
                               "FROM Products_Suppliers AS ps " +
                               "JOIN Products ON ps.ProductId = Products.ProductId " +
                               "JOIN Suppliers ON ps.SupplierId = Suppliers.SupplierId " +
                               "WHERE ProductSupplierId = @ProductSupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductSupplierId", prodSupId);
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (dr.Read()) // if data
                        {
                            prodSup = new ProductSupplier();
                            prodSup.ProductSupplierId = (int)dr["ProductSupplierId"];

                            // determine if it is DBNull and set
                            int colProd = dr.GetOrdinal("ProductId"); // column number of ProductId
                            if (dr.IsDBNull(colProd)) // if reader contains DBNull in this column
                                prodSup.ProductId = null; // make null in the object
                            else // if not null
                                prodSup.ProductId = (int)(dr["ProductId"]);

                            int colSup = dr.GetOrdinal("SupplierId"); // column number of SupplierId
                            if (dr.IsDBNull(colSup)) // if reader contains DBNull in this column
                                prodSup.SupplierId = null; // make null in the object
                            else // if not null
                                prodSup.SupplierId = (int)(dr["SupplierId"]);

                            int colProdName = dr.GetOrdinal("ProdName"); // column number of ProdName
                            if (dr.IsDBNull(colProdName)) // if reader contains DBNull in this column
                                prodSup.ProdName = null; // make null in the object
                            else // if not null
                                prodSup.ProdName = (string)(dr["ProdName"]);

                            int colSupName = dr.GetOrdinal("SupName"); // column number of SupName
                            if (dr.IsDBNull(colSupName)) // if reader contains DBNull in this column
                                prodSup.SupName = null; // make null in the object
                            else // if not null
                                prodSup.SupName = (string)(dr["SupName"]);
                        }
                    }
                }
            }
            return prodSup;
        }
        /// <summary>
        /// Katrina Spencer: Updates product-supplier info
        /// </summary>
        /// <param name="oldProdSup">old product-supplier info</param>
        /// <param name="newProdSup">new product-supplier info</param>
        /// <returns>success indicator</returns>
        public static bool UpdateProductSupplier(ProductSupplier oldProdSup, ProductSupplier newProdSup)
        {
            bool result = false; // no success yet
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement = "UPDATE Products_Suppliers " +
                                         "SET ProductId = @NewProductId, " +
                                         "SupplierId = @NewSupplierId " +
                                         "WHERE ProductSupplierId = @OldProductSupplierId " + // identifies product-supplier
                                         "AND (ProductId = @OldProductId " +
                                         "OR ProductId IS NULL " +
                                         "AND @OldProductId IS NULL) " +
                                         "AND (SupplierId = @OldSupplierId " +
                                         "OR SupplierId IS NULL " +
                                         "AND @OldSupplierId IS NULL)";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    if (newProdSup.ProductId == null) // if new ProductId is null
                        cmd.Parameters.AddWithValue("@NewProductId", DBNull.Value); // set DBNull
                    else
                        cmd.Parameters.AddWithValue("@NewProductId", (int)newProdSup.ProductId);

                    if (newProdSup.SupplierId == null) // if new SupplierId is null
                        cmd.Parameters.AddWithValue("@NewSupplierId", DBNull.Value); // set DBNull
                    else
                        cmd.Parameters.AddWithValue("@NewSupplierId", (int)newProdSup.SupplierId);

                    cmd.Parameters.AddWithValue("@OldProductSupplierId", oldProdSup.ProductSupplierId);

                    if (oldProdSup.ProductId == null) // if old ProductId is null
                        cmd.Parameters.AddWithValue("@OldProductId", DBNull.Value); // set DBNull
                    else
                        cmd.Parameters.AddWithValue("@OldProductId", (int)oldProdSup.ProductId);

                    if (oldProdSup.SupplierId == null) // if old SupplierId is null
                        cmd.Parameters.AddWithValue("@OldSupplierId", DBNull.Value); // set DBNull
                    else
                        cmd.Parameters.AddWithValue("@OldSupplierId", (int)oldProdSup.SupplierId);

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
        /// Katrina Spencer: Adds new product-supplier
        /// </summary>
        /// <param name="prodSup">new product-supplier info</param>
        /// <returns>new product-supplier id</returns>
        public static int AddProductSupplier(ProductSupplier prodSup)
        {
            int prodSupId = 0;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string insertStatement = "INSERT INTO Products_Suppliers (ProductId, SupplierId) " +
                                         "OUTPUT INSERTED.ProductSupplierId " + // returns single value
                                         "VALUES(@ProductId, @SupplierId)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    if (prodSup.ProductId == null)
                        cmd.Parameters.AddWithValue("@ProductId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ProductId", (int)prodSup.ProductId);

                    if (prodSup.SupplierId == null)
                        cmd.Parameters.AddWithValue("@SupplierId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@SupplierId", (int)prodSup.SupplierId);

                    // open connection
                    connection.Open();
                    prodSupId = (int)cmd.ExecuteScalar(); // returns one value
                }
            }
            return prodSupId;
        }

        /// <summary>
        /// Jorge: List of product-supplier ids for combobox
        /// </summary>
        /// <returns></returns>
        public static List<int> GetProductSupplierIds()
        {
            List<int> productsupplierIds = new List<int>(); // Empty Prod Supplier
            int prodSupId;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT ProductSupplierId " +
                               "FROM Products_Suppliers " +
                               "ORDER BY ProductSupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) // while there is data
                        {
                            prodSupId = Convert.ToInt32(dr["ProductSupplierId"]);
                            productsupplierIds.Add(prodSupId);
                        }
                    }
                }
            }
            return productsupplierIds;
        }
    } // class
} // namespace
