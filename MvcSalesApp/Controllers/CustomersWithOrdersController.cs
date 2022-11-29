using MvcSalesApp.Data;
using System.Net;
using System.Web.Mvc;

namespace MvcSalesApp.Web.Controllers
{
	public class CustomersWithOrdersController : Controller
    {
        private CustomerWithOrdersData repo = new CustomerWithOrdersData();

        // GET: CustomersWithOrders
        public ActionResult Index()
        {
            return View(repo.GetAllCustomers());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cust = repo.FindCustomer(id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }
    }
}