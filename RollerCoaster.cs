using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        decimal totalEarning = 0;
        Dictionary<int, Tuple<int, decimal>> previousTours = new Dictionary<int, Tuple<int, decimal>>();
        string[] inputs = Console.ReadLine().Split(' ');
        int L = int.Parse(inputs[0]);
        int C = int.Parse(inputs[1]);
        int N = int.Parse(inputs[2]);
        List<int> queue = new List<int>();
        for (int i = 0; i < N; i++)
        {
            int pi = int.Parse(Console.ReadLine());
            queue.Add(pi);
        }

        int index = 0;
        for (int i = 0; i < C; i++)
        {
            int peopleCount = 0;
            HashSet<int> activelyParticipants = new HashSet<int>();
            int first = index;
            int tourGroupCount = 0;
            if (previousTours.ContainsKey(first))
            {
                totalEarning += previousTours[first].Item2;
                index = index + previousTours[first].Item1 >= N ? index + previousTours[first].Item1 - N : index + previousTours[first].Item1;

                continue;
            }

            decimal tourEarning = 0;
            while (peopleCount < L)
            {
                int x = queue[index];
                if (activelyParticipants.Contains(index))
                {
                    break;
                }
                peopleCount += x;
                if (peopleCount > L)
                {
                    peopleCount -= x;
                    break;
                }
                else
                {
                    totalEarning += x;
                    tourEarning += x;
                    activelyParticipants.Add(index);
                    tourGroupCount++;
                    index = index + 1 >= N ? 0 : index + 1;
                }
            }
            previousTours.Add(first, new Tuple<int, decimal>(tourGroupCount, tourEarning));
        }

        Console.WriteLine(totalEarning);
    }
}
