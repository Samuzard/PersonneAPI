using AutoMapper;
using Microsoft.Extensions.Hosting;
using PersonneAPI.Model;
using PersonneAPI.Model.DTO;

namespace PersonneAPI.Utils
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Personne, PersonneDTO>().ReverseMap();
        }
    }
}
