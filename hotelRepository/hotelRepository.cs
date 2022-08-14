using hotelRepository.Interface;
using hotelRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelRepository
{
    public class hotellRepository : IhotelRepository
    {
        private readonly hotell_managementContext _context;

        public hotellRepository(hotell_managementContext context)
        {
            _context = context;

        }

        public async Task<List<Hotel>> everyhotel()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<List<CustInfo>> getallcust()
        {
            return await _context.CustInfos.ToListAsync();
        }

        public async Task<List<information>> getallhotel()
        {
            var q =  (from h in _context.Hotels
                     join ri in _context.RoomInformations on h.HotelCode equals ri.HotelCode
                    where ri.Availability == "yes"
                    select new information
                    {
                       
                        HotelName=h.HotelName,
                        Address=h.Address,
                        Postcode=h.Postcode,
                        City=h.City,
                        Country=h.Country,
                        PhoneNo=h.PhoneNo,
                        StarRating=h.StarRating,
                        ClassName=h.ClassName,
                        Image=h.Image,
                       
                        RoomId=ri.RoomId,
                        NumberOfRooms=ri.NumberOfRooms,
                        RoomType=ri.RoomType,
                        Price=ri.Price,
                       

                    });;
            return await q.ToListAsync();
        }

        public async Task<List<avail>> getbyavailable(DateTime check_IN, DateTime check_Out, string city)
        {
            var tdate = check_IN;
            var odate = check_Out;
            var date = DateTime.Now;
            var av = (from h in _context.Hotels
                      join r in _context.Reservations on h.HotelCode equals r.HotelCode
                      join ri in _context.RoomInformations on h.HotelCode equals ri.HotelCode 
                      where r.CheckOut< date && h.City == city && r.CheckOut< check_IN
                      select new avail
                      {

                          HotelName = h.HotelName,
                          Address = h.Address,
                          Postcode = h.Postcode,
                          City = h.City,
                          Country = h.Country,
                          PhoneNo = h.PhoneNo,
                          StarRating = h.StarRating,
                          ClassName = h.ClassName,
                          Image = h.Image,

                          RoomId = ri.RoomId,
                          NumberOfRooms = ri.NumberOfRooms,
                          RoomType = ri.RoomType,
                          Price = ri.Price
                      });
            /* foreach (var item in av)
             {
                 var change = _context.RoomInformations.Where(x => x.RoomId == item.RoomId).SingleOrDefault();
                 change.Availability = "yes";
                 _context.SaveChanges();

             }*/
            /* var av1 = (from h in _context.Hotels
                       join r in _context.Reservations on h.HotelCode equals r.HotelCode
                       join ri in _context.RoomInformations on h.HotelCode equals ri.HotelCode
                       where r.CheckOut > date
                       select new avail
                       {

                           HotelName = h.HotelName,
                           Address = h.Address,
                           Postcode = h.Postcode,
                           City = h.City,
                           Country = h.Country,
                           PhoneNo = h.PhoneNo,
                           StarRating = h.StarRating,
                           ClassName = h.ClassName,
                           Image = h.Image,

                           RoomId = ri.RoomId,
                           NumberOfRooms = ri.NumberOfRooms,
                           RoomType = ri.RoomType,
                           Price = ri.Price
                       });
             foreach (var item in av)
             {
                 var change = _context.RoomInformations.Where(x => x.RoomId == item.RoomId).SingleOrDefault();
                 change.Availability = "no";
                 _context.SaveChanges();

             }*/

            return await av.ToListAsync();
        }

        public async Task<List<information>> gethotel(string City)
        {

            var q = (from h in _context.Hotels
                     join ri in _context.RoomInformations on h.HotelCode equals ri.HotelCode
                     where ri.Availability == "yes" && h.City==City 
                     select new information
                     {

                         HotelName = h.HotelName,
                         Address = h.Address,
                         Postcode = h.Postcode,
                         City = h.City,
                         Country = h.Country,
                         PhoneNo = h.PhoneNo,
                         StarRating = h.StarRating,
                         ClassName = h.ClassName,
                         Image = h.Image,

                         RoomId = ri.RoomId,
                         NumberOfRooms = ri.NumberOfRooms,
                         RoomType = ri.RoomType,
                         Price = ri.Price,


                     }); ;
            return await q.ToListAsync();

        }

        public async Task<CustInfo> postcustinfo(CustInfo cust)
        {
            var result = await _context.CustInfos.AddAsync(cust);
           await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Reservation> postreserve(Reservation reservation)
        {
            var result = await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
