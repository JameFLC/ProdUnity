using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public static class SoundManager
{
    public enum Sound
    {
        PlayerJump,
        PlayerMove,
        CameraMove,
        CameraSpot,
        ButtonPressed,
        DoorOpen,
        DoorClose,
        Card,
        DoorLocked,
    }
    private static Dictionary<Sound, float> soundTimerDictionary;
    private static GameObject oneshotGameObject;
    private static AudioSource oneShotAudioSource;


    public static void Initialise()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove] = 0f;
    }
    public static void PlaySound(Sound sound,Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.outputAudioMixerGroup = GameManager.instance.effectsGroup;
            audioSource.spatialBlend = 1;
            Debug.Log(" audio " + audioSource.clip);
            audioSource.Play();            
        }
    }
    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            if (oneshotGameObject == null)
            {
               oneshotGameObject = new GameObject("Sound");
               oneShotAudioSource = oneshotGameObject.AddComponent<AudioSource>();
            }
            oneShotAudioSource.outputAudioMixerGroup = GameManager.instance.effectsGroup;
            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
        }
        
    }
    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;
            case Sound.PlayerMove:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playermoveTimerMax = 0.5f;
                    if (lastTimePlayed + playermoveTimerMax < Time.time)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else return true;
        }
    }
    private static AudioClip GetAudioClip(Sound sound)
    {
        
        foreach (GameManager.SoundAudioClip soundAudioClip in GameManager.instance.soundAudioArray)
        {
            Debug.Log("clip " + soundAudioClip);
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        //Debug.LogError("Sound " + sound + " not found");
        return null;
    }
}
