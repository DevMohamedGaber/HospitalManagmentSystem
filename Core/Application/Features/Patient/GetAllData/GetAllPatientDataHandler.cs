using Domain.Repositories;
using MediatR;

namespace Application.Features.Patient.GetAllData;

public sealed class GetAllPatientDataHandler : IRequestHandler<GetAllPatientDataRequest, GetAllPatientDataResponse>
{
    private readonly IPatientRepository _repository;
    public GetAllPatientDataHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAllPatientDataResponse> Handle(GetAllPatientDataRequest request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetWithRelationships(request.Id, cancellationToken);

        if (patient == null)
        {
            return new();
        }

        return new(patient);
    }
}
