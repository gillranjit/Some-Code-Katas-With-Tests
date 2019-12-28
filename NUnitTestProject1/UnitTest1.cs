using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SolvedDigitsProblemShouldLookLikeTheSolution()
        {
            //Arrange
            string _numericDigitsProblem1 = "11118888833344";

            //Act
            IEnumerable<Tuple<int, int>> result = AggregateOperations.PrintAgggregateResults(_numericDigitsProblem1);
            string answerString = string.Join(",", result.Select(t => string.Format("{0}:{1}", t.Item1, t.Item2)));

            //Assert
            Assert.AreEqual(answerString, _numericDigitsSolutionToProblem1);
        }

        [Test]
        public void UnSolvedDigitsProblemShouldNotLookLikeTheSolution()
        {
            //Arrange
            string _numericDigitsProblem1 = "11111118888833344";

            //Act
            IEnumerable<Tuple<int, int>> result = AggregateOperations.PrintAgggregateResults(_numericDigitsProblem1);
            string answerString = string.Join(",", result.Select(t => string.Format("{0}:{1}", t.Item1, t.Item2)));

            //Assert
            Assert.AreNotEqual(answerString, _numericDigitsSolutionToProblem1);            
        }

        [TearDown]
        public void Tear()
        {

        }
        private string _numericDigitsProblem1 = "11118888833344";
        private string _numericDigitsSolutionToProblem1 = "8:5,1:4,3:3,4:2";
    }
}