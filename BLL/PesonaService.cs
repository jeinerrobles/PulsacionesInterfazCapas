using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class PesonaService
    {
        private readonly PersonaRepository _repositorio;
        public PesonaService()
        {
            _repositorio = new PersonaRepository();
        }
        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                persona.CalcularPulsaciones();
                _repositorio.Guardar(persona);
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public List<Persona> ConsultarTodos()
        {
            List<Persona> personas = _repositorio.ConsultarTodos();
            return personas;
        }

        public int ValidarExiste(string identificacion)
        {
            return _repositorio.ValidarExiste(identificacion); ;
        }

        public Persona ConsultarPersona(string identificaion)
        {
            return _repositorio.ConsultarPersona(identificaion);
        }

        public void Modificar(Persona persona)
        {
            _repositorio.Modificar(persona);
        }

        public List<Persona> Mujeres()
        {
            return _repositorio.Mujeres();
        }

        public List<Persona> Hombres()
        {
            return _repositorio.Hombres();
        }

        public void EliminarPersona(string identificacion)
        {
            _repositorio.EliminarPersona(identificacion);
        }
    }
    public class GuardarPersonaResponse
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
}
