using AdvWorksDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvWorksDAL
{
    public class AdvWorksDataAccessLayer
    {
        SqlConnection conObj;
        SqlCommand cmdObj;
        AdventureWorks2012Context contextObj;
        public AdvWorksDataAccessLayer()
        {
            conObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvWorksConnectionStr"].ConnectionString);
            contextObj = new AdventureWorks2012Context();
        }
        public int ConnectionToDB()
        {
            try
            {
                string sqlConStr = ConfigurationManager.ConnectionStrings["AdvWorksConnectionStr"].ConnectionString;
                SqlConnection conObj = new SqlConnection(sqlConStr);
                conObj.Open();
                if (conObj.State.ToString() == "Open")
                    return 1;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                return -99;
            }
        }
        
        public List<ProductsDTO> FetchProductsListUsingEF()
        {
            try
            {
                //contextObj.Products.ToList();
                //var lstProdListPrice = contextObj.Products.Where(w => w.ListPrice>100).OrderBy(o => o.ListPrice).ToList();
                var result = (from prod in contextObj.Products
                              where prod.ListPrice > 100
                              orderby prod.ListPrice ascending
                              select prod).ToList();
                List<Product> lstProductsFromDB = contextObj.Products.ToList();
                List<ProductsDTO> lstProducts = new List<ProductsDTO>();
                foreach (var prod in result)
                {
                    lstProducts.Add(new ProductsDTO()
                    {
                        ProdId = prod.ProductID,
                        ProdName = prod.Name,
                        ProdNum = prod.ProductNumber,
                        ProdListPrice = prod.ListPrice,
                    });
                }
                //foreach (var prod in lstProdListPrice)
                //{
                //    lstProducts.Add(new ProductsDTO()
                //    {
                //        ProdId = prod.ProductID,
                //        ProdName = prod.Name,
                //        ProdNum = prod.ProductNumber,
                //        ProdListPrice = prod.ListPrice,
                //    });
                //}
                return lstProducts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ProductsDTO> FetchProductsMaxMin(int from, int to)
        {
            try
            {

                SqlCommand conOb = new SqlCommand(@"select Name, ProductId, Color from [Production].[Product] where listPrice>" + from + "and ListPrice<" + to, conObj);
                conObj.Open();
                SqlDataReader dept = conOb.ExecuteReader();

                List<ProductsDTO> lsProduct = new List<ProductsDTO>();
                while (dept.Read())
                {
                    ProductsDTO deptDTO = new ProductsDTO();
                    deptDTO.ProdName = dept["Name"].ToString();
                    deptDTO.ProdNum = dept["Num"].ToString();
                    lsProduct.Add(deptDTO);
                }
                return lsProduct;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conObj.Close();
            }
        }
    }
}
