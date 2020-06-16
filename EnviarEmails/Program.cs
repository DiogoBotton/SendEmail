using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EnviarEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite para quem quer enviar:");
            string emailDestinatario = Console.ReadLine();

            Console.WriteLine("Digite o Título do Email:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite a mensagem:");
            string mensagem = Console.ReadLine();

            Console.WriteLine("Confirme a senha do email remetente:");
            string senha = Console.ReadLine();

            Console.WriteLine("Aperte ENTER para enviar");
            Console.ReadLine();

            try
            {
                MailMessage mailMessage = new MailMessage("COLOQUE_SEU_EMAIL_REMETENTE_AQUI", emailDestinatario);

                mailMessage.Subject = $"{titulo}";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = $"<p> {mensagem} </p>";
                mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("COLOQUE_SEU_EMAIL_REMETENTE_AQUI", senha);

                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

                Console.WriteLine("Seu email foi enviado com sucesso! :)");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro no envio do email :(");
                Console.ReadLine();
            }
        }
    }
}
