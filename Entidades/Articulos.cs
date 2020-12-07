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
        public int ProveedorId { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }
        public string Decripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Garantia { get; set; }
        public decimal ITBIs { get; set; }
    }
}