using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblAppointment
{
    public int AppointmentId { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public int DocterId { get; set; }

    public int MedicalServiceId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public virtual TblDoctor Doctor { get; set; }

    public virtual TblMedicalService MedicalService { get; set; }

    public virtual TblPatient Patient { get; set; }
}
