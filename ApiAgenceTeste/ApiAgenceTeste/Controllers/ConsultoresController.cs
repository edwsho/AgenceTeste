using ApiAgenceTeste.ServicesLayer.DTO;
using ApiAgenceTeste.ServicesLayer.Mappers;
using BackEndPortafolioTarjeta;
using BackEndPortafolioTarjeta.BusinessLayer.Command.Consultor;
using BackEndPortafolioTarjeta.BusinessLayer.Factory;
using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.ServicesLayer.DTO;
using BackEndPortafolioTarjeta.ServicesLayer.Factory;
using BackEndPortafolioTarjeta.ServicesLayer.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgenceTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultoresController : ControllerBase
    {

        //Coloco este atributo private y readonly
        private readonly ApplicationDbContext _context;

        //Igualo la instanciasion anterior a la nueva declarada
        public ConsultoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/Tarjeta/GetTarjetas
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetTarjetas()
        {
            try
            {
                /*  var tarjetas = await _context.TarjetaCredito.ToListAsync();
                 return Ok(tarjetas);*/
                //GetAllUserCreaditCardCommmand comando = CommandFactory.GetAllUserCreaditCardCommmand();
                //comando.Excute();

                GetAllConsultores comando = CommandFactory.GetAllConsultores();
                comando.Excute();

                List<Entity> _ListaTarjetas = comando.GetEntities();

                ConsultorMapper traductor = MapperFactory.CreateConsultorMapper();
                List<DTOConsultor> dto = traductor.CrearListaDto(_ListaTarjetas);

                //retornando resultados
                return Ok(dto);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/Tarjeta/GetTarjetas
        [HttpPost]
        [Route("GetReceitasUser")]
        public async Task<IActionResult> GetReceitasUser([FromBody] List<DTOConsultor> _tarjetaEnviada)
        {
            try
            {

                ConsultorMapper _Mapper = MapperFactory.CreateConsultorMapper();
                List<Entity> _entityList = _Mapper.CrearListaEntidades(_tarjetaEnviada);

                GetReceitasCommand comando = CommandFactory.GetReceitasCommand(_entityList);
                comando.Excute();

                List<Entity> _ListaTarjetas = comando.GetEntities();

                ConsultoresConsultadosMapper traductor = MapperFactory.CreateConsultoresConsultadosMapper();
                List<DTOConsultoresConsultados> dto = traductor.CrearListaDto(_ListaTarjetas);

                //retornando resultados
                return Ok(dto);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        
    }
}
