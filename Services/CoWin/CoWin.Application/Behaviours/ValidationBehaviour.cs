using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = CoWin.Application.Exceptions.ValidationException;

namespace CoWin.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>>  validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(_validators.Any())
            {
                var context=new ValidationContext<TRequest>(request);

                var validatorResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures=validatorResults.SelectMany(r=>r.Errors).Where(f=>f!=null).ToList();

                if (failures.Count != 0)
                    throw new ValidationException(failures);

            }
            return await next();
        }
    }
}
