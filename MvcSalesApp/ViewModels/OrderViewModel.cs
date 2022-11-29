using SalesModel.DomainClasses.Enums;
using System;

namespace SalesModel.DomainClasses
{
	public class OrderViewModel
	{
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public OrderSource OrderSource { get; set; }
		public int CustomerId { get; set; }
	}
}