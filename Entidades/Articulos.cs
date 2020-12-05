using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WaoCellDominicana_ProyectoFinal_Ap1.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; }
        public string Decripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Minimo { get; set; }
        public decimal Garantia { get; set; }
    }
}