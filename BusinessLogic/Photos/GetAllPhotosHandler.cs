using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace BusinessLogic.Photos
{
    public class GetAllPhotosHandler: BaseRequestHandler<GetAllPhotosRequest, List<PhotoModel>>
    {
        public GetAllPhotosHandler(IServiceProvider provider) : base(provider)
        {
        }

        protected override async Task<List<PhotoModel>> ExecuteAsync(GetAllPhotosRequest request, CancellationToken token)
        {
            var apiClient = new RestClient("https://jsonplaceholder.typicode.com/");
            var apiRequest = new RestRequest($"albums/{request.AlbumId}/photos", Method.GET, DataFormat.Json);

            var apiResponse = await apiClient.ExecuteGetAsync(apiRequest, token);

            var photos = JsonConvert.DeserializeObject<List<PhotoModel>>(apiResponse.Content,
                new JsonSerializerSettings() {ContractResolver = new CamelCasePropertyNamesContractResolver()});
            
            return photos;
        }
    }
}