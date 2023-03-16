using FluentValidation;
using KusysDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusysDemo.Business.FValidator
{
    public class StudentValidator : AbstractValidator <Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("İsim boş bırakılamaz");
            RuleFor(s => s.LastName).NotEmpty().WithMessage("Soyisim boş bırakılamaz");
            RuleFor(s => s.BirthDate).LessThan(DateTime.Now.AddYears(-18)).WithMessage("Yaş Sorunu");
        }
    }
}
