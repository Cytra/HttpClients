using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MorningstartAPI.Services
{
    public class MartynasService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private CancellationTokenSource _cancellationTokenSource;
        public MartynasService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task<long> OneRequest()
        {
            var watch = new Stopwatch();
            var httpClient = _httpClientFactory.CreateClient("MartynasClient");
            watch.Start();

            var request = new HttpRequestMessage(
                HttpMethod.Get, "api/rest.svc/timeseries_price/nen6ere626?id=F000015CV2%5D2%5D1%5D&currencyId=CZK&idtype=Morningstar&priceType=&frequency=daily&startDate=2020-06-29&endDate=2020-09-21&outputType=COMPACTJSON");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = await httpClient.SendAsync(request, _cancellationTokenSource.Token))
            {
                var result = await response.Content.ReadAsStreamAsync();
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public async Task<long> HundredRequests()
        {
            var watch = new Stopwatch();
            var httpClient = _httpClientFactory.CreateClient("MartynasClient");
            watch.Start();
            for (int i = 0; i < 100; i++)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "api/rest.svc/timeseries_price/nen6ere626?id=F000015CV2%5D2%5D1%5D&currencyId=CZK&idtype=Morningstar&priceType=&frequency=daily&startDate=2020-06-29&endDate=2020-09-21&outputType=COMPACTJSON");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await httpClient.SendAsync(request, _cancellationTokenSource.Token))
                {
                    var result = await response.Content.ReadAsStreamAsync();
                }
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
