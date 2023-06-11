﻿using AutoMapper;
using ClientesAPI.DTOs;
using ClientesAPI.Entidades;
using ClientesAPI.Migrations;
using ClientesAPI.Servicios;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesAPI.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "peliculas";

        public PeliculasController(ApplicationDBContext context,
            IMapper mapper,
            IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<List<PeliculaDTO>>> Get()
        {
            var peliculas = await context.Peliculas.ToListAsync();
            return mapper.Map<List<PeliculaDTO>>(peliculas);
        }

        [HttpGet("{id}", Name = "obtenerPelicula")]
        public async Task<ActionResult<PeliculaDTO>> Get(int id)
        {
            var pelicula = await context.Peliculas.FirstOrDefaultAsync(x => x.Id == id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return mapper.Map<PeliculaDTO>(pelicula);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PeliculaCreacionDTO peliculaCreacionDTO)
        {

            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);

            return Ok();

            //var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);

            //if (peliculaCreacionDTO.Poster != null)
            //{
            //    using (var memoryStream = new MemoryStream())
            //    {
            //        await peliculaCreacionDTO.Poster.CopyToAsync(memoryStream);
            //        var contenido = memoryStream.ToArray();
            //        var extension = Path.GetExtension(peliculaCreacionDTO.Poster.FileName);
            //        pelicula.Poster = await almacenadorArchivos.GuardarArchivo(contenido, extension, contenedor,
            //            peliculaCreacionDTO.Poster.ContentType);
            //    }
          //  }

            //context.Add(pelicula);
            //await context.SaveChangesAsync();
            //var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);
            //return new CreatedAtRouteResult("obtenerPelicula", new { id = pelicula.Id }, peliculaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromForm] PeliculaCreacionDTO peliculaCreacionDTO)
        {
           

            var peliculaDB = await context.Peliculas.FirstOrDefaultAsync(x => x.Id == id);

            if (peliculaDB == null) { return NotFound(); }

            peliculaDB = mapper.Map(peliculaCreacionDTO, peliculaDB);

            if (peliculaCreacionDTO.Poster != null)
            {
                using var memoryStream = new MemoryStream();
                await peliculaCreacionDTO.Poster.CopyToAsync(memoryStream);
                var contenido = memoryStream.ToArray();
                var extension = Path.GetExtension(peliculaCreacionDTO.Poster.FileName);
                peliculaDB.Poster = await almacenadorArchivos.EditarArchivo(contenido, extension, contenedor,
                    peliculaDB.Poster,
                    peliculaCreacionDTO.Poster.ContentType);

            }

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<PeliculaPatchDTO> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var entidadDB = await context.Peliculas.FirstOrDefaultAsync(x => x.Id == id);
            if (entidadDB == null)
            {
                return NotFound();
            }

            var entidadDTO = mapper.Map<PeliculaPatchDTO>(entidadDB);
            patchDocument.ApplyTo(entidadDTO, ModelState);

            var esValido = TryValidateModel(entidadDTO);

            if (!esValido)
            {
                return BadRequest(ModelState);
            }

            mapper.Map(entidadDTO, entidadDB);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Peliculas.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Pelicula() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
