using System.Web.Mvc;

namespace PetShop.Areas.Shipper
{
    public class ShipperAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Shipper";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Shipper_default",
                "Shipper/{controller}/{action}/{id}",
                new { Controller ="Login", action = "Index", id = UrlParameter.Optional },
                  namespaces: new string[] { "PetShop.Areas.Shipper.Controllers" }
            );
        }
    }
}