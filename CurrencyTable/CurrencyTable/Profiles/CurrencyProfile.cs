using AutoMapper;
using CurrencyTable.Models.DTOs;
using CurrencyTable.Models.Entities;

namespace CurrencyTable.Profiles
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyDTO>();
        }
    }
}
