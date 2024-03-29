using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    #region Singleton
    private static AudioManager _instance;

    public static AudioManager Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    #endregion

    void Start()
    {
        Play("MainSong");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        if(s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.LogError($"{name} could not be found.");
        }
    }

    public void AdjustVolume(float volume, int[] soundVolsToChange)
    {
        foreach(int s in soundVolsToChange)
        {
            sounds[s].source.volume = volume;
        }
    }

    public float[] KeepVolume()
    {
        float[] sliderValues = new float[] { 0, 0 };
        sliderValues[0] = sounds[0].source.volume;
        sliderValues[1] = sounds[1].source.volume;
        return sliderValues;
    }
}
