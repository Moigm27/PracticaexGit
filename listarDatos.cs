using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practicaex
{
    internal class listarDatos
    {

        private nodo cabeza;

        public listarDatos()
        {
            this.cabeza = null;
        }

        public nodo getCabeza()
        {
            return this.cabeza;
        }

        public listarDatos insertarCabeza(persona p)
        {
            nodo nuevo = new nodo();
            nuevo.setPersona(p);
            nuevo.setSiguiente(cabeza);
            cabeza = nuevo;
            return this;
        }

        public listarDatos insertarAlFinal(persona p)
        {
            nodo nuevo = new nodo();
            nuevo.setPersona(p);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                nodo aux = cabeza;
                while (aux.GetSiguiente() != null)
                {
                    aux = aux.GetSiguiente();
                }
                aux.setSiguiente(nuevo);
            }
            return this;
        }
        public listarDatos insertarMedio(nodo anterior, persona p)
        {
            nodo nuevo = new nodo();
            nuevo.setPersona(p);
            nuevo.setSiguiente(anterior.GetSiguiente());
            anterior.setSiguiente(nuevo);
            return this;
        }
    }
}
