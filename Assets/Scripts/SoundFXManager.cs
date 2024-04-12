using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

public class SoundFXManager : MonoBehaviour
{
[SerializeField] private AudioSource soundFXObject;
public static SoundFXManager instance;

private void Awake()
{
    if (instance == null)
    {
        instance = this;
    }

}


public void PlaySoundFXClip(AudioClip audioClip, Transform transform, float volume)
{
    AudioSource audioSource = Instantiate(soundFXObject, transform.position, Quaternion.identity);
    audioSource.clip = audioClip;
    audioSource.volume = volume;
    audioSource.Play();
    float clipLength = audioSource.clip.length;
    Destroy(audioSource.gameObject, clipLength);
}

public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform transform, float volume)
{
    int randomIndex = Random.Range(0, audioClip.Length);

    AudioSource audioSource = Instantiate(soundFXObject, transform.position, Quaternion.identity);
    audioSource.clip = audioClip[randomIndex];
    audioSource.volume = volume;
    audioSource.Play();
    float clipLength = audioSource.clip.length;
    Destroy(audioSource.gameObject, clipLength);
}
}