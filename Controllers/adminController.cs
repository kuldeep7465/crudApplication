using BootstraptemplateTesting.connect;
using BootstraptemplateTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstraptemplateTesting.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult login()
        {
            return View();
        }
        public ActionResult indexdasbord()
        {
            return View();
        }
        public ActionResult table()
        {
            mbvdatabaseEntities obj = new mbvdatabaseEntities();

            var rev = obj.mytables.ToList();
            return View(rev);
           
        }
        public ActionResult form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult form(Class1 obj1)
        {
            mbvdatabaseEntities obj = new mbvdatabaseEntities();
            mytable obj2 = new mytable();
            obj2.id = obj1.id;
            obj2.name = obj1.name;
            obj2.email = obj1.email;

            if (obj1.id == 0)
            {
                obj.mytables.Add(obj2);
                obj.SaveChanges();
            }
            else
            {
                obj.Entry(obj2).State = System.Data.Entity.EntityState.Modified;
                obj.SaveChanges();
            }
            return View();
        }
        public ActionResult delete(int id)
        {
            mbvdatabaseEntities obj = new mbvdatabaseEntities();
            var delete = obj.mytables.Where(x => x.id == id).First();
            obj.mytables.Remove(delete);
            obj.SaveChanges();
            return RedirectToAction("table");
        }
        public ActionResult edit(int id)
        {
            mytable edi = new mytable();
            mbvdatabaseEntities obj = new mbvdatabaseEntities();
            var edit = obj.mytables.Where(x => x.id == id).First();


            edi.name = edit.name;
            edi.email = edit.email;

            return View("form", edi);
        }
    }
}