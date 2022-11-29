using SalesModel.DomainClasses.Enums;
using System;

namespace SalesModel.DomainClasses
{
	public class OrderViewModel
	{
		public DateTime OrderDate { get; set; }
		public OrderSource OrderSource { get; set; }
	}
}