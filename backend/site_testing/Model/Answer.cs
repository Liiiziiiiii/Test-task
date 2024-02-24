using System;
using System.Collections.Generic;

namespace test_site;

public partial class Answer
{
    public int QuestionId { get; set; }

    public string Question { get; set; } = null!;

    public int Mark { get; set; }

    public int QuestionIdQuestion { get; set; }

    public int QuestionTestId { get; set; }

    public virtual Question QuestionNavigation { get; set; } = null!;
}
