using System.Collections.Generic;

namespace DatabaseAsService.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public ICollection<SessionKeywordMapping> SessionMappings { get; set; }
    }
}
