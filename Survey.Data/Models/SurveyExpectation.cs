using System;
using System.Collections.Generic;

namespace Survey.Data.Models
{
    public partial class SurveyExpectation
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public Guid QuestionId { get; set; }
        public int Weight { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual Survey Survey { get; set; } = null!;
    }
}
