using System;
using System.Collections.Generic;
using System.Linq;
using MathAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class HackerRankAlgorithmsTests
    {
        [TestMethod]
        public void ExponentialTests()
        {
            MathFunctions.Instance.Exponential(5, 2)
                                  .Should()
                                  .Be(25);

            MathFunctions.Instance.Exponential(10, 10)
                          .Should()
                          .Be(10000000000);
        }

        [TestMethod]
        public void FactorialTests()
        {
            MathFunctions.Instance.Factorial(5)
                                  .Should()
                                  .Be(120);

            MathFunctions.Instance.Factorial(10)
                                  .Should()
                                  .Be(3628800);
        }

        [TestMethod]
        public void IsPrimeTest()
        {
            MathFunctions.Instance.IsPrime(5)
                                 .Should()
                                 .Be(true);

            MathFunctions.Instance.IsPrime(23)
                       .Should()
                       .Be(true);

            MathFunctions.Instance.IsPrime(33)
                    .Should()
                    .Be(false);
        }

        [TestMethod]
        public void DiagnolTest()
        {
            var matrix = new Matrix().GenerateMatrix(5);
            ArrayAlgorithms.Instance.SumDiagonalsOnMatrix(matrix);
        }

        [TestMethod]
        public void ReturnMeNRandomValuesFromAnArrayTest()
        {
            var myArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var randomNumbers = ArrayAlgorithms.Instance.GiveMeNRandomDistinctValuesFromAnArray(5, myArray);
            randomNumbers.Count().Should().Be(5);
            randomNumbers.Except(myArray)
                         .Any()
                         .Should()
                         .BeFalse();

            randomNumbers.ToList()
                         .ForEach(nbr => myArray.Contains(nbr)
                                                .Should()
                                                .BeTrue());
        }

        [TestMethod]
        public void Find2ndLargestTest()
        {
            var someArray = new int[] { 12, 18, 16, 7 };
            var secondLargest = ArrayAlgorithms.Instance.FindSecondLargestNumberInAnArray(someArray);
            secondLargest.Should()
                         .Be(16);
        }

        [TestMethod]
        public void FindLargestElementTest()
        {
            var someArray = new int[] { 12, 18, 16, 7, 10};
            var largest = ArrayAlgorithms.Instance.FindLargestElementInArray(someArray);
            largest.Should()
                         .Be(18);
        }

        [TestMethod]
        public void FindLargestWordInSentenceTest()
        {
            var someSentence = "Peyton Manning is the Greatest QB Ever";
            var largest = ArrayAlgorithms.Instance.FindLongestWordInSentence(someSentence);
            largest.Should()
                   .Be("Greatest");
        }

        [TestMethod]
        public void FindMostCharacterOccurancesInASentence()
        {
            var someSentence = "AAAA will have the most occurances. AAAA";
            var mostOccurances = ArrayAlgorithms.Instance.FindMostOccurancesOfACharacterInASentence(someSentence);
            mostOccurances.Item1
                          .Should()
                          .Be('A'); 
        }

        [TestMethod]
        public void ReverseAStringWithSplitMethodTest()
        {
            var someSentence = "the quick brown fox";
            var result = ArrayAlgorithms.Instance.ReverseWordsInAStringWithSplitMethod(someSentence);
            result.Should().BeEquivalentTo("fox brown quick the");


            var sentence2 = "hungry hippo";
            result = ArrayAlgorithms.Instance.ReverseWordsInAStringWithSplitMethod(sentence2);
            result.Should().BeEquivalentTo("hippo hungry");

            var sentence3 = "dog ate homework";
            result = ArrayAlgorithms.Instance.ReverseWordsInAStringWithSplitMethod(sentence3);
            result.Should().BeEquivalentTo("homework ate dog");

        }

        [TestMethod]
        public void ReverseAStringTest()
        {
            var someSentence = "the quick brown fox";
            var result = ArrayAlgorithms.Instance.ReverseWordsInAString(someSentence);
            result.Should().BeEquivalentTo("fox brown quick the");
        }

        [TestMethod]
        public void ShiftArrayLeft()
        {
            var someArray = new int[] { 12, 18, 16, 7, 10 };
            var expectedArray = new int[] { 16, 7, 10, 12, 18 };
            var shiftedArray = ArrayAlgorithms.Instance.ShiftArrayLeft(2, someArray);
            shiftedArray.Should()
                        .BeEquivalentTo(expectedArray);
        }

        [TestMethod]
        public void IsExpressionBalancedTest()
        {
            var unBalancedStatement = "[afads[ {";
            var result1 = ArrayAlgorithms.Instance.IsExpressionBalanced(unBalancedStatement);
            result1.Should().BeFalse();

            var balancedStatement = "[afads]";
            var result2 = ArrayAlgorithms.Instance.IsExpressionBalanced(balancedStatement);
            result2.Should().BeTrue();
        }

        [TestMethod]
        public void FindDuplicatesInArrayTest()
        {
            var array = new int[8] { 3, 1, 3, 4, 5, 1, 7, 7};
            var duplicates = ArrayAlgorithms.Instance.FindDuplicateValuesInArray(array);
            duplicates.Contains(1).Should().BeTrue();
            duplicates.Contains(3).Should().BeTrue();
            duplicates.Contains(7).Should().BeTrue();

            var duplicatesCSharp = ArrayAlgorithms.Instance.FindDuplicateValuesInArrayCSharp(array);
            duplicatesCSharp.Contains(1).Should().BeTrue();
            duplicatesCSharp.Contains(3).Should().BeTrue();
            duplicatesCSharp.Contains(7).Should().BeTrue();
        }

        [TestMethod]
        public void FindNthLargestInArray()
        {
            var array = new int[10] { 10, 8, 9, 4, 3, 7, 2, 1, 5, 6};
            var nthLargest = ArrayAlgorithms.Instance.FindNthLargestElementInArray(3, array);
            nthLargest.Should().Be(7);

            var arrayWithDuplicates = new int[15] { 10, 8, 9, 4, 3, 7, 2, 1, 5, 6, 1, 3, 3, 7, 9 };
            nthLargest = ArrayAlgorithms.Instance.FindNthLargestElementInArray(3, arrayWithDuplicates);
            nthLargest.Should().Be(7);
        }

        [TestMethod]
        public void FindFirstRecurringCharacter()
        {
            var txt = "ABCCDEFFGHHH";
            var firstRecurringCharacter = StringAlgorithms.Instance.FindFirstRecurringCharacter(txt);
            Assert.IsTrue(firstRecurringCharacter == 'C');
        }

        [TestMethod]
        public void IsStringBalanced()
        {
            var txt = "{|afbcsd}";
            var result = StringAlgorithms.Instance.DoesStringHaveClosingElement(txt);
            Assert.IsTrue(result);

            txt = "{|afbcsd}}";
            result = StringAlgorithms.Instance.DoesStringHaveClosingElement(txt);
            Assert.IsFalse(result);
        }

     
        [TestMethod]
        public void ItAppendsToTheEndOfALinkedList()
        {
            var parentNode = new LinkedListNode(18);
            var linkedList = new LinkedList(parentNode);
            linkedList.Append(12);
            linkedList.Append(9);
            linkedList.Append(7);
            linkedList.Count.Should().Be(4);
            linkedList.Display();
        }

        [TestMethod]
        public void ItRemovesAnItemAtTheEndOfALinkedList()
        {
            var parentNode = new LinkedListNode(18);
            var linkedList = new LinkedList(parentNode);
            linkedList.Append(12);
            linkedList.Append(9);
            linkedList.Append(7);
            linkedList.Remove();
            linkedList.Count.Should().Be(3);
            linkedList.Display();
        }
    }
}
