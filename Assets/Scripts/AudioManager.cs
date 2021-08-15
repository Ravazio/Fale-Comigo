using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool StillSpeaking = false;
    public static AudioSource audioSrc;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void SpeakWordsOnLoop()
    {
        StartCoroutine(SpeakWordsOnLoopRoutine());
    }

    IEnumerator SpeakWordsOnLoopRoutine()
    {
        StillSpeaking = true;
        while (StillSpeaking)
        {
            audioSrc.Stop();
            audioSrc.Play();
            while (audioSrc.isPlaying)
            {
                yield return null;
            }
        }
    }

    public void BipSound()
    {
        StartCoroutine(BipSoundRoutine());
    }

    IEnumerator BipSoundRoutine()
    {
        audioSrc.Play();
        yield return null;
    }
}
