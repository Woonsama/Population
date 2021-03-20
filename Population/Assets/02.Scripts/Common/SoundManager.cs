using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("오디오 - 배경음")]
    public AudioSource audioSource_BGM;

    [Header("효과음 - 플레이어 걸음")]
    public AudioSource audioSource_Player_Walk;
    private bool isRun_PlayerWalk;

    public void ChangeBGM(AudioClip clip, bool loop)
    {
        audioSource_BGM.clip = clip;
        audioSource_BGM.loop = loop;
        audioSource_BGM.Play();
    }

    public void SetWalk_Player(AudioClip clip, bool loop)
    {
        audioSource_Player_Walk.clip = clip;
        audioSource_Player_Walk.loop = loop;
    }

    public void SetVolume_Player_Walk(float volume)
    {
        audioSource_Player_Walk.volume = volume;
    }

    public void PlayWalk_Player()
    {
        if (!isRun_PlayerWalk)
        {
            audioSource_Player_Walk.Play();
            isRun_PlayerWalk = true;
        }
    }

    public void StopWalk_Player()
    {
        if(isRun_PlayerWalk)
        {
            audioSource_Player_Walk.Stop();
            isRun_PlayerWalk = false;
        }
    }

    
    public void SetBGMVolume(float volume)
    {
        audioSource_BGM.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        audioSource_Player_Walk.volume = volume;
    }
}