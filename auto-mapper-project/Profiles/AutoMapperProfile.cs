using auto_mapper_project.Dto;
using auto_mapper_project.DTO;
using auto_mapper_project.Models;
using AutoMapper;

namespace auto_mapper_project.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<LivroModel, LivroVisualizacaoDTO>();
            CreateMap<CriarLivrosDTO, LivroModel>();
        } 
    }
}
