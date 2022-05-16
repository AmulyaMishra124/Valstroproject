using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;

namespace V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the character Name:");
            string searchName = Console.ReadLine().ToLower();
            while (true) { 
                if (string.IsNullOrWhiteSpace(searchName))
                {
                    Console.WriteLine("Enter a valid string.");

                }
                else
                {
                    SearchPeople(searchName);
                    return;
                }
            }
            

        }

        public static void SearchPeople(string searchName)
        {
            try
            {

            
            using (var client = new HttpClient())
            {
                var endPoint = new Uri("https://www.swapi.tech/api/people");
                var result = client.GetAsync(endPoint).Result.Content.ReadAsStringAsync().Result;
                var peopleColl = JsonConvert.DeserializeObject<Starwars>(result);
                    bool found = false;
                Console.WriteLine("Search Details:");

                foreach (people item in peopleColl.results)
                {
                    if (item.name.ToLower().Contains(searchName.ToLower()))
                    {
                            Console.WriteLine(item.name);
                            found = true;
                    }
                     
                 }
                    if (!found) { Console.WriteLine("No results found."); }
                Console.ReadLine();
               }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }

}
