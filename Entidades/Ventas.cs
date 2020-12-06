using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaoCellDominicana_ProyectoFinal_Ap1.Entidades
{
    public class Ventas
   /* {
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public float NCF { get; set; }
        public int ITBIS { get; set; }
        //public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> VentasDetalle { get; set; } = new List<VentasDetalle>();

        [ForeignKey("ClienteId")]
        public virtual Clientes Clientes { get; set; }
    }
}