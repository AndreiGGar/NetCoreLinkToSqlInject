using Microsoft.AspNetCore.Mvc;
using NetCoreLinkToSqlInject.Models;

namespace NetCoreLinkToSqlInject.Controllers
{
    public class CochesController : Controller
    {
        /*private Coche car;*/
        private ICoche car;

        public CochesController(ICoche car)
        {
            this.car = car;
        }

        public IActionResult Index()
        {
            return View(this.car);
        }

        [HttpPost]
        public IActionResult Index(string accion)
        {
            if(accion.ToLower() == "acelerar")
            {
                this.car.Acelerar();
            } else
            {
                this.car.Frenar();
            }
            return View(this.car);
        }
    }
}
