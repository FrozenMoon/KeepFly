using UnityEngine;
using System.Collections;
using Common;

namespace GamePlay 
{
    public enum GAME_STATE 
    {
        GAME_STATE_START,
        GAME_STATE_READY,
        GAME_STATE_PLAY,
        GAME_STATE_OVER,
        GAME_STATE_SCORE,
        GAME_STATE_RESUME,
        GAME_STATE_GOON
    }

    public class GameSetting : Singleton<GameSetting> {
        public string tagBird = "Bird";
        public string ppBestScore = "gameBestScore";
        public string inputJump = "Jump";
        public string pipiDown = "pipe_down";
        public string sceneLevel1 = "Level1";
        public string sceneMain = "Main";
    }
}
