using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace BusinessLogic.Albums
{
    public class GetAlbumsHandler: BaseRequestHandler<GetAlbumsRequest, List<AlbumModel>>
    {
        public GetAlbumsHandler(IServiceProvider provider) : base(provider)
        {
        }

        protected override async Task<List<AlbumModel>> ExecuteAsync(GetAlbumsRequest request, CancellationToken token)
        {
            var apiClient = new RestClient("https://jsonplaceholder.typicode.com/");
            var apiRequest = new RestRequest("albums", Method.GET, DataFormat.Json);

            var apiResponse = await apiClient.ExecuteGetAsync(apiRequest, token);

            var albums = JsonConvert.DeserializeObject<List<AlbumModel>>(apiResponse.Content,
                new JsonSerializerSettings() {ContractResolver = new CamelCasePropertyNamesContractResolver()});
            
            return albums;
        }
    }
}