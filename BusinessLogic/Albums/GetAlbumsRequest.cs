using System.Collections.Generic;
using MediatR;

namespace BusinessLogic.Albums
{
    public class GetAlbumsRequest: IRequest<List<AlbumModel>>
    {
        
    }
}