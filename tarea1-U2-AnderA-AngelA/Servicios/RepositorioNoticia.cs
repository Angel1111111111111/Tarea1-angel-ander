using tarea1_U2_AnderA_AngelA.Interfaces;
using tarea1_U2_AnderA_AngelA.Models;

namespace tarea1_U2_AnderA_AngelA.Servicios
{
	public class RepositorioNoticia : IRepositorioNoticia

	{
        public List<Models.Noticia> Noticia { get; }

        public RepositorioNoticia()
        {
            Noticia = new List<Models.Noticia>();
        }

        public void ActualizarNoticias(Noticia task)
        {
            var noticia = Noticia.FirstOrDefault(noticia => noticia.Id == task.Id);

            if (noticia == null)
            {

                throw new Exception(message: "No existe ninguna tarea.");
            }
            noticia.Titulo = task.Titulo;
            noticia.Descripcion = task.Descripcion;
            noticia.FechaDePublicacion = task.FechaDePublicacion;
        }

        public void AgregarNoticias(Models.Noticia noticia)
        {
            noticia.Id = Guid.NewGuid();
            Noticia.Add(noticia);
        }

        public void EliminarNoticias(Guid Id)
        {
            var noticia = Noticia.FirstOrDefault(noticia => noticia.Id == Id);

            if (noticia == null)
            {
                throw new Exception(message: "No existe ninguna tarea.");
            }
            Noticia.Remove(noticia);
        }

        public Models.Noticia ObtenerPorId(Guid Id)
        {
            var noticia = Noticia.FirstOrDefault(noticia => noticia.Id == Id);

            if (noticia == null)
            {
                throw new Exception(message: "No existe ninguna tarea.");
            }
            return noticia;
        }

        public List<Models.Noticia> ObtenerNoticia()
        {
            return Noticia;
        }
            public IEnumerable<Noticia> BuscarPorCategoria(string categoria)
            {
                return Noticia.Where(noticia => noticia.Categoria == categoria);
            }
        

    }
}
