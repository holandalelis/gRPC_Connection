using Calculator;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.SumCalculatorService;

namespace server
{
    internal class SumCalculatorServiceImpl : SumCalculatorServiceBase
    {
        public override Task<SumCalculatorResponse> Calculator(SumCalculatorRequest request, ServerCallContext context)
        {
            string result = string.Format("the sum is {0} ", request.SumCalculator.N1 + request.SumCalculator.N2);
            return Task.FromResult(new SumCalculatorResponse() { Result = result });
        }
    }
}
