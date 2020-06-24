using System;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Domain.Exception;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Inventory.Application
{
    public class ExceptionLoggerPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ExceptionLoggerPipelineBehaviour<TRequest, TResponse>> _logger;

        public ExceptionLoggerPipelineBehaviour(ILogger<ExceptionLoggerPipelineBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return next();
            } catch (RequestValidationException e)
            {
                _logger.LogWarning(e, e.Message);
                throw;
            } catch (DomainException e)
            {
                _logger.LogError(e, e.Message);
                throw;
            } catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
                throw;
            }
        }
    }
}