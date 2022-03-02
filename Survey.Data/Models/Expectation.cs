using System;
using System.Collections.Generic;

namespace Survey.Data.Models
{
    public partial class Expectation
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public int Weight { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual Survey Survey { get; set; } = null!;
    }
}
