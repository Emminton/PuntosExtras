﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PuntosExtra.Entidades
{
    public class Personas
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public Personas()
        {

        }
        public Personas(int personaId, string nombre)
        {
            PersonaId = personaId;
            Nombre = nombre;
        }
    }
}
