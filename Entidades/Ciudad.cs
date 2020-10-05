using System.ComponentModel.DataAnnotations;
using System;

namespace Diego_P1_AP1.Entidades
{
    

public class Ciudad{
        [Key]
        public int CiudadId { get; set; }

        public string Nombre { get; set; }

    }

}