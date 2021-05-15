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
    [Route("Comments")]
    public class CommentsController : Controller
    {
        private readonly IMediator _mediator;

        public CommentsController(IServiceProvider provider)
        {
            _mediator = provider.GetService<IMediator>();
        }

        [Route("{photoId}")]
        public async Task<IActionResult> GetComments(int photoId, CancellationToken cancellationToken)
        {
            var comments = await _mediator.Send(new GetPhotoCommentsRequest(photoId), cancellationToken);
            return View("CommentsPartial", new PhotoCommentsViewModel() { Comments = comments});
        }
    }
}
