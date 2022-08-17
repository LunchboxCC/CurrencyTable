using AutoMapper;
using CurrencyTable.Models;
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
