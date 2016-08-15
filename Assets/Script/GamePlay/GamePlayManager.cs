using UnityEngine;
using System.Collections;
using Common;
using UI;
using UnityEngine.SceneManagement;

namespace GamePlay 
{
    public class GamePlayManager : Singleton<GamePlayManager> 
    {
        public GameObject bird;
        public float speed = 1.5f;
        public GAME_STATE gameState {get; set;}
        public int gameScore {get; set;}
        public int gameBestScore {get; set;}


        public bool Init()
        {
            gameBestScore = PlayerPrefs.GetInt(GameSetting.Instance.ppBestScore, 0);
            SetGameState(GAME_STATE.GAME_STATE_START);
            
            return true;
        }

        public bool UnInit() 
        {
            return true;
        }

        public void Update() 
        {
            if (gameState == GAME_STATE.GAME_STATE_READY && Input.GetButtonDown(GameSetting.Instance.inputJump)) 
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
            

            AudioManager.Instance.Play(AudioManager.audioSwitch);
            AudioManager.Instance.Play(AudioManager.audioBgWindSmall);
            EffectManager.Instance.Create(EffectManager.effectFlashBlack);

            SceneManager.LoadScene(GameSetting.Instance.sceneLevel1);

            UIManager.Instance.CloseWindow(WindowID.UIGameOver);
            UIManager.Instance.CloseWindow(WindowID.UIGameStart);
            UIManager.Instance.OpenWindow(WindowID.UIGameReady);
        }

        private void GamePlay() 
        {
            UIManager.Instance.CloseWindow(WindowID.UIGameReady);
            UIManager.Instance.OpenWindow(WindowID.UIGamePlay);

            bird = GameObject.FindGameObjectWithTag(GameSetting.Instance.tagBird);
            bird.GetComponent<BirdControler>().OnGamePlay();
        }

        private void GameOver() 
        {
            bird.GetComponent<BirdControler>().OnGameOver();
        }

        private void GameScore() 
        {
            UIManager.Instance.CloseWindow(WindowID.UIGamePlay);
            UIManager.Instance.OpenWindow(WindowID.UIGameOver);

            if (gameScore > gameBestScore) 
            {
                gameBestScore = gameScore;
                PlayerPrefs.SetInt(GameSetting.Instance.ppBestScore, gameBestScore);
            }
        }

        private void GameResume() 
        {
            UnityEngine.Debug.Log("GameResume");
        }
    }
}

