using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Models;
using LojaVirtual.Libraries.Email;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            Contato contato = new Contato();
            contato.nome = HttpContext.Request.Form["nome"];
            contato.email = HttpContext.Request.Form["email"];
            contato.texto = HttpContext.Request.Form["texto"];
            ContatoEmail.EnviarContatoPorEmail(contato);
            return new ContentResult(){ Content = string.Format("Dados recebidos com sucesso! <br/> Nome:{0} <br/> Email: {1} <br/> Texto:{2}", contato.nome, contato.email, contato.texto),ContentType="text/html"};
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
