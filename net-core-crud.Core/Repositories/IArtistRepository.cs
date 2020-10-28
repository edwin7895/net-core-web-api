
using System.Collections.Generic;
using System.Threading.Tasks;
using net_core_crud.Core.Models;

namespace net_core_crud.Core.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithMusicsAsync();
        Task<Artist> GetWithMusicsByIdAsync(int id);
    }
}