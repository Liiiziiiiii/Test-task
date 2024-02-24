using System.Collections.Generic;

namespace site_testing.Model
{
    public class CompletedTest
    {
        public int IdCompletedTest { get; set; }

        // Foreign key properties
        public int TestId { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public virtual Test Test { get; set; }
        public virtual User User { get; set; }
    }
}
