using System;
using System.Collections.Generic;

namespace Survey.Data.Models
{
    public partial class Respondent
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
