using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobApplicationPortal.Models;

public class JobApplication
{
    [Key]
    public int Id { get; set; }

    // Basic Details
    [Required]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Address { get; set; }

    public string? Gender { get; set; }

    [Required]
    [Phone]
    public string? Contact { get; set; }

    // Education Details (consider using a separate class for clarity)
    public List<EducationDetail> EducationDetails { get; set; } = [];

    // Work Experience (consider using a separate class for clarity)
    public List<WorkExperience> WorkExperiences { get; set; } = [];

    // Known Languages
    public List<KnownLanguage> KnownLanguages { get; set; } = [];

    // Technical Experience
    public List<TechnicalSkill> TechnicalSkills { get; set; } = [];

    // Preference
    public string? PreferredLocation { get; set; }
    public decimal ExpectedCTC { get; set; }
    public decimal CurrentCTC { get; set; }
    public int NoticePeriod { get; set; }
}

public class EducationDetail
{
    public int Id { get; set; }

    [ForeignKey("JobApplicationId")]
    public int JobApplicationId { get; set; } // Foreign key
    public string? BoardUniversity { get; set; }
    public int Year { get; set; }
    public decimal CGPA { get; set; } // Or Percentage
}

public class WorkExperience
{
    public int Id { get; set; }

    [ForeignKey("JobApplicationId")]
    public int JobApplicationId { get; set; } // Foreign key
    public string? Company { get; set; }
    public string? Designation { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; } // Can be nullable for current job
}

public class KnownLanguage
{
    public int Id { get; set; }

    [ForeignKey("JobApplicationId")]
    public int JobApplicationId { get; set; } // Foreign key
    public LanguageEnum Language { get; set; }
    public bool CanRead { get; set; }
    public bool CanWrite { get; set; }
    public bool CanSpeak { get; set; }
}

public class TechnicalSkill
{
    public int Id { get; set; }

    [ForeignKey("JobApplicationId")]
    public int JobApplicationId { get; set; } // Foreign key
    public string? Technology { get; set; }
    public string? ProficiencyLevel { get; set; } // Beginner, Intermediate, Expert
}

public enum LanguageEnum
{
    Hindi,
    English,
    Gujarati
}