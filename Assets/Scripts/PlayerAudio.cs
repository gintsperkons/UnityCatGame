using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{    
    [SerializeField] private AudioClip[] catMeowArray;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            SoundFXManager.instance.PlayRandomSoundFXClip(catMeowArray, transform, 1f);
        } 
    }
}
