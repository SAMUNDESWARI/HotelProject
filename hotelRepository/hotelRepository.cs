using hotelRepository.Interface;
using hotelRepository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelRepository
{
    public class hotellRepository : IhotelRepository
    {
        private readonly hotel_managementContext _context;

        public hotellRepository(hotel_managementContext context)
        {
            _context = context;

        }

        public async Task<List<CustInfo>> getallcust()
        {
            return await _context.CustInfos.ToListAsync();
        }

        public async Task<List<Hotel>> getallhotel()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<List<Hotel>> gethotel(string City)
        {
            return await _context.Hotels.Where(x => x.City == City).ToListAsync();
        }

        public async Task<CustInfo> postcustinfo(CustInfo cust)
        {
            var result = await _context.CustInfos.AddAsync(cust);
           await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
