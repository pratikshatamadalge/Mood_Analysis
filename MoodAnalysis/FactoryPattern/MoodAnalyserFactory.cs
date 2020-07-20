// <copyright file="MoodAnalyserFactory.cs" company="Bridgelabz">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MoodAnalysis.FactoryPattern
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Factory class for Mood Analyser.
    /// </summary>
    /// <typeparam name="E">Generic type.</typeparam>
    public class MoodAnalyserFactory<E>
    {
        /// <summary>
        /// Instance of class Type .
        /// </summary>
        public Type type = typeof(E);

        /// <summary>
        /// Method to get info of default constructor.
        /// </summary>
        /// <returns>constructor.</returns>
        public ConstructorInfo ConstructorCreator()
        {
            try
            {
                ConstructorInfo[] constructor = this.type.GetConstructors();
                return constructor[0];
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, e.Message);
            }
        }

        /// <summary>
        /// Method to get info of parameterized constructor.
        /// </summary>
        /// <param name="className">passing classname as string type.</param>
        /// <returns>Reflection constructor Info.</returns>
        public ConstructorInfo ConstructorCreator(string className)
        {
            try
            {
                Type type = Type.GetType(className);
                ConstructorInfo[] constructor = type.GetConstructors();
                return constructor[0];
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, e.Message);
            }
        }

        /// <summary>
        /// Method to get info of parameterized constructor.
        /// </summary>
        /// <param name="numberOfParameters">number of parameters.</param>
        /// <returns>Reflection constructor Info.</returns>
        public ConstructorInfo ConstructorCreator(int numberOfParameters)
        {
            try
            {
                ConstructorInfo[] constructor = this.type.GetConstructors();
                foreach (ConstructorInfo index in constructor)
                {
                    int numberOfParam = index.GetParameters().Length;
                    while (numberOfParam == numberOfParameters)
                    {
                        return index;
                    }
                }

                return constructor[0];
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, e.Message);
            }
        }

        /// <summary>
        /// Method to create instance at Runtime.
        /// </summary>
        /// <param name="className">Passing className as string.</param>
        /// <param name="constructor">ConstructorInfo.</param>
        /// <returns>Object of class.</returns>
        public object InstanceCreator(string className, ConstructorInfo constructor)
        {
            try
            {
                if (className != this.type.Name)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, "No such class found");
                }

                if (constructor != this.type.GetConstructors()[0])
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, "No such method found");
                }

                E reflectionGenratedObject = Activator.CreateInstance<E>();
                return reflectionGenratedObject;
            }
            catch (MoodAnalyserException e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Instance creator method using reflection.
        /// </summary>
        /// <param name="className">Passing classname as string.</param>
        /// <param name="constructor">Constructor Info.</param>
        /// <param name="message">Message.</param>
        /// <returns>Returns object of className provided.</returns>
        public object InstanceCreator(string className, ConstructorInfo constructor, string message)
        {
            try
            {
                if (className != this.type.Name)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, "No such class found");
                }

                if (constructor != this.type.GetConstructors()[1])
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, "No such method found");
                }

                object reflectionGenratedObject = Activator.CreateInstance(this.type, message);
                return reflectionGenratedObject;
            }
            catch (MoodAnalyserException e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Invoke method at runtime using reflection.
        /// </summary>
        /// <param name="method_name">Passing method name as string which we want to invoke.</param>
        /// <param name="message">Passing message as string.</param>
        /// <returns>Returns true or false.</returns>
        public bool InvokeMethods(string method_name, string message)
        {
            try
            {
                if (message != null)
                {
                    object instance = Activator.CreateInstance(this.type, message);
                    MethodInfo method2 = this.type.GetMethod(method_name);
                    method2.Invoke(instance, new object[] { message });
                    return true;
                }
                else
                {
                    object instance = Activator.CreateInstance(this.type);
                    MethodInfo method = this.type.GetMethod("AnalyseMood1");
                    MethodInfo[] m = this.type.GetMethods();
                    method.Invoke(instance, null);
                    return true;
                }
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_METHOD_FOUND, e.Message);
            }
        }

        /// <summary>
        /// Method for change mood.
        /// </summary>
        /// <param name="mood">Passing mood as string type.</param>
        /// <returns>Returns dynamic type(Skip type checking at compile time).</returns>
        public dynamic ChangeTheMood(string mood)
        {
            try
            {
                dynamic change_mood = Activator.CreateInstance(this.type, mood);
                MethodInfo method = this.type.GetMethod("AnalyseMood");
                if (mood == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NULL_POINTER_EXCEPTION, "Mood Should Not Null");
                }

                dynamic value = method.Invoke(change_mood, new object[] { mood });
                return value;
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NULL_POINTER_EXCEPTION, e.Message);
            }
        }
    }
}