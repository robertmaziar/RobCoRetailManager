using Microsoft.AspNet.Identity;
using RRMDataManager.Library.DataAccess;
using RRMDataManager.Library.Models;
using System.Web.Http;

namespace RRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        [HttpPost]
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData();
            string cashierId = RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, cashierId);
        }
    }
}
