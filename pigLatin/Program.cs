using System;
using System.Collections.Generic;
using System.Linq;

namespace pigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;

            //GREETING
            Console.WriteLine("***** Hello and Welcome to the Nifty Pig Latin Translator!");

            //Begin loop for continuance
            while (cont)
            {

                Console.WriteLine("What would you like to translate?");
                
                //BEGIN TRANSLATION
                Translate();

                Console.WriteLine();

                //Ask user if they want to continue
                cont = ContinueProgram(cont);
            }

            //Say goodbye
            Console.WriteLine("Have a Terrific day! \n");
            
        }

        //Check each word for first instance of vowel. return index of the vowel
        public static int IndexOfVowel (string word)
        {
            string vowels = "aeiouy";

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (word[i] == vowels[j])
                    {
                        return i;
                    }
                }
            }
            return 1;
        }

        //Ask user if they want to continue
        public static bool ContinueProgram(bool cont)
        {
            Console.WriteLine("Would you like to continue? y/n");
            string input = Console.ReadLine();
            input = input.ToLower();

            while (cont)
            {
                //validate input
                if (input[0] == 'y')
                {
                    cont = true;
                    break;
                }
                else if (input[0] == 'n')
                {
                    cont = false;
                }
                else
                {
                    Console.WriteLine("Sorry, that is not a valid input. Please enter y/n.");
                    input = Console.ReadLine();
                    input = input.ToLower();
                }
            }
            return cont;
        }

        //Check each word for numbers and symbols
        public static bool ContainsNumsOrSymbols(string word)
        {
            string lookFor = "0123456789`~@#$%^&*()_=+{}[]|<>";

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < lookFor.Length; j++)
                {
                    if (word[i] == lookFor[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //String manipulation for translations
        public static void Translate()
        {
            //get input and convert to lowercase
            string input = Console.ReadLine();
            string lowerCase = input.ToLower();
            
            //put lowercase input into an array 
            string[] sentence = lowerCase.Split(' ');

            //create a list
            List<string> list = new List<string>();

            string newWord = "";


            foreach (string word in sentence)
            {
                //if word contains numbers or symbols, dont translate
                if (ContainsNumsOrSymbols(word))
                {
                    newWord = word;
                }
                else if (word[0] == 'y')
                {
                    newWord = word.Substring(1, word.Length - 1) + word[0] + "ay";
                }
                //determine if word begins with a vowel
                else if (word[0] == 'a' || word[0] == 'e' || word[0] == 'i' || word[0] == 'o' || word[0] == 'u')
                {
                    

                    newWord = word + "way";
                }
                //main word concatenation
                else
                {
                    string beginning = word.Substring(0, IndexOfVowel(word));

                    int start = IndexOfVowel(word);
                    int end = word.Length - start;

                    string middle = word.Substring(start, end);

                    newWord = middle + beginning + "ay";

                }

                //add each word to a list
                list.Add(newWord);
            }

            //convert list to array
            String[] newSentence = list.ToArray();

            //print translation
            foreach (string item in newSentence)
            {
                Console.Write(item + " ");
            }
        }
    }
}
