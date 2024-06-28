using Calculator;
using Greet;
using Grpc.Core;

namespace client
{
    class Program
    {
        const string target = "127.0.0.1:50051";
        static async Task Main(string[] args)
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The client connected successfully");
            });
            //var client = new DummyService.DummyServiceClient(channel);
            var client = new GreetingService.GreetingServiceClient(channel);
            //var client = new SumCalculatorService.SumCalculatorServiceClient(channel);
            var greeting = new Greeting() { FirstName = "Pedro", LastName = "Lelis" };

            //var numbers = new SumCalculator()
            //{
            //   N1 = 10,
            //    N2 = 20
            //};

            //var request = new SumCalculatorRequest() { SumCalculator = numbers };
            //var response = client.Calculator(request);

            var request = new GreetManyTimesRequest()
            {
                Greeting = greeting
            };
            var response = client.GreetManyTimes(request);

            //Console.WriteLine(response);

            while (await response.ResponseStream.MoveNext())
            {
                Console.WriteLine(response.ResponseStream.Current.Result);
                await Task.Delay(200);
            }
            channel.ShutdownAsync().Wait();
            Console.ReadKey();

        }
    }
}