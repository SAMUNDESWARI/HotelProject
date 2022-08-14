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
       

        Task<List<informationvm>> gethotel( string City);
        Task<List<informationvm>> getallhotel();
        Task<customerVM> postcustinfo(customerVM cust);
        Task<List<customerVM>> getallcust();
        Task<List<availvm>> getbyavailable(DateTime Check_IN, DateTime Check_Out, string City);
        Task<reservationvm> postreserve(reservationvm reservation);
    }
}
