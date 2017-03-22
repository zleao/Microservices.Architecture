using System.Collections.Generic;

namespace DatabaseAsService.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<SessionKeywordMapping> SessionMappings { get; set; }
    }
}
