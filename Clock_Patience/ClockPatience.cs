using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock_Patience
{
    internal class ClockPatience
    {
        static Tuple<int, string> PlayClockPatience(List<string> deck)
        {
            List<string>[] piles = new List<string>[14];
            for (int i = 0; i < 14; i++)
            {
                piles[i] = new List<string>();
            }

            foreach (var card in deck)
            {
                string rank = card.Substring(0, card.Length - 1);
                piles[int.Parse(rank)].Add(card);
            }

            string currentCard = piles[13][piles[13].Count - 1];
            piles[13].RemoveAt(piles[13].Count - 1);
            int exposedCount = 1;

            while (piles[int.Parse(currentCard.Substring(0, currentCard.Length - 1))].Count > 0)
            {
                exposedCount++;
                currentCard = piles[int.Parse(currentCard.Substring(0, currentCard.Length - 1))][piles[int.Parse(currentCard.Substring(0, currentCard.Length - 1))].Count - 1];
                piles[int.Parse(currentCard.Substring(0, currentCard.Length - 1))].RemoveAt(piles[int.Parse(currentCard.Substring(0, currentCard.Length - 1))].Count - 1);
            }

            return Tuple.Create(exposedCount, currentCard);
        }

        static void Main()
        {
            List<List<string>> decks = new List<List<string>>();
            string line;

            while (true)
            {
                line = Console.ReadLine().Trim();
                if (line == "#")
                {
                    break;
                }

                decks.Add(new List<string>(line.Split()));
            }

            foreach (var deck in decks)
            {
                var result = PlayClockPatience(deck);
                Console.WriteLine($"{result.Item1:D2},{result.Item2}");
            }
        }
    }

}

