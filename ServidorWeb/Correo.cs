using System.Net.Mail;
public class Correos{
    public  string Destinatario{get;set;} = string.Empty;
    public string Asunto {get;set;} = string.Empty;
    public string Mensaje {get;set;} = string.Empty;
    public void Enviar(){
        MailMessage correo = new MailMessage();
    correo.From = new MailAddress("carlosdiaztovar94@gmail.com", null, System.Text.Encoding.UTF8);
    correo.To.Add(this.Destinatario); 
    correo.Subject = this.Asunto;
    correo.Body = this.Mensaje; 
    correo.IsBodyHtml = true;
    correo.Priority = MailPriority.Normal;
    SmtpClient smtp = new SmtpClient();
    smtp.UseDefaultCredentials = false;
    smtp.Host = "smtp.gmail.com"; 
    smtp.Port = 25;
    smtp.EnableSsl = true;
    smtp.Credentials = new System.Net.NetworkCredential("carlosdiaztovar94@gmail.com", "bkbg vlyb upeg euit");
    smtp.Send(correo);
    }
}
