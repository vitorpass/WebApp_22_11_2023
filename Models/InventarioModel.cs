using System.ComponentModel.DataAnnotations;

namespace WebApp_22_11_2023.Models
{
    public class InventarioModel : CadClientes
    {
        [Key]

        public int id_inventario { get; set; }

        public int id_cliente { get; set; }

        public int id_maquina { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string nome_maquina { get; set; }

        public string tipo_maquina { get; set; }

        public string status_maquina { get; set; }

        public int quantidade { get; set; }

        public DateTime data_aquisicao { get; set; }

        public decimal preco_unitario { get; set; }

        public string observacoes { get; set; }

        public List<CadClientes> clientes { get; set; }
        public List<CadMaquinas> maquinas { get; set; }
        public List<Inventario> inventario { get; set; }
    }
}
