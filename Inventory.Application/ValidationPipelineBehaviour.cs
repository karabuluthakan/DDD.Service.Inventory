using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Inventory.Application
{
    public class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ValidationPipelineBehaviour<TRequest, TResponse>> _logger;

        public ValidationPipelineBehaviour(ILogger<ValidationPipelineBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is IValidatableObject validatableObject)
            {
                var validationResults = validatableObject.Validate(new ValidationContext(request)).ToArray();
                if (validationResults.Any())
                {
                    var validationException = new RequestValidationException(validationResults);
                    _logger.LogError(validationException, $"Request Not Valid! ({request.GetType().Name})");
                    throw validationException;
                }
            }

            return next();
        }
    }
}