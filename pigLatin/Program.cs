using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;

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

                //Console.WriteLine("What would you like to translate?");

                //BEGIN TRANSLATION

                Translate();

                Console.WriteLine(); Console.WriteLine();

                //Ask user if they want to continue
                cont = ContinueProgram(cont);
            }

            //Say goodbye
            Console.WriteLine("Have a Terrific day! \n");
            
        }

        /*
        public static int[] Upper (string originalSentence)
        {
            List<int> list = new List<int>();

            foreach()
        }
        */

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

        //trim ending punctuation
        public static string Punctuation (string word)
        {
            string punct = "!?,.;:";

            string s = "";

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < punct.Length; j++)
                {
                    if (word[i] == punct[j])
                    {
                        //Console.WriteLine(word.IndexOf(word[i]));
                        //Console.WriteLine(word.Length);

                        s = word.Substring(word.IndexOf(word[i]));

                        //Console.WriteLine(s);
                        return s;
                    }
                }
            }

            return s;
        }

        //Ask user if they want to continue
        public static bool ContinueProgram(bool cont)
        {
            string input = "";
            while (input.Trim() == "")
            {
                Console.WriteLine("Would you like to continue? y/n");
                input = Console.ReadLine();
                input = input.ToLower();
            }


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
            string input = "";
            while (input.Trim() == "")
            {
                Console.WriteLine("Please enter some text to translate.");
                Console.WriteLine();
                input = Console.ReadLine();
            }
            
            string lowerCase = input.ToLower();

            //put lowercase input into an array 

            string[] sentence = lowerCase.Split(' ', StringSplitOptions.RemoveEmptyEntries);


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
                    if (Punctuation(word) == "")
                    {
                        newWord = word.Substring(1, word.Length - 1) + word[0] + "ay" + Punctuation(word);  
                    }
                    else
                    {
                        string cutword = word.Replace(Punctuation(word), "");
                        newWord = cutword.Substring(1, cutword.Length - 1) + cutword[0] + "ay" + Punctuation(word);
                    }                    
                }
                //determine if word begins with a vowel
                else if (IndexOfVowel(word) == 0)
                {
                    if (Punctuation(word) == "")
                    {
                        newWord = word + "way";
                    }
                    else
                    {
                        string cutword = word.Replace(Punctuation(word), "");
                        newWord = cutword + "way" + Punctuation(word);
                    }
                    
                }
                //main word concatenation
                else
                {
                    if (Punctuation(word) == "")
                    {
                        string beginning = word.Substring(0, IndexOfVowel(word));

                        int start = IndexOfVowel(word);
                        int end = word.Length - start;

                        string middle = word.Substring(start, end);
                        newWord = middle + beginning + "ay" + Punctuation(word);
                    }
                    else
                    {
                        string cutword = word.Replace(Punctuation(word), "");
                        string beginning = cutword.Substring(0, IndexOfVowel(cutword));

                        int start = IndexOfVowel(cutword);
                        int end = cutword.Length - start;

                        string middle = cutword.Substring(start, end);
                        newWord = middle + beginning + "ay" + Punctuation(word);
                    }                    

                }

                string[] originalSentence = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string wrd in originalSentence)
                {
                    List<int> myList = new List<int>();

                    for (int i = 0; i < wrd.Length; i++)
                    {
                        if (Char.IsUpper(wrd[i]))
                        {
                            myList.Add(i);
                            //Console.WriteLine("yes" + i);
                        }
                        else
                        {
                            //Console.WriteLine("no");
                        }
                    }


                    
                    int[] convert = myList.ToArray();
                    //Console.WriteLine("My list: ");

                    foreach (int item in convert)
                    {
                        string adjustCase = "";

                        for (int i = 0; i < word.Length; i++)
                        {
                            if (newWord.IndexOf(word[i]) == item)
                                {
                                    //Console.WriteLine(true);
                                    
                                    string character = word.Substring(i, 1);
                                    character.ToUpper();
                                    adjustCase += character.ToUpper();
                                    //Console.WriteLine("DO IT!");
                                    
                                }
                            else
                            {
                                string character = word.Substring(i, 1);
                                adjustCase += character;
                                //Console.WriteLine(false);
                            }
                            //for (int j = 0; j < convert.Length; j++)
                            //{
                                
                                //else
                                //{
                                //    Console.WriteLine(false);
                                    
                                //    character = newWord.Substring(i, 1);
                                //    adjustCase += character;
                                    
                                //}
                            //}

                        }

                        //Console.WriteLine();
                        //Console.WriteLine("Adjusted: " + adjustCase);

                        //newWord = adjustCase;
                    }
        

                }

                //add each word to a list
                list.Add(newWord);
            }

            //convert list to array
            String[] newSentence = list.ToArray();

            //print translation
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string item in newSentence)
            {
                Console.Write(item + " ");
            }
            Console.ResetColor();

        }
    }
}
