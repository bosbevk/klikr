using System;
using System.Collections.Generic;

namespace Survey.Data.Models
{
    public partial class Question
    {
        public Question()
        {
            SurveyExpectations = new HashSet<SurveyExpectation>();
            SurveyQuestions = new HashSet<SurveyQuestion>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<SurveyExpectation> SurveyExpectations { get; set; }
        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; }
    }
}
