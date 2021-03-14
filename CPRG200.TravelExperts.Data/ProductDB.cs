using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200.TravelExperts.Data
{
    /*
     * Purpose: Data access class for Products
     * Authors: Group 5
     * Date Created: 02/2021
     */
    public static class ProductDB
    {
        /// <summary>
        /// Katrina Spencer: Retrieves list of products
        /// </summary>
        /// <returns>products</returns>
        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>(); // empty
            Product prod;
            // connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT ProductId, ProdName " +
                               "FROM Products " +
                               "ORDER BY ProductId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) // while there is data
                        {
                            prod = new Product();
                            prod.ProductId = (int)dr["ProductId"];
                            prod.ProdName = (string)dr["ProdName"];
                            products.Add(prod);
                        }
                    }
                }
            }
            return products;
        }
        /// <summary>
        /// Katrina Spencer: Retrieves product info with given id
        /// </summary>
        /// <param name="prodId">id of product to get</param>
        /// <returns>product object</returns>
        public static Product GetProduct(int prodId)
        {
            Product prod = null;
            // connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT ProductId, ProdName " +
                               "FROM Products " +
                               "WHERE ProductId = @ProductId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", prodId);
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (dr.Read()) // if data
                        {
                            prod = new Product();
                            prod.ProductId = (int)dr["ProductId"];
                            prod.ProdName = (string)dr["ProdName"];
                        }
                    }
                }
            }
            return prod;
        }
        /// <summary>
        /// Katrina Spencer: Updates product info
        /// </summary>
        /// <param name="oldProd">old product info</param>
        /// <param name="newProd">new product info</param>
        /// <returns>success indicator</returns>
        public static bool UpdateProduct(Product oldProd, Product newProd)
        {
            bool result = false; // no success yet
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement = "UPDATE Products " +
                                         "SET ProdName = @NewProdName " +
                                         "WHERE ProductId = @OldProductId " + // identifies product
                                         "AND ProdName = @OldProdName";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    cmd.Parameters.AddWithValue("NewProdName", newProd.ProdName);
                    cmd.Parameters.AddWithValue("@OldProductId", oldProd.ProductId);
                    cmd.Parameters.AddWithValue("@OldProdName", oldProd.ProdName);

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
        /// Katrina Spencer: Adds a new product
        /// </summary>
        /// <param name="prod">new product info</param>
        /// <returns>new product id</returns>
        public static int AddProduct(Product prod)
        {
            int prodId = 0;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string insertStatement = "INSERT INTO Products (ProdName) " +
                                         "OUTPUT INSERTED.ProductId " + // returns single value
                                         "VALUES(@ProdName)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@ProdName", prod.ProdName);

                    // open connection
                    connection.Open();
                    prodId = (int)cmd.ExecuteScalar(); // returns one value
                }
            }
            return prodId;
        }
        /// <summary>
        /// Katrina: List of product ids for combobox
        /// </summary>
        /// <returns></returns>
        public static List<int> GetProductIds()
        {
            List<int> productIds = new List<int>(); // Empty Prod Supplier
            int prodId;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT ProductId " +
                               "FROM Products " +
                               "ORDER BY ProductId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) // while there is data
                        {
                            prodId = Convert.ToInt32(dr["ProductId"]);
                            productIds.Add(prodId);
                        }
                    }
                }
            }
            return productIds;
        }
    }
}