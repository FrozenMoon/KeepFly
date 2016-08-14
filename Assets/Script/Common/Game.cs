using UnityEngine;
using System.Collections;
using Common;
using GamePlay;
using UI;

public class Game : MonoSingleton<Game>
{
    public void Start()
    {
        Init();
    }

    protected override void OnInit()
    {
        UIManager.Instance.Init();

        if (!GamePlayManager.Instance.Init())
        {
            UnityEngine.Debug.LogError("GamePlayManager Init fail.");
            return;
        }
    }

    protected override void OnUnInit()
    {
       UIManager.Instance.UnInit();
       GamePlayManager.Instance.UnInit();
    }

    void Update()
    {
        GamePlayManager.Instance.Update();
    }
}

