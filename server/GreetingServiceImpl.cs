using Greet;
using Grpc.Core;
using static Greet.GreetingService;

namespace server
{
    public class GreetingServiceImpl : GreetingServiceBase
    {
        public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
        {
            string result = string.Format("hello {0} {1}", request.Greeting.FirstName, request.Greeting.LastName);
            return Task.FromResult(new GreetingResponse() { Result = result });
        }

        public override async Task GreetManyTimes(GreetManyTimesRequest request, IServerStreamWriter<GreetManyTimesResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine("The server received the request : ");
            Console.WriteLine(request.ToString());
            string result = String.Format("Hello {0} {1}", request.Greeting.FirstName, request.Greeting.LastName);
            foreach (int i in Enumerable.Range(1, 10))
            {
                await responseStream.WriteAsync(new GreetManyTimesResponse() { Result = result });
            }
        }
    }
}
