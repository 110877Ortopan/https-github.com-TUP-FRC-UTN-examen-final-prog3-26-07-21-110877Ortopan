using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comandos.Vehiculos;
using FinalAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resultado;

namespace FinalAPI.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    public class VehiculoController : ControllerBase
    {
       
       private readonly VehiculosContext db = new VehiculosContext();

        private readonly ILogger<VehiculoController> _logger;

       public VehiculoController(ILogger<VehiculoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Vehiculo/ObtenerVehiculo/{Id}")]
        public ActionResult<ResultadoAPI> Get(int Id)
        {
           var resultado = new ResultadoAPI();

           try
           {
               var v = db.Vehiculos.Where(c => c.Id == Id).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = v;

                return resultado;
           }
           catch (Exception ex)
           {
                resultado.Ok = false;
                resultado.CodigoError = 1;
                resultado.Error = "Vehiculo no encontrado - " + ex.Message;

                return resultado;
               
           }
        }

         [HttpGet]
        [Route("Vehiculo/ObtenerVehiculo")]
        public ActionResult<ResultadoAPI> GetVehiculo()
        {
            var resultado = new ResultadoAPI();

           resultado.Ok = true;
           resultado.Return = db.Vehiculos.ToList();

           return resultado;
        }


         [HttpPut]
        [Route("Vehiculo/ActualizarVehiculo")]

        public ActionResult<ResultadoAPI> ActualizarVehiculo([FromBody]ComandoActualizarEstado comando)
        {
            //Validacion
            var resultado = new ResultadoAPI();
             if (comando.Modelo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese Modelo";

                return resultado;
            }

            if (comando.Color.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese Color";

                return resultado;
            }

             if (comando.Estado == true)
            {
                resultado.Ok = false;
                
                return resultado;
            }

            var veh = db.Vehiculos.Where(c => c.Id == comando.Id).FirstOrDefault();
            if (veh != null)
            {
                veh.Modelo= comando.Modelo;
                veh.Color = comando.Color;

                db.Vehiculos.Update(veh); 
                db.SaveChanges();

            }

            

            resultado.Ok = true;
            resultado.Return = db.Vehiculos.ToList();

            return resultado;
        }

       
        




    }
}
