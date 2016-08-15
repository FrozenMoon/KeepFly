using System;
using UnityEngine;

namespace Common
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T instance = null;
        private bool inited = false;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType(typeof(T)) as T;
                }
                return instance;
            }
        }

        protected void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this as T;
        }

        private void OnApplicationQuit()  
        {  
            instance = null;
        }  
        
        public void Init()
        {
            if (inited)
            {
                return;
            }
                
            inited = true;
            OnInit();
        }

        public void UnInit()
        {
            if (!inited)
            {
                return;
            }

            inited = false;
            OnUnInit();
        }

        protected virtual void OnInit()
        {

        }

        protected virtual void OnUnInit()
        {

        }
    }
}