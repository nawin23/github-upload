using AdvWorksBL;
using AdvWorksDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdvWorksAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        AdvWorksBusinessLayer blObj;
        public DepartmentController()
        {
            blObj = new AdvWorksBusinessLayer();
        }
        [HttpGet]

        public HttpResponseMessage FetchProductsMaxMin()
        {
            try
            {
                List<ProductsDTO> lsProduct = new List<ProductsDTO>();
                if (lsProduct.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, lsProduct);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "No Dept Details");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
