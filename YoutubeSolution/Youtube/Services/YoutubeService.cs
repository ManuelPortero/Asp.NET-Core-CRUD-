using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Models;
using Youtube.Data;
using Microsoft.EntityFrameworkCore;

namespace Youtube.Services
{
    public class YoutubeService : IYoutubeService
    {
        private readonly YoutubeContext _context; 

        public YoutubeService(YoutubeContext ctx)
        {
            _context = ctx; 
        }
        public Task<Video> Create(Video video)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.Videos.Add(video);
                    _context.SaveChanges();

                    return video;
                } catch (Exception exp)

                {
                    Console.WriteLine($"Erro:{exp}");

                }

                return null; 
            });
        }

        public Task<Video> Delete(Video video)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.Videos.Remove(video);
                    _context.SaveChanges();

                    return video;
                }
                catch (Exception exp)

                {
                    Console.WriteLine($"Erro:{exp}");

                }

                return null;
            });
        }

        public Task<IEnumerable<Video>> GetAll()
        {
            return Task.Run(() =>
            {
                try
                {
                    return _context.Videos
                        .Include(v => v.Author)
                        .OrderBy(v => v.CreatedDate).AsEnumerable();
                }
                catch (Exception exp)

                {
                    Console.WriteLine($"Erro:{exp}");

                }

                return null;
            });
        }

        public Task<Video> GetbyId(int? id)
        {
            return Task.Run(() =>
            {
              if (id != null)

                {
                    try
                    {
                        var video = _context.Videos.Where(v => v.Id == id).First();
                        if (video != null)
                        {
                            return video;
                        }
                    }
                    catch (Exception exp)

                    {
                        Console.WriteLine($"Erro:{exp}");

                    }



                }

                return null;
            });
        }

        public Task<Video> Update(Video video)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.Videos.Update(video);
                    _context.SaveChanges();

                    return video;
                }
                catch (Exception exp)

                {
                    Console.WriteLine($"Erro:{exp}");

                }

                return null;
            });
        }
    }
}
