using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tarea1_U2_AnderA_AngelA.Models;
using tarea1_U2_AnderA_AngelA.Interfaces;

namespace tarea1_U2_AnderA_AngelA.Controllers
{
	public class NoticiaController : Controller
	{
        private readonly ILogger<NoticiaController> _logger;
        private readonly IRepositorioNoticia repositorioNoticia;

        public NoticiaController(ILogger<NoticiaController> logger, IRepositorioNoticia repositorioNoticia)
        {

            _logger = logger;
            this.repositorioNoticia = repositorioNoticia;
            if (repositorioNoticia.ObtenerNoticia().Count == 0)
            {
                var nociasPasadas = ObtenerNoticiasPasadas();
                foreach (var noticia in nociasPasadas)
                {
                    repositorioNoticia.AgregarNoticias(noticia);
                }
            }
        }

        public IActionResult Index()
        {
            var task = repositorioNoticia.ObtenerNoticia();

            var taskViewModel = new NoticiaViewModel
            {
                Task = task.OrderByDescending(noticia => noticia.FechaDePublicacion).Reverse()
            };

            return View(taskViewModel);
        }

        public IActionResult Crear()
        {
            return View("CrearFormulario");
        }

        [HttpPost]
        public IActionResult Crear(Models.Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                return View("CrearFormulario", noticia);
            }
            repositorioNoticia.AgregarNoticias(noticia);

            return RedirectToAction("Index");
        }

        public IActionResult Editar(Guid Id)
        {
            var noticia = repositorioNoticia.ObtenerPorId(Id);

            return View("FormularioEditar", noticia);
        }

        [HttpPost]
        public IActionResult Editar(Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                return View("FormularioEditar", noticia);
            }
            repositorioNoticia.ActualizarNoticias(noticia);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult BorrarTarea(Guid Id)
        {
            repositorioNoticia.EliminarNoticias(Id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult BuscarPorCategoria(string categoria)
        {
            var noticias = repositorioNoticia.BuscarPorCategoria(categoria);

            var viewModel = new NoticiaViewModel
            {
                Task = noticias.OrderByDescending(noticia => noticia.FechaDePublicacion).Reverse()
            };

            return View("Index", viewModel);
        }
        private List<Noticia> ObtenerNoticiasPasadas()
        {
            var noticiasPasadas = new List<Noticia>();

            noticiasPasadas.Add(new Noticia
            {
                Id = Guid.NewGuid(),
                Titulo = "Acuerdo histórico en la cumbre del clima: 195 países se comprometen a reducir emisiones",
                Descripcion = "En la cumbre del clima celebrada en Madrid, los representantes de 195 países alcanzaron " +
                "un acuerdo histórico para reducir las emisiones de gases de efecto invernadero. " +
                "El pacto establece metas ambiciosas y medidas concretas para abordar el cambio climático global.",
                FechaDePublicacion = DateTime.Now.AddDays(-1310),
                Categoria = "Internacional"
            });

            noticiasPasadas.Add(new Noticia
            {
                Id = Guid.NewGuid(),
                Titulo = "Protestas masivas en Honduras exigen reformas en el sistema educativo",
                Descripcion = "Miles de estudiantes, profesores y padres de familia salieron a las calles de Honduras para demandar reformas en el sistema educativo. " +
                "Las protestas se centraron en la falta de recursos, la calidad de la educación y la necesidad de una mayor inversión en infraestructura escolar.",
                FechaDePublicacion = DateTime.Now.AddDays(-1022),
                Categoria = "Sociales"
            });

            noticiasPasadas.Add(new Noticia
            {
                Id = Guid.NewGuid(),
                Titulo = "Lanzamiento exitoso del primer satélite de comunicaciones de última generación",
                Descripcion = " La compañía espacial SpaceX logró un lanzamiento exitoso del primer satélite de comunicaciones de última generación. " +
                "Este satélite promete mejorar significativamente la velocidad y calidad de las comunicaciones globales, " +
                "abriendo nuevas posibilidades en áreas como la conectividad rural y la transmisión de datos.",
                FechaDePublicacion = DateTime.Now.AddDays(-496),
                Categoria = "Tecnología"
            });

            noticiasPasadas.Add(new Noticia
            {
                Id = Guid.NewGuid(),
                Titulo = "Crecimiento económico mundial se desacelera en medio de tensiones comerciales",
                Descripcion = "El Fondo Monetario Internacional (FMI) informó que el crecimiento económico global se está desacelerando " +
                "debido a las crecientes tensiones comerciales entre importantes economías. " +
                "El informe destaca la importancia de la cooperación internacional para resolver las disputas comerciales y promover un crecimiento sostenible.",
                FechaDePublicacion = DateTime.Now.AddDays(-1454),
                Categoria = "Económicas"
            });

            noticiasPasadas.Add(new Noticia
            {
                Id = Guid.NewGuid(),
                Titulo = "Equipo nacional de fútbol de Argentina se corona campeón de la Copa América",
                Descripcion = " La selección argentina de fútbol se consagró campeona de la Copa América tras vencer a Brasil en la final. " +
                "El equipo argentino logró un destacado desempeño durante el torneo, " +
                "liderado por su capitán Lionel Messi, quien fue elegido como el mejor jugador del campeonato. ",
                FechaDePublicacion = DateTime.Now.AddDays(-734),
                Categoria = "Deportivas"
            });

            return noticiasPasadas;
        }
    }
}