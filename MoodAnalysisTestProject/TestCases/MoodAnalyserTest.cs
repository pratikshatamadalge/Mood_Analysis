using MoodAnalysis;
using MoodAnalysis.FactoryPattern;
using NUnit.Framework;
using System;
using System.Reflection;

namespace MoodAnalysisTestProject
{
    public class MoodAnalyserTest
    {
        MoodAnalyser analyser;
        [OneTimeSetUp]
        public void Setup()
        {
            analyser = new MoodAnalyser();
        }

        [Test]
        public void Test_For_Sad_Mood_Test()
        {
            string message = "I Am So Sad ";
            string currentMood = "SAD";
            string result = analyser.AnalyseMood(message);
            Assert.AreEqual(currentMood, result);
        }

        [Test]
        public void Test_For_Happy_Mood_Test()
        {
            string message = "I Am So Happy";
            string currentMood = "HAPPY";
            string result = analyser.AnalyseMood(message);
            Assert.AreEqual(currentMood, result);
        }
    }
}