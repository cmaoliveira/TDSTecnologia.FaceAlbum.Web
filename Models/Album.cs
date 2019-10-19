using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TDSTecnologia.FaceAlbum.Web.Models
{
    [Table("tb01_album")]
    public class Album
    {
        [Key]
        [Column("id")]
        public int AlbumId { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("capa")]
        public string Capa { get; set; }

        [Column("dt_inicio")]
        public DateTime DataFoto { get; set; }
    }
}
