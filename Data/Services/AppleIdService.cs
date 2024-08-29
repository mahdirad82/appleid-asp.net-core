using AppleAccounts.Controllers;
using AppleAccounts.Data.Enums;
using AppleAccounts.Models;
using Microsoft.EntityFrameworkCore;

namespace AppleAccounts.Data.Services
{
    public class AppleIdService(AppDbContext context) : IAppleIdService
    {
        private readonly AppDbContext _context = context;
        public async Task AddAsync(AppleId appleId)
        {
            await _context.AppleIds.AddAsync(appleId);
            await _context.SaveChangesAsync();
        }

        public async Task<AppleId?> GetAppleId(int id) => await _context.AppleIds.FirstOrDefaultAsync(n => n.Id == id);


        public async Task<AppleId> UpdateAsync(int id, AppleId newAppleId)
        {
            _context.Update(newAppleId);
            await _context.SaveChangesAsync();
            return newAppleId;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.AppleIds.FirstOrDefaultAsync(n => n.Id == id);
            if (result != null)
            {
                _context.AppleIds.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AppleId>> GetAppleIds(bool expired, string? status = null, string? filterQuery = "", string? order = null)
        {
            IQueryable<AppleId> appleIds = _context.AppleIds.AsQueryable().Where(i => i.Expired == expired);
            if (!string.IsNullOrEmpty(filterQuery))
                appleIds = appleIds.Where(i => i.Email.Contains(filterQuery) || i.Id.ToString().Contains(filterQuery));

            if (!string.IsNullOrWhiteSpace(status))
            {
                if (int.TryParse(status, out int id))
                    appleIds = appleIds.Where(i => i.Status == (AppleIdStatus)id);
            }
            if (!string.IsNullOrWhiteSpace(order))
            {
                if (order.Equals("status", StringComparison.OrdinalIgnoreCase))
                    appleIds = appleIds.OrderBy(i => i.Status);

                if (order.Equals("email", StringComparison.OrdinalIgnoreCase))
                    appleIds = appleIds.OrderBy(i => i.Email);

                if (order.Equals("birth", StringComparison.OrdinalIgnoreCase))
                    appleIds = appleIds.OrderBy(i => i.BirthDay);
            }

            return await appleIds.ToListAsync();
        }
    }
}