using test_site;

namespace site_testing.Model
{
    public class Test
    {
        public int Idtest { get; set; }
        public string NameTest { get; set; }
        public virtual ICollection<CompletedTest> CompletedTests { get; set; } = new List<CompletedTest>();
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
