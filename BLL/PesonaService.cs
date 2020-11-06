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

        public int BuscarxIdentificacion(string identificacion)
        {
            return _repositorio.BuscarPorIdentificacion(identificacion); ;
        }
        /*public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var persona = _repositorio.BuscarPorIdentificacion(identificacion);
                if (persona != null)
                {
                    _repositorio.Eliminar(persona);
                    _conexion.Close();
                    return ($"El registro {persona.Nombre} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }
        public Persona BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Persona persona = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return persona;
        }
        public int Totalizar()
        {
            return _repositorio.Totalizar();
        }
        public int TotalizarMujeres()
        {
            return _repositorio.TotalizarMujeres();
        }
        public int TotalizarHombres()
        {
            return _repositorio.TotalizarHombres();
        }*/
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
