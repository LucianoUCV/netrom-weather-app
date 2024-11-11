using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NetRom.Weather.Application.Models;
using NetRom.Weather.Application.Services;
using NetRom.Weather.Core.Entities;

namespace NetRom.Weather.Application.Profiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CityModelForCreation, City>().ReverseMap();
        CreateMap<City, CityModel>().ReverseMap();
    }
}

