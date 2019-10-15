using System;
using System.Net;
using System.Net.Mail;
using LojaVirtual.Models;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            string msgErro;
            string remetenteEmail = "diegov.peresr13@gmail.com"; //O e-mail do remetente
            MailMessage mail = new MailMessage();
            mail.To.Add("diegov.peresr13@gmail.com");
            mail.From = new MailAddress(remetenteEmail, "Diego Peres", System.Text.Encoding.UTF8);
            mail.Subject = "Contato - Loja Virtual - Email:" + contato.email;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            string Msg = string.Format("<h2>Contato - Loja Virtual</h2>" +
            "<b>Nome: {0} <br/>" +
            "<b>Email: {1} <br/>" +
            "<b>Texto: {2} <br/>" +
            "<br/> Email enviado automaticamento LojaVirtual - Favor não responder",
            contato.nome, contato.email, contato.texto);
            mail.Body = Msg;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            // mail.Priority = MailPriority.High; //Prioridade do E-Mail
            SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:
            client.Credentials = new System.Net.NetworkCredential(remetenteEmail, "floquinho2012");
            client.Port = 587;
            client.Host = "smtp.gmail.com"; //Definindo o provedor que irá disparar o e-mail
            client.EnableSsl = true; //Gmail trabalha com Server Secured Layer      

            // try
            // {
                client.Send(mail);
            // }
            // catch (Exception ex)
            // {
            //     msgErro = "Ocorreu um erro ao enviar:" + ex.Message;
            // }   
        }

    }
}