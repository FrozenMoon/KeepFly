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
    }

    public class TagManager : Singleton<TagManager> {
        public string Bird = "Bird";
    }
    
}
