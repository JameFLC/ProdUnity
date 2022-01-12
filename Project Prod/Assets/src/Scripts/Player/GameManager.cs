using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class GameManager : MonoBehaviour
{
    // Variables
    public static GameManager instance { get; private set; }

    public AudioMixerGroup effectsGroup;
    public AudioMixerGroup musicGroup;

    private bool isInSafeZone = false;

    void Awake()
    {
        if (instance != null || instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)

        instance = this;
        SoundManager.Initialise();
        DontDestroyOnLoad(this);
    }

    


    public bool getisSafe()
    {
        return isInSafeZone;
    }
    public void setIsSafe(bool var)
    {
        isInSafeZone = var;
        Debug.Log("isInSafeZone " + isInSafeZone);
    }
    
    public SoundAudioClip[] soundAudioArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
