using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Models;
namespace Youtube.Services
{
    public interface IYoutubeService
    {
        Task<Video> Create(Video video);
        Task<IEnumerable<Video>> GetAll();
        Task<Video> GetbyId(int? id);
        Task<Video> Update(Video video);
        Task<Video> Delete(Video video);
    }
}
