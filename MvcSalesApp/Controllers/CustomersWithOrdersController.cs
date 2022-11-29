using MvcSalesApp.Data;
using MvcSalesApp.Domain;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MvcSalesApp.Web.Controllers
{
	public class CustomersWithOrdersController : Controller
    {
        private OrderSystemContext db = new OrderSystemContext();

        // GET: CustomersWithOrders
        public ActionResult Index()
        {
            var custs = db.Customers.AsNoTracking()
                .Select(c => new CustomerViewModel
                {
                    CustomerId = c.CustomerId,
                    Name = c.FirstName + " " + c.LastName,
                    OrderCount = c.Orders.Count()
                })
                .ToList();
            return View(custs);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cust = db.Customers.AsNoTracking()
                .Select(c => new CustomerViewModel
                {
                    CustomerId = c.CustomerId,
                    Name = c.FirstName + " " + c.LastName,
                    OrderCount = c.Orders.Count(),
                    Orders = c.Orders.Select(
                    o => new OrderViewModel
                    {
                        OrderSource = o.OrderSource,
                        CustomerId = o.CustomerId,
                        OrderDate = o.OrderDate
                    }).ToList()
                })
                .FirstOrDefault(c => c.CustomerId == id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }
    }
}