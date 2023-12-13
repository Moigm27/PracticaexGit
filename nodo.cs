using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicaex
{
    internal class nodo
    {
        private nodo siguiente;

        private persona persona;
        public persona GetPersona() { return persona; }
        public nodo GetSiguiente() { return siguiente; }
        public void setPersona(persona p)
        {
            this.persona = p;
        }
        public void setSiguiente(nodo siguiente)
        {
            this.siguiente = siguiente;
        }
    }
}
