using System;
using System.Collections.Generic;

namespace Survey.Data.Models
{
    public partial class SurveyAnswer
    {
        public Guid Id { get; set; }
        public Guid RespondentId { get; set; }
        public Guid SurveyId { get; set; }
        public Guid QuestionId { get; set; }
        public int Weight { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
