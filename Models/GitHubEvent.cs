using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace GitHubActivity.Models
{
    public class GitHubEvent
    {
        public string Type { get; set; }
        public Repo Repo { get; set; }
    }
    public class Repo
    {
        public string Name { get; set; }
    }
}
