using System.Collections.Generic;

namespace TestProjectApi.Core
{
    public class DTO
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string CoatOfArms { get; set; }
        public string Words { get; set; }
        public List<string> Titles { get; set; }
        public List<string> Seats { get; set; }
        public string CurrentLord { get; set; }
        public string Heir { get; set; }
        public string Overlord { get; set; }
        public string Founded { get; set; }
        public string Founder { get; set; }
        public string DiedOut { get; set; }
        public List<string> AncestralWeapons { get; set; }
        public List<string> CadetBranches { get; set; }
        public List<string> SwornMembers { get; set; }
    }
}
