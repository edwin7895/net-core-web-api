
using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Core.Models;

namespace webApi.Core.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithMusicsAsync();
        Task<Artist> GetWithMusicsByIdAsync(int id);
    }
}