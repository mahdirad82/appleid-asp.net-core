using AppleAccounts.Models;

namespace AppleAccounts.Data.Services
{
    public interface IAppleIdService
    {
        Task<IEnumerable<AppleId>> GetAppleIds(bool expired, string? status = null, string? filterQuery = null);
        Task<AppleId> GetAppleId(int id);
        Task AddAsync(AppleId appleId);
        Task<AppleId> UpdateAsync(int id, AppleId newAppleId);
        Task DeleteAsync(int id);
    }
}