using Grpc.Core;
using System;
using ClientPropertyEndpoint;
using System.Threading.Tasks;

namespace ClientProperty
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting GRPC Client...");
            Console.WriteLine();

            var channel = new Channel("localhost:50051", SslCredentials.Insecure);
            var client = new ClientPropertyEndpoint.ClientProperty.ClientPropertyClient(channel);

            try
            {
                var response = await client.GetPropertyAsync(new PropertyRequest { PropertyId = "ac516792-94fc-4e0c-b39c-59b2fcd58a4e" });

                Console.WriteLine("Org Name: " + response.OrganisationName);
                Console.WriteLine("Client Name: " + response.ClientName);
                Console.WriteLine("Product Name: " + response.ProductName);
            }
            catch (RpcException ex)
            {
                if (ex.StatusCode == StatusCode.NotFound)
                {
                    Console.WriteLine(ex.Status.Detail);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Shutting down");
            channel.ShutdownAsync().Wait();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
