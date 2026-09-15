using System.ComponentModel.DataAnnotations;

namespace AuthApp.Models
{
    public class DiphtheriaCase
    {
        //["Id,NameOfTreatingPhysician,NameOfHealthcareCentre,HealthcareCentreTelephone,PatientFirstName,PatientLastName,PatientAge,PatientSex,PatientCountry,PatientTelephoneNumber,PatientCity,PatientAddress,PatientHouseHoldSize,PatientSymptomsPositiveForDiphtheria,DateofFirstClinicalDiagnosis,DateSymptomsOnset,PatientDiphtheriaPicture"]
        public int Id { get; set; }

        //health-care centre info
        [Required]
        [Display(Name = "Name Of Treating Physician")]
        [StringLength(255)]
        public string NameOfTreatingPhysician { get; set; }

        [Required]
        [Display(Name = "Name Of Healthcare Centre")]
        [StringLength(255)]
        public string NameOfHealthcareCentre { get; set; }

        [Required]
        [Display(Name = "Healthcare Centre Telephone")]
        //[Phone]
        public int HealthcareCentreTelephone { get; set; }


        //Patient IDENTIFIER INFORMATION
        [Required]
        [Display(Name = "Patient First Name")]
        [StringLength(255)]
        public string PatientFirstName { get; set; }

        [Required]
        [Display(Name = "Patient Last Name")]
        [StringLength(255)]
        public string PatientLastName { get; set; }

        [Required]
        [Display(Name = "Patient Age")]
        public int PatientAge { get; set; }

        [Required]
        [Display(Name = "Patient Sex Male/Female")]
        [StringLength(255)]
        public string PatientSex { get; set; } //Male/Female

        [Required]
        [Display(Name = "Patient Country of Residence")]
        [StringLength(255)]
        public string PatientCountry { get; set; }

        [Required]
        [Display(Name = "Patient Telephone number")]
        //[Phone]
        public double PatientTelephoneNumber { get; set; }


        [Required]
        [Display(Name = "Patient City")]
        [StringLength(255)]
        public string PatientCity { get; set; }

        [Required]
        [Display(Name = "Patient Address")]
        [StringLength(255)]
        public string PatientAddress { get; set; }

        [Required]
        [Display(Name = "Amount of people in residence")]
        public int PatientHouseHoldSize { get; set; }

        [Required]
        [Display(Name = "Patient presented with any symptoms related to diphtheria: Yes, No, Unk")]
        [StringLength(255)]
        public string PatientSymptomsPositiveForDiphtheria { get; set; } //Yes, No, Unk

        //Symptoms
        [Required]
        [Display(Name = "Date of First Clinical Diagnosis")]
        public DateTime DateofFirstClinicalDiagnosis { get; set; }

        [Required]
        [Display(Name = "Date symptoms onset (date of first/earliest symptom)")]
        public DateTime DateSymptomsOnset { get; set; }


        //Pics
        public byte[]? PatientDiphtheriaPicture { get; set; }

        //location
        //public double Lat { get; set; }
        //public double Lon { get; set; }

        ///public string PatientCaseClassification { get; set; } //Suspected, Confirmed, Probable
        ///public string PatientCurrentStatus { get; set; } //Alive, Dead unknown/lost to follow up
        ///public string HealthcareCentreType { get; set; }  //General Practitioner, hospital emergency room

    }
}
