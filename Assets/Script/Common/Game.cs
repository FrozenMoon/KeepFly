using UnityEngine;
using System.Collections;
using GamePlay;
using UI;

namespace Common 
{
    public class Game : MonoSingleton<Game>
    {
        public void Start()
        {
            DontDestroyOnLoad(this);
            Init();
        }

        protected override void OnInit()
        {
            AudioManager.Instance.Init();
            EffectManager.Instance.Init();
            UIManager.Instance.Init();

            if (!GamePlayManager.Instance.Init())
            {
                UnityEngine.Debug.LogError("GamePlayManager Init fail.");
                return;
            }
        }

        protected override void OnUnInit()
        {
            AudioManager.Instance.UnInit();
            EffectManager.Instance.UnInit();
            UIManager.Instance.UnInit();
            GamePlayManager.Instance.UnInit();
        }

        void Update()
        {
            GamePlayManager.Instance.Update();
        }
    }
}


