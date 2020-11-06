using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class PersonaRepository
    {
        
        private readonly List<Persona> _personas = new List<Persona>();
        public PersonaRepository()
        {
            
        }
        public void Guardar(Persona persona)
        {
            _personas.Add(persona);
        }

        public List<Persona> ConsultarTodos()
        {
            return _personas;
        }
        public int ValidarExiste(string identificacion)
        {
            return _personas.Where(p => p.Identificacion.Equals(identificacion)).Count();
        }

        public Persona ConsultarPersona(string identificaion)
        {
            foreach(Persona p in _personas)
            {
                if (p.Identificacion.Equals(identificaion))
                {
                    return p;
                }
            }
            return null;
        }

        public void EliminarPersona(string identificacion)
        {
            Persona personaEncontrada = ConsultarPersona(identificacion);
            _personas.Remove(personaEncontrada);
        }
       
        public int TotalizarHombres()
        {
            ConsultarTodos();
            return _personas.Where(p => p.Sexo.Equals("M")).Count();
        }
    }
}
