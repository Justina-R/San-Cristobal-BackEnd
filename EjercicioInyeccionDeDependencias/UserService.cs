namespace EjercicioInyeccionDeDependencias
{
    public class UserService
    {

        private readonly IEmailService emailService;

        public UserService(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public void NotifyUser(string email)
        {

            emailService.Send(email, "Notificación");

        }
    }
}
