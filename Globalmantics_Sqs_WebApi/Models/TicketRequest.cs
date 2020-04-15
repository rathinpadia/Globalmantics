using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Globalmantics_Sqs_WebApi.Models
{
    public class TicketRequest
    {
        /// <summary>
        /// New Guid for each ticket
        /// </summary>
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public string Serialize(TicketRequest value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(value, options);
        }
    }
}
