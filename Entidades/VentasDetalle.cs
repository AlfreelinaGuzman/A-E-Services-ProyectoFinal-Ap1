using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WaoCellDominicana_ProyectoFinal_Ap1.Entidades
{
    public class VentasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ArticuloId { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Monto {get; set;}
        public decimal PorcientoItbis { get; set;}

    }
}