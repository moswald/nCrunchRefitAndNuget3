namespace Client
{
    using System;
    using System.Net.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Refit;

    public interface IExampleApi
    {
        [Get("/api/settings/{key}")]
        IObservable<string> GetSettingValue(string key);
    }

    // using a factory allows us to customize the way Json.NET [de]serializes things, as well as change the HttpClient and HttpMessageHandlers
    public static class ApiFactory
    {
        static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public static IExampleApi CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://some.fake.address.com/")
            };

            return RestService.For<IExampleApi>(
                httpClient,
                new RefitSettings
                {
                    JsonSerializerSettings = JsonSerializerSettings
                });
        }
    }
}
