using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubActivity.Services;
using GitHubActivity.UI;

namespace GitHubActivity
{
    class Program
    {
       
        static async Task Main(string[] args)
        {
           
            if (args.Length == 0)
            {
                Console.WriteLine("Hata: Lütfen bir kullanıcı adı girin.");
                Console.WriteLine("Kullanım: github-activity <username>");
                Console.WriteLine("\nÇıkmak için bir tuşa basın...");
                Console.ReadKey();
                return;
            }

            string username = args[0];
            var gitHubService = new GitHubService();

            try
            {
                Console.WriteLine($"{username} için son etkinlikler getiriliyor...\n");

                // 2. Veriyi çek
                var events = await gitHubService.GetUserActivityAsync(username);

                // 3. Ekrana yazdır
                ActivityPrinter.Print(events, username);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }

            
            Console.WriteLine("\nİşlem tamamlandı. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}