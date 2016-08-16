using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public class EffectManager : MonoSingleton<EffectManager> 
    {
        public static readonly string effectFlashWhite   = "Prefabs/Effect/EffectFlashWhite";
        public static readonly string effectFlashBlack   = "Prefabs/Effect/EffectFlashBlack";
        public static readonly string effectHit          = "Prefabs/Effect/EffectHit";

        private Dictionary<string, UnityEngine.Object> efDic;

        protected override void OnInit()
        {
            efDic = new Dictionary<string, UnityEngine.Object>();
        }
        
        public bool Create(string path, Vector3 position, Quaternion rotation)
        {
            if (!efDic.ContainsKey(path))
            {
                UnityEngine.Object obj = Resources.Load(path);
                if (!obj)
                {
                    return false;
                }
                efDic.Add(path, obj);
            }

            GameObject go = Instantiate(efDic[path], position, rotation) as GameObject;
            go.transform.SetParent(transform, false);
            go.name = efDic[path].name;
            return true;
        }

        public bool Create(string path, Vector3 pos)
        {
            Quaternion qn = new Quaternion(0f, 0f, 0f, 1f);
            return Create(path, pos, qn);
        }

        public bool Create(string path)
        {
            Vector3 pos = new Vector3(0, 0, 0);
            Quaternion qn = new Quaternion(0f, 0f, 0f, 1f);
            return Create(path, pos, qn);
        }
    }
}
