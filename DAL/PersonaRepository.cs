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
        public void Eliminar(Persona persona)
        {
            
        }
        public List<Persona> ConsultarTodos()
        {
            return _personas;
        }
        public int BuscarPorIdentificacion(string identificacion)
        {
            return _personas.Where(p => p.Identificacion.Equals(identificacion)).Count();
        }
       
        public int TotalizarHombres()
        {
            ConsultarTodos();
            return _personas.Where(p => p.Sexo.Equals("M")).Count();
        }
    }
}
