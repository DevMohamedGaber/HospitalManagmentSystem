using Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors;

public sealed class ValidationBehavior<TReq, TRes> : IPipelineBehavior<TReq, TRes> where TReq : IRequest<TRes>
{
    private readonly IEnumerable<IValidator<TReq>> _valiators;

    public ValidationBehavior(IEnumerable<IValidator<TReq>> validators)
    {
        this._valiators = validators;
    }

    public async Task<TRes> Handle(TReq req, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
    {
        if(_valiators.Count() == 0)
        {
            return await next();
        }

        var contxt = new ValidationContext<TReq>(req);

        var errorList = _valiators.Select(v => v.Validate(contxt))
                                  .SelectMany(v => v.Errors)
                                  .Where(v => v != null)
                                  .Select(v => v.ErrorMessage)
                                  .Distinct()
                                  .ToArray();

        if(errorList.Any())
        {
            throw new BadRequestException(errorList);
        }

        return await next();
    }
}
