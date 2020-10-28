using System;
using System.Threading.Tasks;
using webApi.Core.Repositories;

namespace webApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        IArtistRepository Artists { get; }
        Task<int> CommitAsync();
    }
}