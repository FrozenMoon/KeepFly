using UnityEngine;
using System.Collections;

public class EffectFlash : MonoBehaviour 
{
    void OnAnimationOver() 
    {
        Destroy(gameObject);
    }
}
