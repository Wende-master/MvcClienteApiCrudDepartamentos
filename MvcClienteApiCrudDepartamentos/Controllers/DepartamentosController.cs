using Microsoft.AspNetCore.Mvc;
using MvcClienteApiCrudDepartamentos.Models;
using MvcClienteApiCrudDepartamentos.Services;

namespace MvcClienteApiCrudDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        private ServiceApiDepartamentos service;

        public DepartamentosController(ServiceApiDepartamentos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.service.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int iddepartamento)
        {
            Departamento departamento = await this.service.FindDepartamentoAsync(iddepartamento);
            return View(departamento);
        }
        public async Task<IActionResult> DeleteDepartamento(int iddepartamento)
        {
            await this.service.DeleteDepartamentoAsync(iddepartamento);
            return RedirectToAction("Index");
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(/*int iddepartamento, */string nombre, string localidad)
        {
            await this.service.InsertDepartamentoAsync(/*iddepartamento*/nombre, localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int iddepartamento)
        {
            Departamento departamento = await this.service.FindDepartamentoAsync(iddepartamento);
            return View(departamento);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Departamento departamento)
        {
            await this.service.UpdateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Cliente()
        {
            return View();
        }
    }
}
