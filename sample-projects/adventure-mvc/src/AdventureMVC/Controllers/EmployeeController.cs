using System.Collections.Generic;
using System.Web.Mvc;
using AdventureMVC.Core.Services;
using System.Web.Routing;
using AdventureMVC.Core.Model;

namespace AdventureMVC.Controllers
{
    [HandleError]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController()
        {
        }

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        public ActionResult PTO(int? pageIndex)
        {
            var pageSize = 10;
//            ViewData.Model = service.GetEmployees(pageSize, pageIndex??0);
            ViewData.Model = _employeeService.GetAllEmployees().ToPagedList(pageIndex ?? 0, pageSize);
            return View();
        }

        public ActionResult Edit(int id)
        {
            //TODO: Handle bad employeeID gracefully.
            ViewData.Model = _employeeService.GetEmployee(id);
            return View("Edit");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update(int id)
        {
            Employee employee = _employeeService.GetEmployee(id);
            UpdateModel(employee);
            _employeeService.SaveEmployee(employee);

            TempData["OutputMessage"] = employee.FullName + " successfully updated!";
            return RedirectToAction("Edit", new RouteValueDictionary(new {id }));
        }
    }
}
