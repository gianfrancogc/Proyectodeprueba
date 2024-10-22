using Microsoft.EntityFrameworkCore;
using MusicStore.Domain;
using MusicStore.Service.Dto;
using MusicStore.Service.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Service.Services
{
    public interface IAlbumService // Sirve para la inyecciones de dependencia
    {
        //Agregar métodos asincronos, ejecutados al mismo tiempo
        Task SaveAlbum(Album album);
        Task<List<AlbumGetAll>> ListAlbum(); // función y retorna la lista de albumes


    }
    public class AlbumService : IAlbumService // Inyecciones
    {
        private readonly MusicDBContext _musicDBContext;

        public AlbumService(MusicDBContext musicDBContext)
        {
            _musicDBContext = musicDBContext;
        }

        public async Task<List<AlbumGetAll>> ListAlbum()
        {
            try
            {
                return await _musicDBContext.Album
                    .Select(item => new AlbumGetAll
                    {
                        AlbumCover = item.AlbumCover,
                        AlbumId = item.AlbumId,
                        Artist = item.Artist,
                        NameAlbum = item.NameAlbum
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de álbumes: " + ex.Message);
            }
        }


        public async Task SaveAlbum(Album album)
        {
            try
            {
                await _musicDBContext.Album.AddAsync(album);
                await _musicDBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
