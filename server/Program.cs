using Grpc.Core;

namespace server
{
    class Program
    {
        const int Port = 50051;
        static void Main(string[] args)
        {
            Server server = null;

            try
            {
                server = new Server
                {
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine("The server is listening on the port: " + Port);
                Console.ReadKey();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("The server failed to start due to the following error: " + ex.Message);
                throw;
            }
            finally
            {
                if(server != null){
                    server.ShutdownAsync().Wait();
                }
            }
        }
    }
}
