using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UIBase : MonoBehaviour
	{
		[HideInInspector]
        public WindowID ID;
        private bool inited = false;
        private Action<object> onClose;

        public void Init()
        {
            if (inited) 
            return;
            inited = true;

            bool active = gameObject.activeSelf;
            gameObject.SetActive(true);

            OnInit();
            gameObject.SetActive(active);
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

            if (onClose != null)
            {
                onClose(message);
                onClose = null;
            }

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

        static public bool AddBtnClick(Transform parent, string path, UnityEngine.Events.UnityAction call) 
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

