using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock_Patience
{
    internal class ClockPatience
    {
         static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "#")
            {
                string[] deck = input.Split();
                Console.WriteLine(PlayClockPatience(deck));
            }
        }

        static string PlayClockPatience(string[] deck)
        {
            List<Stack<string>> piles = new List<Stack<string>>();
            for (int i = 0; i < 13; i++)
            {
                piles.Add(new Stack<string>());
            }

            for (int i = 0; i < 52; i++)
            {
                piles[i % 13].Push(deck[i]);
            }

            string currentCard = piles[12].Peek();
            int exposedCards = 1;

            while (true)
            {
                int pileIndex = (currentCard[0] - 'A' + 1) % 13;
                if (piles[pileIndex].Count == 0)
                {
                    break;
                }

                currentCard = piles[pileIndex].Pop();
                exposedCards++;
            }

            return $"{exposedCards:00}, {currentCard}";
        }
    }

}

