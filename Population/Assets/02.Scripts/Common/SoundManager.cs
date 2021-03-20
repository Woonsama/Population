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


    [Header("아이 클립")]
    public AudioClip[] clip_Young = new AudioClip[0];
    [Header("남자 클립")]
    public AudioClip[] clip_Man = new AudioClip[0];
    [Header("여자 클립")]
    public AudioClip[] clip_Women = new AudioClip[0];
    [Header("노인 클립")]
    public AudioClip[] clip_Old = new AudioClip[0];

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

    public void PlayOnShot_Young(AudioSource source)
    {
        source.PlayOneShot(clip_Young[0]);
    }
    public void PlayOnShot_YoungTruck(AudioSource source)
    {
        source.PlayOneShot(clip_Young[1]);
    }

    public void PlayOnShot_Man(AudioSource source)
    {
        source.PlayOneShot(clip_Man[Random.Range(0,2)]);
    }

    public void PlayOnShot_ManTruck(AudioSource source)
    {
        source.PlayOneShot(clip_Man[2]);
    }

    public void PlayOnShot_Women(AudioSource source)
    {
        source.PlayOneShot(clip_Women[Random.Range(0, 2)]);
    }

    public void PlayOnShot_WomenTruck(AudioSource source)
    {
        source.PlayOneShot(clip_Women[2]);
    }


    public void PlayOnShot_Old(AudioSource source)
    {
        source.PlayOneShot(clip_Old[Random.Range(0, 2)]);
    }

    public void PlayOnShot_OldTruck(AudioSource source)
    {
        source.PlayOneShot(clip_Old[2]);
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