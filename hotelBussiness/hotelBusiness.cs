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

        public async Task<List<hotelInfo>> everyhotel()
        {
            var list4 = await _hotelRepository.everyhotel();
            return _mapper.Map<List<hotelInfo>>(list4);
        }

        public async Task<List<customerVM>> getallcust()
        {
            var list2 = await _hotelRepository.getallcust();
            return _mapper.Map<List<customerVM>>(list2);
        }

        public async Task<List<informationvm>> getallhotel()
        {
            var list1 = await _hotelRepository.getallhotel();
            return _mapper.Map<List<informationvm>>(list1);
        }

        public async Task<List<availvm>> getbyavailable(DateTime Check_IN, DateTime Check_Out, string City)
        {
            var list3 = await _hotelRepository.getbyavailable( Check_IN, Check_Out,City);
            return _mapper.Map<List<availvm>>(list3);
        }

        public async Task<List<informationvm>> gethotel( string City)
        {
           var list1 = await _hotelRepository.gethotel(City);
            return _mapper.Map<List<informationvm>>(list1);
        }

        public async Task<customerVM> postcustinfo(customerVM cust)
        {
            var result = await _hotelRepository.postcustinfo(_mapper.Map<CustInfo>(cust));
            return _mapper.Map<customerVM>(result);
        }

        public async Task<reservationvm> postreserve(reservationvm reservation)
        {
            var res = await _hotelRepository.postreserve(_mapper.Map<Reservation>(reservation));
            return _mapper.Map<reservationvm>(res);
        }
    }
}
