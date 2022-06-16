using ApiAgenceTeste.ServicesLayer.DTO;
using ApiAgenceTeste.ServicesLayer.Mappers;
using BackEndPortafolioTarjeta.BusinessLayer.Command.Consultor;
using BackEndPortafolioTarjeta.BusinessLayer.Command.UserCreditCard;
using BackEndPortafolioTarjeta.BusinessLayer.Factory;
using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Models;
using BackEndPortafolioTarjeta.ServicesLayer.DTO;
using BackEndPortafolioTarjeta.ServicesLayer.Factory;
using BackEndPortafolioTarjeta.ServicesLayer.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndPortafolioTarjeta.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class TarjetaController : ControllerBase
    //{
    //    //Coloco este atributo private y readonly
    //    private readonly ApplicationDbContext _context;

    //    //Igualo la instanciasion anterior a la nueva declarada
    //    public TarjetaController(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET api/Tarjeta/GetTarjetas
    //    [HttpGet]
    //    [Route("GetUsers")]
    //    public async Task<IActionResult> GetTarjetas()
    //    {
    //        try
    //        {
    //            /*  var tarjetas = await _context.TarjetaCredito.ToListAsync();
    //             return Ok(tarjetas);*/
    //            //GetAllUserCreaditCardCommmand comando = CommandFactory.GetAllUserCreaditCardCommmand();
    //            //comando.Excute();

    //            GetAllConsultores comando = CommandFactory.GetAllConsultores();
    //            comando.Excute();

    //            List<Entity> _ListaTarjetas = comando.GetEntities();

    //            ConsultorMapper traductor = MapperFactory.CreateConsultorMapper();
    //            List<DTOConsultor> dto = traductor.CrearListaDto(_ListaTarjetas);

    //            //retornando resultados
    //            return Ok(dto);

    //        }
    //        catch (Exception e)
    //        {
    //            return BadRequest(e.Message);
    //        }

    //    }

    //    // GET api/Tarjeta/GetTarjetas
    //    [HttpPost]
    //    [Route("GetReceitasUser")]
    //    public async Task<IActionResult> GetReceitasUser([FromBody] List<DTOConsultor> _tarjetaEnviada)
    //    {
    //        try
    //        {

    //            ConsultorMapper _Mapper = MapperFactory.CreateConsultorMapper();
    //            List<Entity> _entityList= _Mapper.CrearListaEntidades(_tarjetaEnviada);

    //            GetReceitasCommand comando = CommandFactory.GetReceitasCommand(_entityList);
    //            comando.Excute();

    //            List<Entity> _ListaTarjetas = comando.GetEntities();

    //            ConsultoresConsultadosMapper traductor = MapperFactory.CreateConsultoresConsultadosMapper();
    //            List<DTOConsultoresConsultados> dto = traductor.CrearListaDto(_ListaTarjetas);

    //            //retornando resultados
    //            return Ok(dto);

    //        }
    //        catch (Exception e)
    //        {
    //            return BadRequest(e.Message);
    //        }

    //    }

    //    // GET api/<TarjetaController>/5
    //    [HttpGet("{id}")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/<TarjetaController>
    //    [HttpPost]
    //    [Route("PostTarjetas")]
    //    public async Task<IActionResult> Post([FromBody] DTOUserCreditCard _tarjetaEnviada)
    //    {
    //        try
    //        {
    //            //_context.Add(_tarjetaEnviada);
    //            //await _context.SaveChangesAsync();
    //            //return Ok(_tarjetaEnviada);

    //            UserCreaditCardMapper _Mapper = MapperFactory.CreateUserCreaditCardMapper();
    //            Entity _CreditCard = _Mapper.CrearEntidad(_tarjetaEnviada);

    //            AddUserCredictCardCommand _command = CommandFactory.AddUserCredictCardCommand(_CreditCard);
    //            _command.Excute();

    //            return Ok();

    //        }
    //        catch (Exception e)
    //        {

    //            return BadRequest(e.Message);
    //        }

    //    }

    //    // PUT api/<TarjetaController>/5
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> Put(int id, [FromBody] DTOUserCreditCard _actTarjeta)
    //    {
    //        try
    //        {
    //            UserCreaditCardMapper _mapper = MapperFactory.CreateUserCreaditCardMapper();
    //            Entity _credit = _mapper.CrearEntidad(_actTarjeta);

    //            RefreshUserCreditCardCommand _command = CommandFactory.RefreshUserCreditCardCommand(_credit);
    //            _command.Excute();

    //            return Ok();
    //        }
    //        catch (Exception e )
    //        {

    //            return BadRequest(e.Message);
    //        }


    //        /*try
    //        {
    //            if (id != _actTarjeta.id)
    //            {
    //                return NotFound();
    //            }

    //            _context.Update(_actTarjeta);
    //            await _context.SaveChangesAsync();
    //            return Ok( new {message = "Tarjeta Actualizada!"});

    //        }
    //        catch (Exception e)
    //        {

    //            return BadRequest(e.Message);
    //        }
    //        */

    //    }

    //    // DELETE api/<TarjetaController>/5
    //    [HttpPut("Delete")]
    //    public async Task<IActionResult> Delete([FromBody] DTOUserCreditCard _actTarjeta)
    //    {
    //        try
    //        {
    //            UserCreaditCardMapper _mapper = MapperFactory.CreateUserCreaditCardMapper();
    //            Entity _entity = _mapper.CrearEntidad(_actTarjeta);

    //            DeleteUserCreditCardCommand _command = CommandFactory.DeleteUserCreditCardCommand(_entity);
    //            _command.Excute();

    //            return Ok();

    //        }
    //        catch (Exception e)
    //        {

    //            return BadRequest(e.Message);
    //        }


    //        /*
    //        try
    //        {
    //            var findTarjeta = await _context.TarjetaCredito.FindAsync(id);

    //            if (findTarjeta == null)
    //            {
    //                return NotFound();
    //            }
    //            _context.TarjetaCredito.Remove(findTarjeta);
    //            await _context.SaveChangesAsync();
    //            return Ok(new { message = "Tarjeta Eliminada con exito!" });
    //        }
    //        catch (Exception e)
    //        {

    //            return BadRequest(e.Message);
    //        }
    //        */
    //    }
    //}
}
