﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.AssignmentList
{
    public class AssignmentListQueryValidator : AbstractValidator<AssignmentListQuery>
    {
        public AssignmentListQueryValidator()
        {
        }
    }
}
