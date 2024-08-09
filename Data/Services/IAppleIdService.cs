using AppleAccounts.Models;
using AppleAccounts.Data.Enums;

namespace AppleAccounts.Data.Services
{
    public interface IAppleIdService
    {
        Task<IEnumerable<AppleId>> GetAppleIds(int status, bool expired);
        Task<IEnumerable<AppleId>> GetAppleIds(bool expired);
        Task<AppleId> GetAppleId(int id);
        Task AddAsync(AppleId appleId);
        Task<AppleId> UpdateAsync(int id, AppleId newAppleId);
        Task DeleteAsync(int id);
    }
}