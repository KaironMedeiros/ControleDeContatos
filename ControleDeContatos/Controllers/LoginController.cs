using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar seu login, tente novamente. Erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
