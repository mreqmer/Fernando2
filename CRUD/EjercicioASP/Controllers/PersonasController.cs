using ENT;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using EjercicioASP.Models.VM;
using EjercicioASP.Models;

namespace EjercicioASP.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index()
        {
            try
            {
                ListadoPersonasConDeptVM vm = new ListadoPersonasConDeptVM();
                return View(vm.PersonasConDept);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            ClsPersona p = new ClsPersona();
            List<ClsDepartamento> departamentos = new List<ClsDepartamento>();
            p = ClsManejadoraBL.findPersonaBl(id);
            departamentos = ClsListadosBL.ObtieneListadoDepartamentosBl();

            PersonaConDeptModel personaDept = new PersonaConDeptModel(p, departamentos);


            return View(personaDept);
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            PersonaConListaDepartamento personaDept = new PersonaConListaDepartamento();

            return View(personaDept);
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClsPersona p)
        {
            try
            {
                ClsManejadoraBL.newPersonaBl(p);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View("Error");
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            ClsPersona persona;
            PersonaConListaDepartamento personaListaDept;
            try
            {
                persona = ClsManejadoraBL.findPersonaBl(id);
                personaListaDept = new PersonaConListaDepartamento(persona);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(personaListaDept);
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditCompleto(ClsPersona p)
        {

            try
            {
                ClsManejadoraBL.updatePersonaBl(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ClsPersona p = new ClsPersona();
                p = ClsManejadoraBL.findPersonaBl(id);
                List<ClsDepartamento> listaDepartamentos = new List<ClsDepartamento>();
                listaDepartamentos = ClsListadosBL.ObtieneListadoDepartamentosBl();
                PersonaConDeptModel personaDept = new PersonaConDeptModel(p, listaDepartamentos);
                return View(personaDept);
            }
            catch
            {
                return View("Error");
            }
           
            
            
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                ClsManejadoraBL.borrarPersonaBl(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
