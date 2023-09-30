using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using StudentProject.Models;

namespace StudentProject.Validators
{ 
    //To validate StudentID:
   [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
sealed class CustomStudentIdValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string studentId && Regex.IsMatch(studentId, "^STDN\\d{5}$"))
        {
            return true;
        }

        return value == null;
    }
}


//
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomGenderValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string gender && Regex.IsMatch(gender, "^[FM]$"))
            {
                return true;
            }

            return false;
        }


}

// Custom validation attribute to validate Nationality and PlaceOfBirth
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomAlphabeticValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string text && Regex.IsMatch(text, "^[A-Za-z ]+$"))
            {
                return true;
            }

            return false;
        }
    }

    
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomStageIdValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string stageId && (stageId == "lowerlevel" || stageId == "middleschool" || stageId == "highschool"))
            {
                return true;
            }

            return false;
        }
    }


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
sealed class CustomRelationValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string relation && (relation == "father" || relation == "mother"))
        {
            return true;
        }

        return false;
    }
}

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomGradeIdValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string gradeId && Regex.IsMatch(gradeId, "^G\\d{2}$"))
            {
                return true;
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomSectionIdValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string sectionId && (sectionId == "A" || sectionId == "C"))
            {
                return true;
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomTopicValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string topic && Regex.IsMatch(topic, "^[a-zA-Z]+$"))
            {
                return true;
            }

            return false;
        }
    }

     [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomSemesterValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string semester && (semester == "F" || semester == "S"))
            {
                return true;
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomDigitsValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is int number && number >= 0 && number <= 999)
            {
                return true;
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomYesNoValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string answer && (answer == "yes" || answer == "no"))
            {
                return true;
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomGoodBadValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string satisfaction && (satisfaction == "good" || satisfaction == "bad"))
            {
                return true;
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomAbsenceDaysValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string days && int.TryParse(days, out int daysValue) && daysValue >= -7 && daysValue <= 7)
            {
                return true;
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomStudentMarksValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is int marks && marks >= 0 && marks <= 100)
            {
                return true;
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CustomClassesValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string classes && (classes == "M" || classes == "L" || classes == "H"))
            {
                return true;
            }

            return false;
        }
    }


}

