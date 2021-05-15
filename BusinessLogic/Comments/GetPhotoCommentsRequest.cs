using System.Collections.Generic;
using MediatR;

namespace BusinessLogic.Comments
{
    public class GetPhotoCommentsRequest: IRequest<List<CommentModel>>
    {
        public int PostId { get; }
        public GetPhotoCommentsRequest(int postId)
        {
            PostId = postId;
        }
    }
}