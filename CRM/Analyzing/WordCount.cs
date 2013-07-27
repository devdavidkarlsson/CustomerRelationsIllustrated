//David Karlsson 20120828
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM
{
    /// <summary>
    /// Static class to count good and bad words in strings of sentences.
    /// </summary>
    public static class WordCount
    {

        private static string[] badWords = { "dålig", "dåligt", "arg", "besviken", "ledsen", "otrevlig", "oklar", "fundersam", "osäker", "avtrubbad", "negativ", "nej", "tveka", "misslycka", "missnöjd", "mad", "sad", "angry", "unhappy", "stressed", "bad", "unfortunately","unfortunate"};

       private static string[] goodWords = { "bra", "glad", "nöjd", "lycka", "trevlig", "intresserad","happy","pleased", "interested", "good" };


        /// <summary>
        /// Get all talks from a customer and analyze them
        /// </summary>
        /// <param name="cust">Customer to analyze</param>
        /// <returns>returns an integer value weighting the good against the bad where 100 is neutral</returns>
        public static int AnalyzeCustomer(Customer cust){
            int result=100;
            foreach (Contact contact in cust.getContacts())
            {
                result += AnalyzeWords(contact.getTalks());
            }
            return result;
        }

        /// <summary>
        /// Analyze words in a string
        /// </summary>
        /// <param name="talk">string of words to analyze</param>
        /// <returns>returns a value weighing the good words against the bad</returns>
        public static int AnalyzeWords(string talk){
            int weight=0; // Maybe make dependent on number of words…
            char[] delim={',', ' ', '.'};
            string[] words= talk.Split(delim);
            if(words.Length>1){
                foreach (string word in words)
                {
                    foreach (string goodWord in goodWords)
                    {
                        if (goodWord.Equals(word.ToLower()))
                        {
                            weight += 10;
                        }
                    }
                    foreach (string badWord in badWords)
                    {
                        if (badWord.Equals(word.ToLower()))
                        {
                            weight -= 10; ;
                        }
                    }
                }
            }
            return weight; // Weight >100 => overall positive feedback, weight<100 bad feedback needs attention.
        }

    }
}
