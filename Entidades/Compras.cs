using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WaoCellDominicana_ProyectoFinal_Ap1.Entidades
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string NCF { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalITBIs { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("CompraId")]
        public List<ComprasDetalles> Detalle { get; set; } = new List<ComprasDetalles>(); 
        

    }
}