using hotelBussiness.Interface;
using hotelModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {   
        private readonly IhotelBusiness _hotelBusiness;

        public ValuesController(IhotelBusiness hotelBusiness)
        {
            _hotelBusiness = hotelBusiness;
        }

       
        [HttpGet("{City}")]
        public async Task<IActionResult> Getbycity(string City)
        {
            var car = await _hotelBusiness.gethotel(City);
            return Ok(car);
        }

        [HttpGet("hote")]
        public async Task<IActionResult> Gethotel()
        {
            var car = await _hotelBusiness.getallhotel();
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> savecustinfo(customerVM cust)
        {
            var cuts = await _hotelBusiness.postcustinfo(cust);
            return Ok(cuts);
        }

        [HttpGet("cust")]
        public async Task<IActionResult> getallcust()
        {
            var cust = await _hotelBusiness.getallcust();
            return Ok(cust);
        }


    }
}
