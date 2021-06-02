
namespace PortableAPI.Mapper
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using RepositoryLayer.Context;
    using ServiceLayer.Models;

    /// <summary>
    /// Class MappingProfile
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor of MappingProfile 
        /// </summary>
        public MappingProfile()
        {
            NewsMapper();
        }

        private void NewsMapper()
        {            
            CreateMap<PinArticleDTO, PinArticle>().ReverseMap();
            CreateMap<GuardianData, NewsData>()
                .ForMember(x => x.WebPublicationDate, opt => opt.MapFrom(src => src.WebPublicationDate.ToString("dd/MM/yyyy"))).ReverseMap();
        }
    }
}