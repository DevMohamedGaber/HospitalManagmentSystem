using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Web.Helpers;

namespace Application.Features.Patient.Login;

public sealed class PatientLoginHandler : IRequestHandler<PatientLoginRequest, PatientLoginResponse>
{
    private readonly IPatientRepository _repository;
    private readonly IHttpContextAccessor _httpContext;
    public PatientLoginHandler(IPatientRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContext = httpContextAccessor;
    }
    public async Task<PatientLoginResponse> Handle(PatientLoginRequest request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByNationalID(request.NationalID!);

        if(patient == null)
        {
            return new("National ID Not found");
        }
        var hashedPassword = Crypto.HashPassword(request.Password);
        
        if(hashedPassword != patient.Password)
        {
            return new("Wrong Password");
        }

        _httpContext.HttpContext.Session.Set("PatientId", BitConverter.GetBytes(patient.Id));

        return new();
    }
}
