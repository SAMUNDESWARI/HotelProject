using hotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace hotelBussiness.Interface
{
    public interface IhotelBusiness
    {
       // Task getallcust();
       

        Task<List<hotelInfo>> gethotel(string City);
        Task<List<hotelInfo>> getallhotel();
    }
}
