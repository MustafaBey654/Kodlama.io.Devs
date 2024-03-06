using AutoMapper;
using Core.Persistence.Paging;
using Course.Application.Features.Languages.Commands.CreateLanguage;
using Course.Application.Features.Languages.Commands.DeletedLanguage;
using Course.Application.Features.Languages.Commands.UpdatedLanguage;
using Course.Application.Features.Languages.Dtos;
using Course.Application.Features.Languages.Models;
using Course.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.Languages.Profiles
{
    public class MappingProfiles:Profile
    {
        //Mappleme profilleri

        public MappingProfiles()
        {
            CreateMap<Language,CreatedLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();

            CreateMap<Language, DeletedLanguageCommand>().ReverseMap();
            CreateMap<Language, DeletedLanguageProgramingDto>().ReverseMap();

            CreateMap<Language, UpdatedLanguageProgramingDto>().ReverseMap();
            CreateMap<Language, UpdatedLanguageProgramingCommand>().ReverseMap();

            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
            CreateMap<Language,LanguageListDto>().ReverseMap();

            CreateMap<Language,LanguageGetByIdDto>().ReverseMap();

        }
    }
}
