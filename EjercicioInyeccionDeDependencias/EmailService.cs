namespace EjercicioInyeccionDeDependencias
{
    public class EmailService : IEmailService
    {
        public void Send(string email, string mensaje)
        {
            Console.WriteLine($"Enviando email a {email} con el mensaje: {mensaje}");
        }
    }
}
