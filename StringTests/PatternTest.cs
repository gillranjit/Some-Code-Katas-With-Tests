using NUnit.Framework;
using ConsoleApp1;

namespace StringTests
{
    public class PatternTest
    {
        /*
        create a function that parses a string and returns valid or not

        example:
        () = true
        (( = false
        )( = false
        (() = false
        (hello) = true
        )hello( = false
        */

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PassingTestOfPatternBuilder_Inclusion()
        {
            //Arrange
            string testString = "dfsgdsgf(()((hello)stringcontinued";

            //Act
            var result = testString
                .TestStringForPattern("((")
                .TestStringForPattern(")(")
                .TestStringForPattern("(")
                .TestStringForPattern("hello")
                .TestStringForPattern(")");

            //Assert
            Assert.True(!result.Contains(INVALID));
        }

        [Test]
        public void FailingTestOfPatternBuilder_Inclusion()
        {
            //Arrange
            string testString = "dfsgdsgf(()(()stringcontinued";

            //Act
            var result = testString.TestStringForPattern("hello");

            //Assert
            Assert.True(result.Contains(INVALID));
        }

        [Test]
        public void PassingTestOfPatternBuilder_Exclusion()
        {
            //Arrange
            string testString = "dfsgdsgf(()(()stringcontinued";

            //Act
            var result = testString.TestStringForPattern("hello",false);

            //Assert
            Assert.True(!result.Contains(INVALID));
        }

        [Test]
        public void FailingTestOfPatternBuilder_Exclusion()
        {
            //Arrange
            string testString = "dfsgdsgf(()((hello)stringcontinued";

            //Act
            var result = testString.TestStringForPattern("hello", false);

            //Assert
            Assert.True(result.Contains(INVALID));
        }

        const string INVALID = "INVALID";
    }
}