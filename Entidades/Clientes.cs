using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WaoCellDominicana_ProyectoFinal_Ap1.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string EstadoCivil { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string  Celular { get; set; }
        public char Sexo { get; set; }

    }
}