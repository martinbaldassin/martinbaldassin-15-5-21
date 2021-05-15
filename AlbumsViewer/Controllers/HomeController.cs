using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlbumsViewer.Models;
using BusinessLogic.Albums;
using BusinessLogic.Comments;
using BusinessLogic.Photos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AlbumsViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IServiceProvider provider)
        {
            _mediator = provider.GetService<IMediator>();
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var albums = await _mediator.Send(new GetAlbumsRequest(), cancellationToken);
            return View(albums.OrderBy(x => x.Id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
