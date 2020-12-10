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
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int ProveedorId { get; set; }
        public float NCF { get; set; }
        public decimal Total { get; set; } = 0;

        [ForeignKey("CompraId")]
        public List<ComprasDetalles> ComprasDetalles { get; set; } = new List<ComprasDetalles>(); 
        
        [ForeignKey("ProveedorId")]
        public virtual Proveedores Proveedores { get; set; }
    }
}