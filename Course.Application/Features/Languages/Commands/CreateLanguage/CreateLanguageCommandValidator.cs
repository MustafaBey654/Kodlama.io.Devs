﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommandValidator:AbstractValidator<CreateLanguageCommand>
    {

        public CreateLanguageCommandValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
            RuleFor(l => l.Name).MinimumLength(2);
        }
    }
}
