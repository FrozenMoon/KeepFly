using UnityEngine;
using System.Collections;
using Common;
using UI;

namespace GamePlay 
{
    public class GamePlayManager : Singleton<GamePlayManager> 
    {
        public GameObject bird;
        public float speed = 1.5f;
        public GAME_STATE gameState {get; set;}
        public int gameScore {get; set;}

        static bool bStart = false;

        public bool Init()
        {
            bird = GameObject.FindGameObjectWithTag(TagManager.Instance.Bird);
            if (!bStart) 
            {
                SetGameState(GAME_STATE.GAME_STATE_START);
                bStart = true;
            }
            else
            {
                SetGameState(GAME_STATE.GAME_STATE_READY);
            }
            
            return true;
        }

        public bool UnInit() 
        {
            return true;
        }

        public void Update() 
        {
            if (gameState == GAME_STATE.GAME_STATE_READY && Input.GetButtonDown("Jump")) 
            {
                SetGameState(GAME_STATE.GAME_STATE_PLAY);
            }
        }
        
        public void SetGameState(GAME_STATE gs) 
        {
            gameState = gs;
            switch (gameState) 
            {
                case GAME_STATE.GAME_STATE_START: 
                {
                    GameStart();
                    break;
                }
                case GAME_STATE.GAME_STATE_READY: 
                {
                    GameReady();
                    break;
                }
                case GAME_STATE.GAME_STATE_PLAY: 
                {
                    GamePlay();
                    break;
                }
                case GAME_STATE.GAME_STATE_OVER: 
                {
                    GameOver();
                    break;
                }
                case GAME_STATE.GAME_STATE_SCORE: 
                {
                    GameScore();
                    break;
                }
                case GAME_STATE.GAME_STATE_RESUME: 
                {
                    GameResume();
                    break;
                }
            }
        }

        private void GameStart() 
        {
            UIManager.Instance.OpenWindow(WindowID.UIGameStart);
        }

        private void GameReady() 
        {
            gameScore = 0;
            UIManager.Instance.CloseWindow(WindowID.UIGameStart);
            UIManager.Instance.OpenWindow(WindowID.UIGameReady);
        }

        private void GamePlay() 
        {
            UIManager.Instance.CloseWindow(WindowID.UIGameReady);
            UIManager.Instance.OpenWindow(WindowID.UIGamePlay);
            
            bird.GetComponent<BirdControler>().OnGamePlay();
        }

        private void GameOver() 
        {
            bird = GameObject.FindGameObjectWithTag(TagManager.Instance.Bird);
            bird.GetComponent<BirdControler>().OnGameOver();
        }

        private void GameScore() 
        {
            UIManager.Instance.CloseWindow(WindowID.UIGamePlay);
            UIManager.Instance.OpenWindow(WindowID.UIGameOver);
        }

        private void GameResume() 
        {
            UnityEngine.Debug.Log("游戏暂停！！");
        }
    }
}

