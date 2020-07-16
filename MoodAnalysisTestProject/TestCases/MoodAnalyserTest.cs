// <copyright file="MoodAnalyserTest.cs" company="Bridgelabz">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MoodAnalysisTestProject
{
    using System.Reflection;
    using MoodAnalysis;
    using MoodAnalysis.FactoryPattern;
    using NUnit.Framework;

    /// <summary>
    /// MoodAnalyser test class.
    /// </summary>
    public class MoodAnalyserTest
    {
        private MoodAnalyser analyser;

        /// <summary>
        /// Set up.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            this.analyser = new MoodAnalyser();
        }

        /// <summary>
        /// Test case to check happy mood.
        /// </summary>
        [Test]
        public void Test_For_Happy_Mood_Test()
        {
            string message = "I Am So Happy";
            string currentMood = "HAPPY";
            string result = this.analyser.AnalyseMood(message);
            Assert.AreEqual(currentMood, result);
        }

        /// <summary>
        /// Test case to check sad mood.
        /// </summary>
        [Test]
        public void Test_For_Sad_Mood_Test()
        {
            string message = "I Am So Sad ";
            string currentMood = "SAD";
            string result = this.analyser.AnalyseMood(message);
            Assert.AreEqual(currentMood, result);
        }

        /// <summary>
        /// Test case to check null response.
        /// </summary>
        [Test]
        public void Test_For_Null_Response_Test()
        {
            try
            {
                string result = this.analyser.AnalyseMood(null);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NULL_POINTER_EXCEPTION, e.ExceptionType);
            }
        }

        /// <summary>
        /// Test for empty message .
        /// </summary>
        [Test]
        public void Test_For_Empty_Message_Test()
        {
            try
            {
                string result = this.analyser.AnalyseMood(string.Empty);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.EMPTY_STRING_EXCEPTION, e.ExceptionType);
            }
        }

        /// <summary>
        /// Test case to check constructor.
        /// </summary>
        [Test]
        public void Mood_Analyser_Contructor_Checker_Test()
        {
            string className = "MoodAnalyser";
            MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
            ConstructorInfo constrInfo = factory.ConstructorCreator();
            object instanceOfClass = factory.InstanceCreator(className, constrInfo);
            Assert.IsInstanceOf(typeof(MoodAnalyser), instanceOfClass);
        }

        /// <summary>
        /// Test case to check Improper class name.
        /// </summary>
        [Test]
        public void Improper_Class_Haandeling_Test()
        {
            try
            {
                string imProperClassName = "Mood";
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator();
                object instanceOfClass = factory.InstanceCreator(imProperClassName, constrInfo);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, e.ExceptionType);
            }
        }

        /// <summary>
        /// Test case to check improper constructor handling.
        /// </summary>
        [Test]
        public void Improper_Constructor_Haandeling_Test()
        {
            try
            {
                string constructorOfClass = "MoodAnalysis.MoodAnalyserException";
                string className = "MoodAnalyser";
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator(constructorOfClass);
                object instanceOfClass = factory.InstanceCreator(className, constrInfo);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, e.ExceptionType);
            }
        }

        /// <summary>
        /// Test case to check parameterised constructor.
        /// </summary>
        [Test]
        public void Mood_Analyser_Parameterised_Constructor_Check_Test()
        {
            string message = "here i am in sad mood";
            string className = "MoodAnalyser";
            MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
            ConstructorInfo constrInfo = factory.ConstructorCreator(1);
            object instanceOfClass = factory.InstanceCreator(className, constrInfo, message);
            Assert.IsInstanceOf(typeof(MoodAnalyser), instanceOfClass);
        }

        /// <summary>
        /// Test case to check improper name for parameterised constructor.
        /// </summary>
        [Test]
        public void Improper_Class_Name_For_Parametersed_Constructor_Test()
        {
            try
            {
                string message = "here i am in happy mood";
                string imProperClassName = "Mood";
                MoodAnalyser analysis = new MoodAnalyser(message);
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator(1);
                object instanceOfClass = factory.InstanceCreator(imProperClassName, constrInfo, message);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, e.ExceptionType);
            }
        }

        /// <summary>
        /// Test case to check improper parameterised constructor.
        /// </summary>
        [Test]
        public void Improper_Constructor_For_Parameterised_Constructor_Test()
        {
            try
            {
                string message = "here i am in happy mood";
                string className = "MoodAnalyser";
                string imProperConstructor = "MoodAnalysis.MoodAnalyser";
                MoodAnalyser analysis = new MoodAnalyser(message);
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator(imProperConstructor);
                object instanceOfClass = factory.InstanceCreator(className, constrInfo, message);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, e.ExceptionType);
            }
        }

        /// <summary>
        /// Test case to check call method using reflection.
        /// </summary>
        [Test]
        public void Call_Method_Using_Reflection_Test()
        {
            MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
            bool checker = factory.InvokeMethods("AnalyseMood", "Happy");
            Assert.AreEqual(true, checker);
        }

        /// <summary>
        /// Test case to check improper method Exception.
        /// </summary>
        [Test]
        public void Improper_Method_Should_Throw_Exception()
        {
            try
            {
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                bool checker = factory.InvokeMethods("Mood", null);
                Assert.AreEqual(true, checker);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_METHOD_FOUND, e.ExceptionType);
            }
        }

        /// <summary>
        /// Test case for dynamic mood change.
        /// </summary>
        [Test]
        public void Change_Mood_Dynamically()
        {
            MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
            dynamic result = factory.ChangeTheMood("Happy");
            Assert.AreEqual("HAPPY", result);
        }

        /// <summary>
        /// Test case to check null value.
        /// </summary>
        [Test]
        public void Null_Value_Should_Throw_Exception()
        {
            try
            {
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                dynamic result = factory.ChangeTheMood(null);
                Assert.AreEqual("HAPPY", result);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NULL_POINTER_EXCEPTION, e.ExceptionType);
            }
        }
    }
}