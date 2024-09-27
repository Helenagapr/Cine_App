using AutoMapper;
using CineApi.DTO;
using CineApi.Models;

namespace CineApi {

    public class MapConfig : Profile {

        public MapConfig() {

            CreateMap<Boleto, BoletoDTO>().ReverseMap();
            CreateMap<Boleto, CreateBoletoDTO>().ReverseMap();

            CreateMap<Butaca, ButacaDTO>().ReverseMap();
            CreateMap<Butaca, CreateButacaDTO>().ReverseMap();

            CreateMap<CategoriaEntrada, CategoriaEntradaDTO>().ReverseMap();
            CreateMap<CategoriaEntrada, CreateCategoriaEntradaDTO>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, CreateClienteDTO>().ReverseMap();

            CreateMap<Fila, FilaDTO>().ReverseMap();
            CreateMap<Fila, CreateFilaDTO>().ReverseMap();

            CreateMap<Funcion, FuncionDTO>().ReverseMap();
            CreateMap<Funcion, CreateFuncionDTO>().ReverseMap();

            CreateMap<Pelicula, PeliculaDTO>().ReverseMap();
            CreateMap<Pelicula, CreatePeliculaDTO>().ReverseMap();

            CreateMap<Sala, SalaDTO>().ReverseMap();
            CreateMap<Sala, CreateSalaDTO>().ReverseMap();
            
        }
    }
}


