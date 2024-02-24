using test_site;

namespace site_testing.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<CompletedTest> CompletedTests { get; set; } = new List<CompletedTest>();
    }
}
