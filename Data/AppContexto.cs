using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSTecnologia.FaceAlbum.Web.Models;

namespace TDSTecnologia.FaceAlbum.Web.Data
{
    public class AppContexto : DbContext
    {
        public AppContexto(DbContextOptions<AppContexto> opcoes) : base(opcoes)
        {
        }

        public DbSet<Album> Albuns { get; set; }
    }
}
