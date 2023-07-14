using tarea1_U2_AnderA_AngelA.Models;

namespace tarea1_U2_AnderA_AngelA.Interfaces
{
	public interface IRepositorioNoticia
	{
		public List<Models.Noticia> Noticia { get; }

		public List<Models.Noticia> ObtenerNoticia();
		public void AgregarNoticias(Models.Noticia noticia);
		public void EliminarNoticias(Guid noticia);
		public void ActualizarNoticias(Noticia noticia);
		public Models.Noticia ObtenerPorId(Guid Id);
        IEnumerable<Noticia> BuscarPorCategoria(string categoria);
        
    }
}
