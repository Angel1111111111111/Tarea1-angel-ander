using System.ComponentModel.DataAnnotations;

namespace tarea1_U2_AnderA_AngelA.Models
{
	public class Noticia
	{
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Inserte el titulo de la noticia.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Inserte la descripcion de la noticia.")]
        public string Descripcion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Inserte la fecha de la noticia.")]
        [DataType(DataType.Date, ErrorMessage = "Inserte la fecha de la noticia.")]
        public DateTime FechaDePublicacion { get; set; }
        [Required(ErrorMessage = "Inserte la Categoria de la noticia.")]
        public string Categoria { get; set; }
    }
}
