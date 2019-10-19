using System.Threading.Tasks;
using Models;

namespace DBRepository.Interfaces
{
    public interface IIdentityRepository
    {
        Task<User> GetUser(string userName);
    }
}