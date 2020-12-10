using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WaoCellDominicana_ProyectoFinal_Ap1.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}