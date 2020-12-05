using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WaoCellDominicana_ProyectoFinal_Ap1.Entidades
{
    public class ComprasDetalles
    {
        [Key]
        public int ComprasDetalleId { get; set; }
        public int CompraId { get; set; }
        public int ArticuloId { get; set; }
        public string Decripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Importe { get; set; }   

    }
}