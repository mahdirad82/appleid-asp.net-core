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

        public async Task<AppleId> GetAppleId(int id)
        {
            var result = await _context.AppleIds.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<IEnumerable<AppleId>> GetAppleIds(int status, bool expired)

        {
            return await _context.AppleIds.Where(i => i.Status == (AppleIdStatus)status && i.Expired == expired).ToListAsync();
        }

        public async Task<IEnumerable<AppleId>> GetAppleIds(bool expired)

        {
            return await _context.AppleIds.Where(i => i.Expired == expired).ToListAsync();
        }

        public async Task<AppleId> UpdateAsync(int id, AppleId newAppleId)
        {
            _context.Update(newAppleId);
            await _context.SaveChangesAsync();
            return newAppleId;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.AppleIds.FirstOrDefaultAsync(n => n.Id == id);
            _context.AppleIds.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}