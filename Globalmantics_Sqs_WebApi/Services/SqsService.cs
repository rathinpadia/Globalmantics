using Globalmantics_Sqs_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Globalmantics_Sqs_WebApi.Services
{
    public class SqsService : ISqsService
    {
        private readonly IAmazonSQS _amazonSqsClient;
        private readonly string QueueUrl = "";
        public SqsService(IAmazonSQS amazonSqsClient)
        {
            _amazonSqsClient = amazonSqsClient;
        }
        public async Task<TicketResponse> SendMessageToSqsQueue(TicketRequest request)
        {
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = QueueUrl,
                MessageBody =  request.Serialize(request)
            };

            var response = await _amazonSqsClient.SendMessageAsync(sendMessageRequest);

            return new TicketResponse
            {
                MessageId = response.MessageId
            };
        }
    }
}
