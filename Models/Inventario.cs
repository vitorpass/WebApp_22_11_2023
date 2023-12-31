﻿using System.ComponentModel.DataAnnotations;

namespace WebApp_22_11_2023.Models
{
    public class Inventario
    {
        [Key]

        public int id_inventario { get; set; }

        public int id_cliente { get; set; }

        public int id_maquina { get; set; }

        public int quantidade { get; set; }

        public DateTime data_aquisicao { get; set; }

        public decimal preco_unitario { get; set; }

        public string observacoes { get; set; }
    }
}
