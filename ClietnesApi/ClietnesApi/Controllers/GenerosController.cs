using AutoMapper;
using ClientesAPI.DTOs;
using ClientesAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesAPI.Controllers
{
    [ApiController]
    [Route("api/generos")] //Ruta
    public class GenerosController: ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDBContext context,
            IMapper mapper)//Agremos controlador de Generos con Immapper
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genero>>> Get() //Llamos asynconamente con resultado de Genero
        {
            var entidades = await context.Generos.ToListAsync();
            var dtos = mapper.Map<List<GeneroDTO>>(entidades);
            return dtos;
        }
    }
}

//Paquetes a installar:
// -  AutoMapper.Extensions.Microsoft.DependencyInjection
// - 
// - 
// - 
// - 
// - 
// - 
// - 