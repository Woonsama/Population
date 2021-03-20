using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("오디오 - 배경음")]
    public AudioSource audioSource_BGM;

    public void ChangeBGM(AudioClip clip, bool loop)
    {
        audioSource_BGM.clip = clip;
        audioSource_BGM.loop = loop;
    }
}