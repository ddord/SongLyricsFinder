using AutoMapper;
using DomainBiz.DTO;
using DomainBiz.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainBiz.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LyricsInfoDto, LyricsInfo>();
            CreateMap<SongInfoDto, SongInfo>();
        }
        
    }
}
