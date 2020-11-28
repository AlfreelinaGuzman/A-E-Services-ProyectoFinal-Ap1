using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WaoCellDominicana_ProyectoFinal_Ap1.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string NCF { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalITBIs { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("VentaId")]
        public List<VentasDetalles> Detalle { get; set; } = new List<VentasDetalles>(); 
        

    }
}