using PatientEntity = Domain.Entities.Patient;

namespace Application.Features.Patient.GetAllData;

public class GetAllPatientDataResponse
{
    public PatientEntity? data { get; set; }

    public GetAllPatientDataResponse() {}
    public GetAllPatientDataResponse(PatientEntity patient)
    {
        data = patient;
    }
}
