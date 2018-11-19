using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public class DistinctStack
    {
        private List<int> _Indices;

        public DistinctStack()
        {
            _Indices = new List<int>();
        }

        public void Push(int value) => _Indices.Add(value);

        public int Pop()
        {
            //i'm using a GroupBy expression here to get the number of occurances for each number 
            //and sorting it where the number with the most occurances is at the bottom of the collection
            var mostOccurences = _Indices.GroupBy(i => i)
                                         .Select(j => new
                                         {
                                             Number = j.Key,
                                             Count = j.Count()
                                         })
                                         .OrderBy(i => i.Count);

            var value = mostOccurences.LastOrDefault();

            //i'm removing the most recent occurance from the top of the stack  
            for (var i = _Indices.Count - 1; i >= 0; i--)
            {
                if (_Indices[i] == value.Number)
                {
                    _Indices.RemoveAt(i);
                    break;
                }
            }

            return value.Number;
        }
    }

    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void ItPopsTheNumbersWithTheMostOccurances()
        {
            var stack = new DistinctStack();
            stack.Push(1);
            stack.Push(1);
            stack.Push(1);
            stack.Push(1);
            stack.Push(2);
            stack.Push(2);
            stack.Push(3);
            stack.Push(3);

            var result = stack.Pop();
            Assert.IsTrue(result == 1);
            result = stack.Pop();
            Assert.IsTrue(result == 1);
            result = stack.Pop();
            Assert.IsTrue(result == 3);
            result = stack.Pop();
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void ItPopsTheNumbersClosestToTheTopOfTheStack()
        {
            var stack = new DistinctStack();
            stack.Push(1);
            stack.Push(1);
            stack.Push(2);
            stack.Push(2);
            stack.Push(4);
            stack.Push(4);
            stack.Push(3);
            stack.Push(3);
            stack.Push(5);
            stack.Push(5);

            var result = stack.Pop();
            Assert.IsTrue(result == 5);
            result = stack.Pop();
            Assert.IsTrue(result == 3);
            result = stack.Pop();
            Assert.IsTrue(result == 4);
            result = stack.Pop();
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void ItPopsInOrderWhenThereAreNoDuplicates()
        {
            var stack = new DistinctStack();
            stack.Push(9);
            stack.Push(1);
            stack.Push(2);
            stack.Push(5);

            var result = stack.Pop();
            Assert.IsTrue(result == 5);
            result = stack.Pop();
            Assert.IsTrue(result == 2);
            result = stack.Pop();
            Assert.IsTrue(result == 1);
            result = stack.Pop();
            Assert.IsTrue(result == 9);
        }
    }
}
