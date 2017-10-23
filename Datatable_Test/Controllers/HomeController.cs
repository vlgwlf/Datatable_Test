using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datatable_Test.Models;

namespace Datatable_Test.Controllers
{
    public class HomeController : Controller
    {
        [Route("Main")]
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            using (Empresa2Entities Obj_Connection = new Empresa2Entities())
            {
                var empleados = Obj_Connection.Departamentoes.OrderBy(a => a.Num_Empleado).ToList();
                return Json(new { data = empleados}, JsonRequestBehavior.AllowGet);
            }
        }


        //CRUD Operations
        [HttpGet]
        public ActionResult Save(int id)
        {
            using (Empresa2Entities Obj_Connection = new Empresa2Entities())
            {
                var v = Obj_Connection.Departamentoes.Where(a => a.Num_Empleado == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Departamento empleado)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (Empresa2Entities Obj_Connection = new Empresa2Entities())
                {
                    if (empleado.Num_Empleado > 0)
                    {
                        //Edit
                        var v = Obj_Connection.Departamentoes.Where(a => a.Num_Empleado == empleado.Num_Empleado).FirstOrDefault();
                        if (v != null)
                        {
                            v.Nombre = empleado.Nombre;
                            v.Fecha_Creacion = empleado.Fecha_Creacion;
                        }
                    }
                    else
                    {
                        //Save
                        Obj_Connection.Departamentoes.Add(empleado);
                    }
                    Obj_Connection.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (Empresa2Entities Obj_Connection = new Empresa2Entities())
            {
                var v = Obj_Connection.Departamentoes.Where(a => a.Num_Empleado == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmpleado(int id)
        {
            bool status = false;
            using (Empresa2Entities Obj_Connection = new Empresa2Entities())
            {
                var v = Obj_Connection.Departamentoes.Where(a => a.Num_Empleado == id).FirstOrDefault();
                if (v != null)
                {
                    Obj_Connection.Departamentoes.Remove(v);
                    Obj_Connection.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}