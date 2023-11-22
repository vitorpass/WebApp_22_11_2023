using System.ComponentModel.DataAnnotations;

namespace WebApp_22_11_2023.Models
{
    public class CadClientes
    {
        [Key]

        public int id_cliente { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }
    }
}
