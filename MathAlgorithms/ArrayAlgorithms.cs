using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathAlgorithms
{
    public sealed class ArrayAlgorithms
    {
        private ArrayAlgorithms() { }
        private static readonly ArrayAlgorithms _Instance = new ArrayAlgorithms();
        public static ArrayAlgorithms Instance => _Instance;

        public IEnumerable<int> FindDuplicateValuesInArray(int []array)
        {
            if (array == null || array?.Length == 0)
                return null;

            var duplicates = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j] && !duplicates.Contains(array[i]))
                        duplicates.Add(array[i]);
                }
            }
            return duplicates;
        }

        public IEnumerable<int> FindDuplicateValuesInArrayCSharp(int[] array) {
            if (array == null || array.Length == 0) {
                return null;
            }

            var values = array.GroupBy(i => i)
                              .Where(j => j.Count() > 1)
                              .Select(k => k.Key);
            return values;
        } 

        public bool IsExpressionBalanced(string expression)
        {
            char openingParenthesis = '(', closingParenthesis = ')';
            char openingBracket = '[', closingBracket = ']';
            char openingBraces = '{', closingBraces = '}';

            var charArray = expression.ToCharArray();
            var stack = new Stack<char>(expression.Length);
            for (int c = 0; c < expression.Length; c++)
            {
                if (charArray[c] == openingParenthesis ||
                    charArray[c] == openingBracket ||
                    charArray[c] == openingBraces)
                {
                    stack.Push(charArray[c]);
                    continue;
                }

                if (charArray[c] == closingParenthesis)
                {
                    var character = stack.Pop();
                    if (character != openingParenthesis)
                        return false;
                }
                else if (charArray[c] == closingBracket)
                {
                    var character = stack.Pop();
                    if (character != openingBracket)
                        return false;
                }
                else if (charArray[c] == closingBraces)
                {
                    var character = stack.Pop();
                    if (character != openingBraces)
                        return false;
                }
            }

            if (stack.Count != 0)
                return false;

            return true;
        }

        public IEnumerable<int>GiveMeNRandomDistinctValuesFromAnArray(int nRandomValues, int[] arrayInput)
        {
            if (nRandomValues > arrayInput.Length)
                return null;

            var randomIndexGenerator = new Random();
            var randomValues = new List<int>();

            for (int i = 0; i < nRandomValues; i++)
            {
                int randomIndex = randomIndexGenerator.Next(0, arrayInput.Length - 1);
                if (!randomValues.Contains(arrayInput[randomIndex]))
                    randomValues.Add(arrayInput[randomIndex]);
                else
                    i--;
            }
            return randomValues;
        }

        public string ReverseWordsInAString(string sentence)
        {
            var words = new List<string>();
            var charArray = sentence.ToCharArray();
            int startIndex = 0, offSetIndex = 0;
            int copyRange;
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    var newArray = new char[offSetIndex];
                    Array.Copy(charArray, 0, newArray, 0, offSetIndex);
                    words.Add(new string(newArray));
                }

                if (charArray[i] == ' ')
                {
                    startIndex = i + 1;
                    if (words.Count == 0)
                    {
                        offSetIndex = charArray.Length - 1;
                        copyRange = (offSetIndex - startIndex) + 1;
                        offSetIndex = i;
                    }
                    else
                    {
                        copyRange = (offSetIndex - startIndex);
                        offSetIndex = i;
                    }
                    var newArray = new char[copyRange];
                    Array.Copy(charArray, startIndex, newArray, 0, copyRange);
                    words.Add(new string(newArray));
                }
            }

            return String.Join(" ", words.ToArray());
        }

        public string ReverseWordsInAStringWithSplitMethod(string sentence)
        {
            var wordsInSentence = sentence.Split(' ');
            for (int i = 0; i < (wordsInSentence.Length / 2); i++)
            {
                var currentWord = wordsInSentence[i];
                var swapIndex = (wordsInSentence.Length - 1) - i;
                wordsInSentence[i] = wordsInSentence[swapIndex];
                wordsInSentence[swapIndex] = currentWord;
            }
            return string.Join(" ", wordsInSentence);
        }

        public Tuple<char, int> FindMostOccurancesOfACharacterInASentence(string sentence)
        {
            if (sentence == null || sentence.Equals(string.Empty))
                return null;

            var occurances = new Dictionary<char, int>();
            foreach (var c in sentence)
            {
                if (Char.IsWhiteSpace(c))
                    continue;

                if (!occurances.ContainsKey(c))
                    occurances.Add(c, 1);
                else
                {
                    var count = occurances[c] + 1;
                    occurances[c] = count;
                }
            }

            int largestCount = 0;
            char charWithMostOccurances = ' ';
            foreach (var key in occurances.Keys)
            {
                if (occurances[key] > largestCount)
                {
                    charWithMostOccurances = key;
                    largestCount = occurances[key];
                }
            }
            return new Tuple<char, int>(charWithMostOccurances, largestCount);
        }

        public string FindLongestWordInSentence(string sentence)
        {
            if (sentence == null)
                return null;

            var words = sentence.Trim().Split(' ');

            if (words.Length == 0)
                return string.Empty;

            if (words.Length == 1)
                return words[0];

            var largestWord = string.Empty;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > largestWord.Length) {
                    largestWord = words[i];
                }
            }
            return largestWord;
        }

        public int FindLargestElementInArray(int[] array)
        {
            if (!array.Any()) return default(int);
            int largest = 0;

            foreach (var nbr in array)
            {
                if (nbr > largest)
                    largest = nbr;
            }
            return largest;
        }

        public int? FindSecondLargestNumberInAnArray(int[] array)
        {
            if (!array.Any()) return default(int);

            int? largest = null, secondLargest = null;

            foreach (var nbr in array)
            {
                //set the largest number to be the default first element
                if (!largest.HasValue)
                    largest = nbr;
                //iterate through the array and look for the largest and 2nd largest
                else if (nbr > largest.Value &&
                         largest.HasValue)
                {
                    secondLargest = largest;
                    largest = nbr;
                }
                //check that the 2nd largest is behind the largest
                else if (secondLargest.HasValue &&
                         nbr > secondLargest.Value &&
                         nbr < largest.Value)
                {
                    secondLargest = nbr;
                }
            }
            return secondLargest;
        }

        public long SumDiagonalsOnMatrix(List<MatrixItem> matrix)
        {
            /*
       1 2 3 4  
       5 6 7 8 
       9 1 2 3 
       2 2 2 2

       1 2 3 4 6
       5 6 7 8 7
       9 1 2 3 7
       2 2 2 2 9
       1 3 3 3 3
   */
            var result = matrix.FirstOrDefault().ColumnValues.ElementAt(0);
            for (int r = 1; r < matrix.Count; r++)
            {
                var rowValues = matrix.Where(rw => rw.RowNumber == r)
                                      .Single()
                                      .ColumnValues;
                result = result + rowValues.ElementAt(r);
            }
            return result;
        }

        public int[] ShiftArrayLeft(int positionShift, int[] array)
        {
            if (positionShift > array.Length)
                return null ;

            var startIndex = 0;
            for (var j = 0; j < positionShift; j++)
            {
                var newTailValue = array[startIndex];
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == array.Length - 1)
                        array[i] = newTailValue;
                    else
                        array[i] = array[i + 1];
                }
            }
            return array;
        }

        public int FindNthLargestElementInArray(int nthLargest, int[] array)
        {
            if (nthLargest > array.Length)
                return 0;

            var distinctArray = array.Distinct().ToArray();
            Array.Sort(distinctArray);
            return distinctArray.Distinct()
                        .ToArray()[(distinctArray.Length - 1) - nthLargest];
        }

        private void Swap(int[] array, int indexSwapFrom, int indexSwapTo)
        {
            var temp = array[indexSwapTo];
            array[indexSwapTo] = array[indexSwapFrom];
            array[indexSwapFrom] = temp;
        }

    }
}
