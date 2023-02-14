using Microsoft.AspNetCore.Mvc;
using NetCoreLinkToSqlInject.Models;
using NetCoreLinkToSqlInject.Repositories;

namespace NetCoreLinkToSqlInject.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctorOracle repo;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctorOracle();
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }
        public IActionResult Delete(int id)
        {
            this.repo.DeleteDoctor(id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            this.repo.InsertDoctor(doctor.HOSPITAL_COD, doctor.APELLIDO, doctor.ESPECIALIDAD, doctor.SALARIO);
            ViewData["MENSAJE"] = "Departamento insertado";
            /*return View("Index");*/
            return RedirectToAction("Index");
        }
    }
}
