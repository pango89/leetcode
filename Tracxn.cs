using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Tracxn
    {
        public void Solve(int numberOfDays, int numberOfIngredients, string[] ingredients)
        {
            int[] map = new int[3];

            List<string> remaining = new List<string>(ingredients);

            for (int i = 0; i < numberOfDays; i++)
            {
                string ingredient = ingredients[i];
                int category = GetCategory(ingredient);
                map[category]++;

                if (i + 1 < numberOfIngredients)
                {
                    Console.Write("-");
                    //Console.WriteLine("For i = {0} Print -", i);
                    continue;
                }

                int majority = (int)Math.Ceiling(0.6 * numberOfIngredients);
                int minority = numberOfIngredients - majority;
                List<string> ans = new List<string>();

                //Console.WriteLine("[{0}]", string.Join(", ", map));

                if (map.Sum() >= numberOfIngredients)
                {
                    int type = GetCategoryIndex(map, majority);
                    if (type == -1)
                    {
                        Console.Write("-");
                        //Console.WriteLine("No Majority Element Type");
                        continue;
                    }

                    int j = 0;
                    while (remaining.Count > 0)
                    {     
                            //Console.WriteLine("Minority = {0}, Majority = {1}", minority, majority);

                        if (majority == 0 && minority == 0)
                        {
                            Console.Write("{0}", string.Join(":", ans));
                            //Console.WriteLine("[{0}]", string.Join(", ", map));
                            break;
                        }
                        if (majority > 0 && GetCategory(remaining[j]) == type)
                        {
                            ans.Add(remaining[j]);
                            remaining.RemoveAt(j);
                            map[type]--;
                            majority--;
                            continue;
                        }
                        if (minority > 0)
                        {
                            //Console.WriteLine("Minority = {0}, Remaing J = {1}, J = {2}, CategoryRemainingJ = {3}", minority, remaining[j], j, GetCategory(remaining[j]));
                            ans.Add(remaining[j]);                            
                            map[GetCategory(remaining[j])]--;
                            remaining.RemoveAt(j);
                            minority--;
                            continue;
                        }

                        j++;
                    }

                    if(majority == 0 && minority == 0 && remaining.Count == 0)
                    {
                        Console.Write("{0}", string.Join(":", ans));
                       // Console.WriteLine("[{0}]", string.Join(", ", map));
                    }
                }
                else
                {
                    Console.Write("-");
                }
            }
        }

        private int GetCategoryIndex(int[] map, int majority)
        {
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] >= majority)
                    return i;
            }

            return -1;
        }

        private int GetCategory(string ingredient)
        {
            if (ingredient.Substring(0, 3) == "FAT")
                return 0;
            else if (ingredient.Substring(0, 4) == "CARB")
                return 1;
            else
                return 2;
        }
    }
}
