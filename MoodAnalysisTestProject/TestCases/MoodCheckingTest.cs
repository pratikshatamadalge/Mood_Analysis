using MoodAnalysis;
using MoodAnalysis.FactoryPattern;
using NUnit.Framework;
using System;
using System.Reflection;

namespace MoodAnalysisTestProject
{
    public class MoodCheckingTest
    {
        MoodAnalyser analyser;
        [OneTimeSetUp]
        public void Setup()
        {
            analyser = new MoodAnalyser();
        }

        [Test]
        public void Test1()
        {
           
        }
    }
}