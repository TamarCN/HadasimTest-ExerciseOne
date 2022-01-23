using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadasimExercise
{
    class ExerciseOne
    {
        
        Dictionary<string, int> Names = new Dictionary<string, int>();
        Dictionary<string, string> Synonyms = new Dictionary<string, string>();
        //A new Dictionay of the true frequencies of each name 
        Dictionary<string, int> amountNames = new Dictionary<string, int>();
        //List of the all Synonym 
        List<List<string>> unitSynonym = new List<List<string>>();

        //This fuction includes all the stages for getting the real list of the most common names 
        public void TheMostCommonNames()
        {
            InitializeDictionary();//This function reads the files into the dictionaries
            MergeSynonym();//This function merges the Synonyms
            AmountAppearanceOfSynonym();//Sum up the appearances of the Synonyms and print them
        }

        //This function reads the files into the dictionaries
        public void InitializeDictionary()
        {
            
            string file1 = @"\Files\Names.txt";
            string file2 = @"\Files\Synonyms.txt";
            string name, synonym;
            int amount;
            if (File.Exists(file1))
            {
                string[] namesAndAges = File.ReadAllLines(file1);
                foreach (string n in namesAndAges)
                {
                    name = n.Substring(0, n.IndexOf(' '));
                    amount = Int32.Parse(n.Substring(n.IndexOf(' ')+1));
                    Names.Add(name, amount);
                }
               
            }
            if (File.Exists(file2))
            {
                string[] namesAndAges = File.ReadAllLines(file2);
                foreach (string n in namesAndAges)
                {
                    name = n.Substring(0, n.IndexOf(' '));
                    synonym = n.Substring(n.IndexOf(' ')+1);
                    Synonyms.Add(name, synonym);
                }

            }
        }

        //This function merges the Synonyms 
        public void MergeSynonym()
        {
            //the index of the list in unitSynonym
            int numberl = 0;
            string value, key;
            while(Synonyms.Any())
            {
                key = Synonyms.ElementAt(0).Key;
                value = Synonyms.ElementAt(0).Value;
                unitSynonym.Add(new List<string> { key });
                unitSynonym.ElementAt(numberl).Add(value);
                Synonyms.Remove(key);
                FindAllSynonym(key, value, numberl);
                numberl++;

            }
        }

        //Recursive function that finds the Synonym for each name
        public void FindAllSynonym(string key, string value ,int numberl)
        {
            string str;

            //Looking for the values that are identical to the key
            if (Synonyms.ContainsValue(key))
            {
                str = Synonyms.FirstOrDefault(x => x.Value == key).Key;
                Synonyms.Remove(str);
                unitSynonym.ElementAt(numberl).Add(str);
                FindAllSynonym(str, key, numberl);
            }

            //Looking for the key that is identical to the value 
            if (Synonyms.ContainsKey(value) == true)
            {
                str = Synonyms.FirstOrDefault(x => x.Key == value).Value;
                Synonyms.Remove(value);
                unitSynonym.ElementAt(numberl).Add(str);
                FindAllSynonym(value, str, numberl);
            }

            //Looking for the values that are identical to the value
            if (Synonyms.ContainsValue(value) == true)
            {
                str = Synonyms.FirstOrDefault(x => x.Value == value).Key;
                Synonyms.Remove(str);
                unitSynonym.ElementAt(numberl).Add(str);
                FindAllSynonym(str, value, numberl);
            }
        }

        //Sum up the appearances of the Synonyms and print them
        public void AmountAppearanceOfSynonym()
        {
            foreach (var list in unitSynonym)
            {
                amountNames.Add(list[0], 0);
                foreach (var item in list)
                {
                    amountNames[list[0]] += Names[item];
                    Names[item] = 0;
                }
            }
            foreach (var item in Names)
            {
                if (item.Value != 0)
                    amountNames.Add(item.Key,item.Value);
            }
            foreach (var item in amountNames)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }






    }
}
