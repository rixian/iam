using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Rixian.Iam.Grpc.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int runCount = 100;

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            // The port number(5001) must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("http://localhost:57518", new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Insecure,
            });
            var iamClient = new IamClient(channel);
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < runCount; i++)
            {
                var tenants = await iamClient.ListTenantsAsync("dev-client").ConfigureAwait(false);
            }

            sw.Stop();
            var avg = sw.ElapsedMilliseconds / runCount;
            Console.WriteLine($"Average Call Time (GRPC): {avg}");

            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:57518") };
            //var httpIamClient = new Rixian.Iam.IamClient();
            sw = Stopwatch.StartNew();
            for (int i = 0; i < runCount; i++)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "/tenants?userId=dev-client")
                {
                    Version = new Version(2, 0),
                };
                var response = await httpClient.SendAsync(request).ConfigureAwait(false);
                var json = await response.Content.ReadAsStringAsync();
                var tenants = Newtonsoft.Json.Linq.JArray.Parse(json);
                //var tenants = await httpIamClient.ListTenantsHttpResponseAsync("dev-client").ConfigureAwait(false);
            }

            sw.Stop();
            avg = sw.ElapsedMilliseconds / runCount;
            Console.WriteLine($"Average Call Time (HTTP): {avg}");

            //Console.WriteLine(JsonSerializer.Serialize(tenants, new JsonSerializerOptions { WriteIndented = true }));
            Console.ReadKey();
        }
    }
}
