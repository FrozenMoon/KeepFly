using UnityEngine;
using System.Collections;
using System;
using Common;
using UnityEngine.UI;

namespace UI 
{
    public enum WindowID 
    {
        UIGameStart,
        UIGameReady,
        UIGamePlay,
        UIGameOver,

        Max,
    }

    public class UIManager : MonoSingleton<UIManager>
    {
        private UIBase[] Instances = new UIBase[(int)WindowID.Max];

        protected override void OnInit()
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                Transform child = transform.GetChild(i);
                UIBase ui = child.GetComponent<UIBase>();
                if (ui != null)
                {
                    WindowID id = (WindowID)Enum.Parse(typeof(WindowID), ui.GetType().Name.ToString());
                    Instances[(int)id] = ui;
                    child.gameObject.SetActive(false);
                }
            }
		}
	
	    protected override void OnUnInit()
        {
            foreach (UIBase ui in Instances)
            {
                if (ui)
                {
                    ui.gameObject.SetActive(false);
				    ui.Close(null);
                    DestroyImmediate(ui.gameObject);
                }
            }
            Array.Clear(Instances, 0, Instances.Length);
        }

        private UIBase getWindow(WindowID id)
		{
            
            if (id == WindowID.Max)
            {
                return null;
            } 
                
            UIBase ui = Instances[(int)id];
		    if (!ui)
            {
                string path = string.Format("Prefabs/UI/{0}", id.ToString());
			    UnityEngine.Object prefab = Resources.Load(path);
                
			    if (prefab == null)
                {
				    return null;
                }
			    else 
			    {
				    GameObject go = Instantiate(prefab) as GameObject;
				    go.name = prefab.name;
                    ui = go.GetComponent<UIBase>();
				    if (!ui)
				    {
					    return null;
				    }

				    go.transform.SetParent(transform, false);
				    Instances[(int)id] = ui;
				    ui.ID = id;

                    go.SetActive(false);
			    }
            }

		    return ui;
		}

        public static UIBase GetWindow(WindowID id)
		{
			return Instance.Instances[(int)id];
		}

        public void Destroy(WindowID id)
        {
            UIBase ui = Instances[(int)id];
	        if (!ui)
            {
                return;
            }
                
	        if (IsOpen(id))
	        {
		        CloseWindow(id);
	        }

	        Instances[(int)id] = null;
	        Resources.UnloadUnusedAssets();
	        GC.Collect();
        }

        public bool IsOpen(WindowID id)
        {
            UIBase ui = Instances[(int)id];
            if (!ui)
	        {
		        return false;
	        }
	        else
	        {
                return ui.gameObject.activeSelf;
	        }
        }

        public UIBase OpenWindow(WindowID id, params object[] args)
        {
	        if (id == WindowID.Max)
	        {
		        return null;
	        }

            UIBase ui = getWindow(id);
            if (ui)
	        {
                bool isOpen = IsOpen(id);
                if (!isOpen)
		        {
                    ui.gameObject.SetActive(true);
                    ui.Open(args);
		        }
	        }

            return ui;
        }

		public void CloseWindow(WindowID id, object message = null)
		{
            UIBase ui = Instances[(int)id];
		    if (!ui)
            {
                return;
            }
                
            bool isOpen = IsOpen(id);
            if (isOpen)
		    {
			    ui.gameObject.SetActive(false);
			    ui.Close(message);
		    }
		}

       
    }
}

