using System;
using System.Collections.Generic;
using StudentProject.Models;
using StudentProject.Validators;
using System.ComponentModel.DataAnnotations;

// using Newtonsoft.Json;


namespace StudentProject.Models;




public partial class StudentDatum

{   [Required(ErrorMessage = "StudentId is required")]
    [CustomStudentIdValidation(ErrorMessage = "StudentId must start with STDN followed by 5 digits")]
    public string StudentId { get; set; } = null!;

    [CustomGenderValidation(ErrorMessage = "Gender must be 'F' or 'M'")]
    public string Gender { get; set; } = null!;

    [CustomAlphabeticValidation(ErrorMessage = "Field must contain only alphabets and spaces, and start with an alphabet")]
    public string Nationlity { get; set; } = null!;

    [CustomAlphabeticValidation(ErrorMessage = "Field must contain only alphabets and spaces, and start with an alphabet")]
    public string PlaceOfBirth { get; set; } = null!;

     [CustomStageIdValidation(ErrorMessage = "StageId must be one of the following: lowerlevel, middleschool, highschool")]
    public string StageId { get; set; } = null!;

    [CustomGradeIdValidation(ErrorMessage = "GradeId must be in the format G followed by two digits (e.g., G01)")]
    public string GradeId { get; set; } = null!;

    [CustomSectionIdValidation(ErrorMessage = "SectionId must be either A or C")]
    public string SectionId { get; set; } = null!;

    [CustomTopicValidation(ErrorMessage = "Topic should contain only alphabets (A-Z, a-z)")]
    public string Topic { get; set; } = null!;

    [CustomSemesterValidation(ErrorMessage = "Semester should be either 'F' or 'S'")]
    public string Semester { get; set; } = null!;

    [CustomRelationValidation(ErrorMessage = "Relation must be either 'Father' or 'Mother'")]
    public string Relation { get; set; } = null!;

    [CustomDigitsValidation(ErrorMessage = "Value must be a number between 0 and 999")]
    public int RaisedHands { get; set; }

    [CustomDigitsValidation(ErrorMessage = "Value must be a number between 0 and 999")]
    public int VisitedResources { get; set; }

    [CustomDigitsValidation(ErrorMessage = "Value must be a number between 0 and 999")]
    public int AnnouncementsView { get; set; }

    [CustomDigitsValidation(ErrorMessage = "Value must be a number between 0 and 999")]
    public int Discussion { get; set; }

    [CustomYesNoValidation(ErrorMessage = "Value must be 'Yes' or 'No'")]
    public string ParentAnsweringSurvey { get; set; } = null!;

    [CustomGoodBadValidation(ErrorMessage = "Value must be 'Good' or 'Bad'")]
    public string ParentschoolSatisfaction { get; set; } = null!;

    [CustomAbsenceDaysValidation(ErrorMessage = "Value must be between 'Under-7' and 'Above-7'")]
    public string StudentAbsenceDays { get; set; } = null!;
     
     [CustomStudentMarksValidation(ErrorMessage = "Value must be a number between 0 and 100")] 
    public int StudentMarks { get; set; }

    [CustomClassesValidation(ErrorMessage = "Value must be 'M', 'L', or 'H'")]
    public string Classes { get; set; } = null!;

}
