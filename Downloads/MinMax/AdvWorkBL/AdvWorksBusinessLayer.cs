using AdvWorksDAL;
using AdvWorksDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvWorksBL
{
    public class AdvWorksBusinessLayer
    {
        AdvWorksDataAccessLayer dalObj;
        public AdvWorksBusinessLayer()
        {
            dalObj = new AdvWorksDataAccessLayer();
        }
        public int ConnectToDB()
        {
            try
            {
                AdvWorksDataAccessLayer dalObj = new AdvWorksDataAccessLayer();
                return dalObj.ConnectionToDB();
            }
            catch (Exception ex)
            {
                return -89;
            }
        }
        
        
        public List<ProductsDTO> FetchAllProductsUsingEF()
        {
            List<ProductsDTO> prodLstFromDAL = dalObj.FetchProductsListUsingEF();
            return prodLstFromDAL;
        }

        public List<ProductsDTO> FetchProductsMaxMin()
        {
            List<ProductsDTO> lsProduct = new List<ProductsDTO>();
            return lsProduct;
        }
        
    }
}
