using System.ComponentModel.DataAnnotations;

namespace EjerciciosORM.Modelos
{
    public class Product
    {
        public string ProductName { get; set; }

        public int CategoryID { get; set; }

        [Key]

        public int ProductID { get; set; }

        public Category Category { get; set; } = null!;
    }
}
