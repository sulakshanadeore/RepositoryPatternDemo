using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Repository;
using RepositoryPatternDemo.Models;
namespace RepositoryPatternDemo.Controllers
{

    [Cors()]
    public class EmpController : Controller
    {
        // GET: Emp
        IRepository<Employee> _repository;
        public EmpController()
        {
            _repository = new Repository<Employee>();
        }
        public ActionResult Index()
        {

            var emplist = _repository.GetAll();
            return View();
        }


        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(emp);
                _repository.Save();
                return RedirectToAction("Index");
            }
            
            return View(emp);
        }

        public ActionResult Edit(int id)
        {

            Employee emp=_repository.GetByID(id);

            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {

            if (ModelState.IsValid)
            {
                _repository.Update(emp);
                _repository.Save();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public ActionResult Details(int id)
        {
            Employee emp = _repository.GetByID(id);
            return View(emp);
        }

        public ActionResult Delete(int id)
        {
            Employee emp = _repository.GetByID(id);
            return View(emp);
        }

        [HttpPost,ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Employee emp = _repository.GetByID(id);
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index");
        }


    }
}