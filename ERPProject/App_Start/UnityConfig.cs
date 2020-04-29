using ERPProject.Services;
using ERPProject.Services.Implementation;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ERPProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IInventoryService, InventoryService>();
            container.RegisterType<IContractorService, ContractorService>();
            container.RegisterType<ILoginService, LoginService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}