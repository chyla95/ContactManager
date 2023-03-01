using api.Models;

namespace api.Services
{
    public interface IContactService : IService<Contact>
    {
        Task<IEnumerable<Contact>> GetManyByOwnerAsync(int id, bool isTrackingEnabled = true);
        Task<IEnumerable<Contact>> GetManyPublicOnlyAsync(bool isTrackingEnabled = true);
    }
}
