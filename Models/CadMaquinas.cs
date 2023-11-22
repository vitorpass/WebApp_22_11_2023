using System.ComponentModel.DataAnnotations;

namespace WebApp_22_11_2023.Models
{
    public class CadMaquinas
    {
        [Key]

        public int id_maquina { get; set; }

        public string nome_maquina { get; set; }

        public string tipo_maquina { get; set; }

        public string status_maquina { get; set; }
    }
}
