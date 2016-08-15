using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public class AudioManager : MonoSingleton<AudioManager> 
    {
        public static readonly string audioBgRainSmall   = "Audios/AudioBgRainSmall";
        public static readonly string audioBgRainIndoor  = "Audios/AudioBgRainIndoor";
        public static readonly string audioBgWindSmall   = "Audios/AudioBgWindSmall";

        public static readonly string audioDie           = "Audios/AudioDie";
        public static readonly string audioHit           = "Audios/AudioHit";
        public static readonly string audioScore         = "Audios/AudioScore";
        public static readonly string audioSwitch        = "Audios/AudioSwitch";
        public static readonly string audioJump          = "Audios/AudioJump";

        private Dictionary<string, AudioClip> acDic;
        private Dictionary<string, AudioSource> asDic;

        protected override void OnInit()
        {
            acDic = new Dictionary<string, AudioClip>();
            asDic = new Dictionary<string, AudioSource>();

            AudioSource[] audioSources = GetComponents<AudioSource>();
            asDic.Add(audioBgRainSmall, audioSources[0]);
            asDic.Add(audioBgRainIndoor, audioSources[0]);
            asDic.Add(audioBgWindSmall, audioSources[0]);

            asDic.Add(audioHit, audioSources[1]);
            asDic.Add(audioJump, audioSources[1]);
            asDic.Add(audioScore, audioSources[2]);
            asDic.Add(audioDie, audioSources[2]);
            asDic.Add(audioSwitch, audioSources[3]);
        }
	    public bool Play(string path)
        {
            if (!asDic.ContainsKey(path))
            {
                return false;
            }
            if (!acDic.ContainsKey(path))
            {
                AudioClip clip = Resources.Load<AudioClip>(path);
                if (!clip)
                {
                    return false;
                }
                acDic.Add(path, clip);
            }

            asDic[path].clip = acDic[path];
            asDic[path].Play();
            return true;
        }

        public bool Stop(string path) 
        {
            if (!asDic.ContainsKey(path))
            {
                return false;
            }
            if (!acDic.ContainsKey(path))
            {
                return false;
            }

            if (!asDic[path].isPlaying)
            {
                return false;
            }

            asDic[path].Stop();
            return true;
        }
    }
}
