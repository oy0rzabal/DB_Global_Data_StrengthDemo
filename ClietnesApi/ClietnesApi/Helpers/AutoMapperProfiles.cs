using AutoMapper;
using ClientesAPI.DTOs;
using ClientesAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap(); //Creamos el mapeogeneral sobre el genero de los Clientes.
        }
    }
}
