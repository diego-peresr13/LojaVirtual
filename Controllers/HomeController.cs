using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Models;
using LojaVirtual.Libraries.Email;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

            // return new ContentResult(){ Content = string.Format("Dados recebidos com sucesso! <br/> Nome:{0} <br/> Email: {1} <br/> Texto:{2}", contato.nome, contato.email, contato.texto),ContentType="text/html"};
            try
            {
                contato.nome = HttpContext.Request.Form["nome"];
                contato.email = HttpContext.Request.Form["email"];
                contato.texto = HttpContext.Request.Form["texto"];

                /* Pega as mensagens de validação, conforme definido no modelo */
                var listaMensagem = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool isValid = Validator.TryValidateObject(contato, contexto, listaMensagem, true);

                /* Se for valido, será enviado o email */
                if (isValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Mensagem enviada com sucesso!";
                }
                else
                {
                    ViewData["CONTATO"] = contato;
                    StringBuilder sb = new StringBuilder();
                    foreach(var i in listaMensagem){
                        sb.Append(i.ErrorMessage + "<br/>");
                    }

                    ViewData["MSG_E"] = sb.ToString();
                }


            }
            catch (Exception ex)
            {
                ViewData["MSG_E"] = "Ocorreu um erro ao tentar enviar, Tente novamente mais tarde! " + ex.Message;
            }

            //TODO - implmentar log

            return View("Contato");
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
