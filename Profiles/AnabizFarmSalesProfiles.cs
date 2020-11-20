using System;
using AnabizFarmSales.Dtos;
using AnabizFarmSales.Modals;
using AutoMapper;

namespace AnabizFarmSales.Profiles
{
    public class AnabizFarmSalesProfile : Profile
    {
        public AnabizFarmSalesProfile()
        {
            //Source -> Target
            CreateMap<FarmSale, AnabizFarmSalesReadDto>();
            CreateMap<AnabizFarmSalesCreateDto, FarmSale>();

        }
    }
}
