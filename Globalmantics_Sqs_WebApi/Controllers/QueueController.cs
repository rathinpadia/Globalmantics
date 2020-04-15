using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globalmantics_Sqs_WebApi.Models;
using Globalmantics_Sqs_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Globalmantics_Sqs_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly ISqsService _sqsService;

        public QueueController(ISqsService sqsService)
        {
            _sqsService = sqsService;
        }

        /// <summary>
        /// Add a new message to SQS
        /// </summary>
        /// <param name="ticketRequest">
        /// parameters to be added
        /// </param>
        /// <returns>
        /// Message Id of newly added message
        /// </returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Queue/SendMessage
        ///     {
        ///        "id": "5e31ca06-72d4-445d-8886-314e7b1cbeb8",
        ///        "name": "Jack Sparrow",
        ///        "emailAddress": "jack@sp.com",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">added message with unique id</response>
        /// <response code="500">general error due to api failure or aws connection failure</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost]
        [Route("SendMessage")]
        public async Task<ActionResult<TicketResponse>> SendMessage([FromBody] TicketRequest ticketRequest)
        {
            var response = await _sqsService.SendMessageToSqsQueue(ticketRequest);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

    }
}