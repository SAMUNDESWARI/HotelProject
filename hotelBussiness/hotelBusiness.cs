using AutoMapper;
using hotelBussiness.Interface;
using hotelModels;
using hotelRepository.Interface;
using hotelRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelBussiness
{
   public class hotelBusiness : IhotelBusiness
    {
        private readonly IhotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public hotelBusiness(IhotelRepository hotelRepository, IMapper mapper)
        {

           _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

      
        public async Task<List<hotelInfo>> getallhotel()
        {
            var list1 = await _hotelRepository.getallhotel();
            return _mapper.Map<List<hotelInfo>>(list1);
        }

        public async Task<List<hotelInfo>> gethotel(string City)
        {
           var list1 = await _hotelRepository.gethotel(City);
            return _mapper.Map<List<hotelInfo>>(list1);
        }
    }
}
