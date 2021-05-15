using System;
using System.Diagnostics;
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
    [Route("Albums")]
    public class AlbumsController : Controller
    {
        private readonly IMediator _mediator;

        public AlbumsController(IServiceProvider provider)
        {
            _mediator = provider.GetService<IMediator>();
        }

        [Route("{albumId}")]
        public async Task<IActionResult> GetPhotos(int albumId, CancellationToken cancellationToken)
        {
            var photos = await _mediator.Send(new GetAllPhotosRequest(albumId), cancellationToken);
            return View("PhotosPartial", new AlbumPhotosViewModel() { Photos = photos});
        }
    }
}
