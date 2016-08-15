using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Common
{
    public class Singleton<T> where T : new()
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }

        // constructor
        protected Singleton()
        {
        }

        private Singleton(ref Singleton<T> instance)
        {
        }

        private Singleton(Singleton<T> instance)
        {
        }   
    }
}