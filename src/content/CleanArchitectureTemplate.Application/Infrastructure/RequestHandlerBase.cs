using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Persistence;
using MediatR;

namespace CleanArchitectureTemplate.Application.Infrastructure
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly CleanArchitectureTemplateDbContext DbContext;

        protected RequestHandlerBase(CleanArchitectureTemplateDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    }
}