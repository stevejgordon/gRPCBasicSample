using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ClientPropertyEndpoint;
using MediatR;

namespace Server
{
    public class PropertyService : ClientProperty.ClientPropertyBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public PropertyService(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<PropertyService>();
            _mediator = mediator;
        }

        public override async Task<PropertyReply> GetProperty(PropertyRequest request, ServerCallContext context)
        {
            var httpContext = context.GetHttpContext();

            _logger.LogInformation($"Connection id: {httpContext.Connection.Id}");

            _logger.LogInformation($"Handling request for property Id '{request.PropertyId}'");

            var property = await _mediator.Send(new ClientPropertyQuery(request.PropertyId));

            if (property is null)
                context.Status = new Status(StatusCode.NotFound, $"Property Id '{request.PropertyId}' was not found");

            return property ?? new PropertyReply();            
        }
    }
}
