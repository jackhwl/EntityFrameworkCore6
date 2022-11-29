using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesModel.DomainClasses
{
	public class CustomerViewModel
	{
		public CustomerViewModel()
		{
			Orders = new List<OrderViewModel>();
		}
		public int CustomerId { get; set; }
		public string Name { get; set; }
		public int OrderCount { get; set; }
		public List<OrderViewModel> Orders { get; set; }
	}
}