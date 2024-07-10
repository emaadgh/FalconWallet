using FluentValidation;
using System.Net;

namespace FalconWallet.API.Common;

public class EndpointValidatorFilter<T>(IValidator<T> validator) : IEndpointFilter
{
    private readonly IValidator<T> _validator = validator;

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        T? inputData = context.GetArgument<T>(0);

        if (inputData is not null)
        {
            var validationResult = await _validator.ValidateAsync(inputData);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary(),
                                                 statusCode: (int)HttpStatusCode.BadRequest);
            }
        }

        return await next.Invoke(context);
    }
}

public static class ValidatorExtensions
{
    public static RouteHandlerBuilder Validator<T>(this RouteHandlerBuilder builder)
        where T : class
    {
        builder.AddEndpointFilter<EndpointValidatorFilter<T>>();
        return builder;
    }
}