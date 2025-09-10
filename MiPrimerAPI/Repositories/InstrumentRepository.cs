namespace MiPrimerAPI.Repositories
{
    public class InstrumentRepository
    {
        public static List<string> Instruments { get; set; }
        
        static InstrumentRepository()
        { 
            Instruments = new List<string>
            {
                "Guitarra",
                "Batería",
                "Piano"
            };
        }
    }
}
