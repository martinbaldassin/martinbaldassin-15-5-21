using System.Collections.Generic;
using MediatR;

namespace BusinessLogic.Photos
{
    public class GetAllPhotosRequest: IRequest<List<PhotoModel>>
    {
        public int AlbumId { get; }
        public GetAllPhotosRequest(int albumId)
        {
            AlbumId = albumId;
        }
    }
}