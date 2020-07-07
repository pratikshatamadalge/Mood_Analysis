using System;
using System.Reflection;


namespace MoodAnalysis.FactoryPattern
{
    public class MoodAnalyserFactory<E>
    {
        Type type = typeof(E);
        public ConstructorInfo ConstructorCreator()
        {
            try
            {              
                ConstructorInfo[] constructor = type.GetConstructors();
                return constructor[0];
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND,e.Message);
            }
        }

        public ConstructorInfo ConstructorCreator(string className)
        {
            try
            {
                Type type = Type.GetType(className);
                ConstructorInfo[] constructor = type.GetConstructors();
                //return constructor[1];
                return constructor[0];
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, e.Message); 
            }
        }

        public ConstructorInfo ConstructorCreator(int numberOfParameters)
        {
            try
            {               
                ConstructorInfo[] constructor = type.GetConstructors();
                foreach(ConstructorInfo index in constructor)
                {
                    int numberOfParam = index.GetParameters().Length;                   
                    while(numberOfParam == numberOfParameters)
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
     

        public object InstanceCreator(string className, ConstructorInfo constructor)
        {
            try
            {             
                if (className != type.Name)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, "No such class found");
                }
                if (constructor != type.GetConstructors()[0])
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

        public object InstanceCreator(string className, ConstructorInfo constructor,string message)
        {
            try
            {
                if (className != type.Name)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, "No such class found");
                }
                if (constructor != type.GetConstructors()[1])
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, "No such method found");
                }
                object reflectionGenratedObject = Activator.CreateInstance(type,message);
                return reflectionGenratedObject;
            }
            catch (MoodAnalyserException e)
            {

                return e.Message;
            }
        }


        public bool InvokeMethods(string method_name,string message)
        {
            try
            {
                if(message != null)
                {
                    object instance = Activator.CreateInstance(type, "I am in Happy Mood");
                    MethodInfo method2 = type.GetMethod(method_name);
                    method2.Invoke(instance, new object[] { message });
                    return true;
                }
                else
                {
                    object instance = Activator.CreateInstance(type);
                    MethodInfo method = type.GetMethod("AnalyseMood1");
                    method.Invoke(instance, null);
                    return true; ;
                }
            }
            catch(MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_METHOD_FOUND, e.Message);
            }
        }

        public dynamic ChangeTheMood(string mood)
        {
            try
            {
                
                dynamic change_mood = Activator.CreateInstance(type, mood);
                MethodInfo method = type.GetMethod("AnalyseMood");                           
                if (mood == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NULL_POINTER_EXCEPTION, "Mood Should Not Null");
                }
                dynamic value = method.Invoke(change_mood, new object[] { mood });
                return value;
            }
            catch(MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NULL_POINTER_EXCEPTION, e.Message);
            }           

        }




    }
}


