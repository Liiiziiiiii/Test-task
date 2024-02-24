using site_testing.Model;
using System;
using System.Collections.Generic;

namespace test_site;

public partial class Question
{
    public int IdQuestion { get; set; }

    public int TestId { get; set; }

    public string Question1 { get; set; } = null!;

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Test Test { get; set; } = null!;
}
