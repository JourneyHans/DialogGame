using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonUnity<AudioManager>
{
    public AudioSource BGMSource;

    private string _bgmRootPath = "Audio/BGM/";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public bool BGMEnable
    {
        get => BGMSource.gameObject.activeSelf;
        set
        {
            BGMSource.gameObject.SetActive(value);
            if (value && BGMSource.clip != null && !BGMSource.isPlaying && BGMSource.loop)
            {
                BGMSource.Play();
            }
        }
    }

    public void SetBGM(string clipName)
    {
        AudioClip clip = SimpleLoader.Load<AudioClip>(_bgmRootPath + clipName);
        if (clip == null)
        {
            Debug.LogError($"clip is NULL, clipName: {clipName}");
            return;
        }

        SetBGM(clip);
    }

    public void SetBGM(AudioClip clip)
    {
        BGMSource.clip = clip;
        BGMSource.loop = true;
        BGMSource.Play();
    }
}
