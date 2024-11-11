using MediatR;

namespace Application.Features.Patient.GetAllData;

public record GetAllPatientDataRequest(uint Id) : IRequest<GetAllPatientDataResponse>;
