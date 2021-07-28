using AutoMapper;
using SehirRehberiAPI.Dtos;
using SehirRehberiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberiAPI.Helper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityForListDto>()
                .ForMember(dest=>dest.PhotoUrl, opt=> {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                });

            CreateMap<City, CityForDetailDto>();

            CreateMap<Photo, PhotoForCreationDto>();
            CreateMap<PhotoForReturnDto, Photo>();
        }
    }
}
