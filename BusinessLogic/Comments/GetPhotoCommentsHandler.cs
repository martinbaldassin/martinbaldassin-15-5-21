using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogic.Photos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace BusinessLogic.Comments
{
    public class GetPhotoCommentsHandler: BaseRequestHandler<GetPhotoCommentsRequest, List<CommentModel>>
    {
        public GetPhotoCommentsHandler(IServiceProvider provider) : base(provider)
        {
        }

        protected override async Task<List<CommentModel>> ExecuteAsync(GetPhotoCommentsRequest request, CancellationToken token)
        {
            var apiClient = new RestClient("https://jsonplaceholder.typicode.com/");
            var apiRequest = new RestRequest($"comments?postId={request.PostId}", Method.GET, DataFormat.Json);

            var apiResponse = await apiClient.ExecuteGetAsync(apiRequest, token);

            var comments = JsonConvert.DeserializeObject<List<CommentModel>>(apiResponse.Content,
                new JsonSerializerSettings() {ContractResolver = new CamelCasePropertyNamesContractResolver()});
            
            return comments;
        }
    }
}