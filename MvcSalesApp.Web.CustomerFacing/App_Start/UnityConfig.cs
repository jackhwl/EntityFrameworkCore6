using MvcSalesApp.Data;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MvcSalesApp.Web.CustomerFacing
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<DbContext, OrderSystemContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}