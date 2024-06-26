using Dummy;
using Grpc.Core;

namespace client
{
    class Program
    {
        const string target = "127.0.0.1:50051";
        static void Main(string[] args)
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The client connected successfully");
            });
            var client = new DummyService.DummyServiceClient(channel);

            channel.ShutdownAsync().Wait();
            Console.ReadKey();

        }
    }
}