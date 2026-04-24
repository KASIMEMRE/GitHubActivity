using GitHubActivity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubActivity.UI
{
    public static class ActivityPrinter
    {
        public static void Print(List<GitHubEvent> events, string username)
        {
            Console.WriteLine($"\n--- Recent Activity for {username} ---");

            foreach (var ev in events.Take(15)) // Son 15 etkinlik
            {
                string message;
                switch (ev.Type)
                {
                    case "PushEvent":
                        message = $"- Pushed commits to {ev.Repo.Name}";
                        break;
                    case "WatchEvent":
                        message = $"- Starred {ev.Repo.Name}";
                        break;
                    case "IssuesEvent":
                        message = $"- Opened an issue in {ev.Repo.Name}";
                        break;
                    case "CreateEvent":
                        message = $"- Created {ev.Repo.Name}";
                        break;
                    default:
                        message = $"- {ev.Type} at {ev.Repo.Name}";
                        break;
                }
                Console.WriteLine(message);  
            }
        }
    }
}