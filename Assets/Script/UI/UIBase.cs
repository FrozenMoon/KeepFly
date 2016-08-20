using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UI
{
	public class UIBase : MonoBehaviour
	{
		[HideInInspector]
        public WindowID ID;
        private bool inited = false;

        public void Init()
        {
            if (inited)
            {
                return;
            }
                
            inited = true;

            bool active = gameObject.activeSelf;
            gameObject.SetActive(true);

            OnInit();
            gameObject.SetActive(active);
        }

        public void UnInit()
        {

        }

        public bool IsOpen()
        {
            return UIManager.Instance.IsOpen(ID);
        }

        public bool Open(params object[] args)
        {
            Init();
            OnOpen(args);
            
            return true;
        }

        public virtual void Close(object message)
        {
            if (!this)
                return;

            OnClose();
        }

        protected virtual void OnInit()
        {

        }

        protected virtual void OnOpen(object[] args)
        {
           
        }

        protected virtual void OnClose()
        {
            
        }

        #region static fuction

        static public bool AddBtnClick(Transform parent, string path, UnityAction call) 
        {
            Transform child = parent.Find(path);
            if (!child) 
            {
                return false;
            }
            else 
            {
                child.GetComponent<Button>().onClick.RemoveAllListeners();
                child.GetComponent<Button>().onClick.AddListener(call);
            }
            return true;
        }
        
        #endregion
	}
}

