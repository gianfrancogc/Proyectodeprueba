using MusicStore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Service.Dto
{
    public class AlbumGetAll
    {
        public int AlbumId { get; set; }

        public string NameAlbum { get; set; }

        public string Artist { get; set; }

        public string AlbumCover { get; set; }

    }
}
