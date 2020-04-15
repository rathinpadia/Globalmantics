using Globalmantics_Sqs_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SQS.Model;

namespace Globalmantics_Sqs_WebApi.Services
{
    public interface ISqsService
    {
        Task<TicketResponse> SendMessageToSqsQueue(TicketRequest request);
    }
}
