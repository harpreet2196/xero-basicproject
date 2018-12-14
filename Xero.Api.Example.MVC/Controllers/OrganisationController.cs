using System.Web.Mvc;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Example.MVC.Helpers;

namespace Xero.Api.Example.MVC.Controllers
{
    public class OrganisationController : Controller
    {
        public ActionResult Index()
        {
            var api = XeroApiHelper.CoreApi();

            //var api1 = XeroApiHelper.User();

            try
            {
                var organisation = api.Organisation;

                
                //var updated_emp = api.Update(new Employee
                //{
                //    Id = emp.Id,
                //    Status = Xero.Api.Payroll.Australia.Model.Status.EmploymentStatus.Terminated,
                //    TerminationDate = DateTime.Now.AddDays(-1)

                //});



                return View(organisation);
            }
            catch (RenewTokenException e)
            {
                return RedirectToAction("Connect", "Home");
            }   
        }
    }
}
