using Domain.Interfaces;

namespace Domain.Entities;

public class PatientContact : Contact
{
    public Patient? Patient { get; set; }
}
