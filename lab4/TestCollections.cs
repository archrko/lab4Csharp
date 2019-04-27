using System;
using System.Collections.Generic;

namespace lab4
{
    class TestCollections
    {
        public List<Edition> edition;
        public List<string> strEdition;
        public Dictionary<Edition, Magazine> editionAndMagazine;
        public Dictionary<string, Magazine> strMagazine;
        public static Magazine GenerateData(int n)
        {                  
            var articles = new List<Article>();
            var editors = new List<Person>();
            Frequency qwe = Frequency.Yearly;
            switch (n % 3)
            {
                case 0:
                    qwe = Frequency.Monthly;
                    break;
                case 1:
                    qwe = Frequency.Weekly;
                    break;
                case 2:
                    qwe = Frequency.Yearly;
                    break;                
            }           
            for (int i = 0; i < 10; i++)
            {
                editors.Add(new Person("Person" + i, "",
                        new DateTime(1970 + i % 40, 1+ i % 12, 1 + i % 27)));
                articles.Add(new Article(editors[i], "Article" + i, i*i % 10));
            }
            return new Magazine("Magazine" + n,
                    new DateTime(2000 + n % 20, 1 + n % 12, 1 + n % 28), n*50 % 1000,
                qwe, articles, editors);
        }
        public TestCollections(int n)
        {                        
            edition = new List<Edition>();
            strEdition = new List<string>();
            editionAndMagazine = new Dictionary<Edition, Magazine>();
            strMagazine = new Dictionary<string, Magazine>();
            for (int i = 0; i < n; i++)
            {
                edition.Add(GenerateData(i).EditionValues);
                strEdition.Add(edition[i].ToString());
                editionAndMagazine.Add(edition[i], GenerateData(i));
                strMagazine[strEdition[i]] = editionAndMagazine[edition[i]];
            }                                              
        }
        public Dictionary<string,int> GetTime(Magazine search)
        {
            var time = new Dictionary<string,int>();
            int n = edition.Count;
            long startTime = DateTime.UtcNow.Ticks;
            edition.Contains(search.EditionValues);
            time.Add("edition",(int)(DateTime.UtcNow.Ticks - startTime));

            startTime = DateTime.UtcNow.Ticks;
            strEdition.Contains(search.EditionValues.ToString());
            time.Add("strEdition",(int)(DateTime.UtcNow.Ticks - startTime));

            startTime = DateTime.UtcNow.Ticks;
            editionAndMagazine.ContainsKey(search.EditionValues);
            time.Add("E&M_Key",(int)(DateTime.UtcNow.Ticks - startTime));

            startTime = DateTime.UtcNow.Ticks;
            strMagazine.ContainsKey(search.EditionValues.ToString());
            time.Add("str&M_Key",(int)(DateTime.UtcNow.Ticks - startTime));

            startTime = DateTime.UtcNow.Ticks;
            editionAndMagazine.ContainsValue(search);
            time.Add("E&M_Value",(int)(DateTime.UtcNow.Ticks - startTime));

            startTime = DateTime.UtcNow.Ticks;
            strMagazine.ContainsValue(search);
            time.Add("str&M_Value",(int)(DateTime.UtcNow.Ticks - startTime));
            if(strMagazine.ContainsKey(search.EditionValues.ToString()))
                Console.WriteLine("Exist");
            else Console.WriteLine("Such Magazine not found");
            return time;
        }

    }
}
