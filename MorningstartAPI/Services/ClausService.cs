using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MorningstartAPI.Services
{
    public class ClausService
    {
        public async Task<long> OneRequest()
        {
            var watch = new Stopwatch();
            watch.Start();
            using (var client = new HttpClient())
            {
                var req = new HttpRequestMessage(HttpMethod.Get, "https://tools.morningstar.dk/api/rest.svc/timeseries_price/nen6ere626?id=F000015CV2%5D2%5D1%5D&currencyId=CZK&idtype=Morningstar&priceType=&frequency=daily&startDate=2020-06-29&endDate=2020-09-21&outputType=COMPACTJSON");
                req.Version = new Version(2, 0);
                req.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var resp = await client.SendAsync(req);
                var res = await resp.Content.ReadAsStringAsync();
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public async Task<long> HundredRequests()
        {
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 100; i++)
            {
                using (var client = new HttpClient())
                {
                    var req = new HttpRequestMessage(HttpMethod.Get, "https://tools.morningstar.dk/api/rest.svc/timeseries_price/nen6ere626?id=F000015CV2%5D2%5D1%5D&currencyId=CZK&idtype=Morningstar&priceType=&frequency=daily&startDate=2020-06-29&endDate=2020-09-21&outputType=COMPACTJSON");
                    req.Version = new Version(2, 0);
                    req.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var resp = await client.SendAsync(req);
                    var res = await resp.Content.ReadAsStringAsync();
                }
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
