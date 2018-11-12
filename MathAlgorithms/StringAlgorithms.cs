using System;
using System.Collections.Generic;
using System.Text;

namespace MathAlgorithms
{
    public sealed class StringAlgorithms
    {
        private StringAlgorithms() { }
        private static readonly StringAlgorithms _Instance = new StringAlgorithms();
        public static StringAlgorithms Instance => _Instance;

        public char FindFirstRecurringCharacter(string txt)
        {
            var characterArray = txt.ToCharArray();
            var characterOccurances = new Dictionary<char, int>();
            char firstRecurringCharacter = ' ';

            foreach (var character in characterArray)
            {
                if (!characterOccurances.ContainsKey(character))
                {
                    characterOccurances.Add(character, 1);
                }
                else
                {
                    firstRecurringCharacter = character;
                    break;
                }
            }
            return firstRecurringCharacter;
        }

        public bool DoesStringHaveClosingElement(string txt) {
            var startingDelimiterElement = '{';
            var closingDelimiterElement = '}';

            var occurances = 0;
            foreach (var character in txt.ToCharArray())
            {
                if (character == startingDelimiterElement) {
                    occurances++;
                }

                if (character == closingDelimiterElement) {
                    occurances--;
                }
            }

            if (occurances < 0)
                return false;
            else if (occurances == 0)
                return true;
            else
                return false;
        }

    }
}
