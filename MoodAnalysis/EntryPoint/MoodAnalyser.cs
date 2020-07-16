// <copyright file="MoodAnalyser.cs" company="Bridgelabz">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MoodAnalysis
{
    using System;

    /// <summary>
    /// MoodAnalyser class.
    /// </summary>
    public class MoodAnalyser
    {
        /// <summary>
        /// Variable string type.
        /// </summary>
        public string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
        public MoodAnalyser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
        /// <param name="message">Method accepts string value.</param>
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Accepts any type of any element.</param>
        public static void Main(string[] args)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
        /// <returns>returns string value.</returns>
        public string AnalyseMood1()
        {
            return this.AnalyseMood(this.message);
        }

        /// <summary>
        /// For checking and analysing mood.
        /// </summary>
        /// <param name="message">It will receive a message.</param>
        /// <returns>returns string value.</returns>
        public string AnalyseMood(string message)
        {
            try
            {
                if (message.Length == 0)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.EMPTY_STRING_EXCEPTION, "Message Can Not Be Empty");
                }
                else if (message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NULL_POINTER_EXCEPTION, "Null Value");
                }
                else if (message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else if (message.ToLower().Contains("happy"))
                {
                    return "HAPPY";
                }
                else
                {
                    return "Not Sure About Mood";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}