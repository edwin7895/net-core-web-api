using System;
using System.Threading.Tasks;
using net_core_crud.Core.Repositories;

namespace net_core_crud.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        IArtistRepository Artists { get; }
        Task<int> CommitAsync();
    }
}