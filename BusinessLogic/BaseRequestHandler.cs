using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BusinessLogic
{

    public abstract class BaseRequestHandler<TRequest,TResponse>
       : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected BaseRequestHandler(IServiceProvider provider)
        {
            
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await ExecuteAsync(request, cancellationToken);

                return response;
            }
            catch (Exception ex)
            {            
                throw ex.GetBaseException();
            }
        }

        protected abstract Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}
