using hotelRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelRepository.Interface
{
    public interface IhotelRepository
    {
      
        Task<List<Hotel>> gethotel(string City);
        Task<List<Hotel>> getallhotel();

        Task<CustInfo> postcustinfo(CustInfo cust);
        Task<List<CustInfo>> getallcust();
    }
}
