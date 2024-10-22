using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Domain
{
    public class User
    {
        public int UserId { get; set; }

        public string NameUser { get; set; }

        public string PassUser { get; set; }

        public String Apellidos { get; set; }
        public String Email { get; set; }
    }
}
