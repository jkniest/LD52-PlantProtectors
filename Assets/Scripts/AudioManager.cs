using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public AudioMixer mixer;
    public AudioSource sourceEffectClick;
    public AudioSource sourceEffectHit;
    public AudioSource sourceEffectPew;
    public AudioSource sourceEffectUpgrade;
    public AudioSource sourceEffectPlant;
    public AudioSource sourceEffectXp;

    private bool IsMuted => mixer.GetFloat("MasterVolume", out float volume) && volume <= -10f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        FadeToNormal();
    }

    public void ToggleMute()
    {
        if (IsMuted)
        {
            mixer.SetFloat("MasterVolume", 0f);
            return;
        }
        
        mixer.SetFloat("MasterVolume", -80f);
    }

    public void FadeToBoss()
    {
        StartCoroutine(FadeMixerGroup.StartFade(
            mixer,
            "NormalVolume",
            2f,
            -80f
        ));
        
        StartCoroutine(FadeMixerGroup.StartFade(
            mixer,
            "BossVolume",
            2f,
            10f
        ));
    }
    
    public void FadeToNormal()
    {
        StartCoroutine(FadeMixerGroup.StartFade(
            mixer,
            "NormalVolume",
            2f,
            10f
        ));
        
        StartCoroutine(FadeMixerGroup.StartFade(
            mixer,
            "BossVolume",
            2f,
            -80f
        ));
    }

    public void PlayEffectClick() => sourceEffectClick.Play();

    public void PlayEffectHit(AudioClip clip)
    {
        sourceEffectHit.clip = clip;
        sourceEffectHit.Play();
    }

    public void PlayPewEffect() => sourceEffectPew.Play();
    
    public void PlayUpgradeEffect() => sourceEffectUpgrade.Play();

    public void PlayEffectPlant() => sourceEffectPlant.Play();
    
    public void PlayEffectXp() => sourceEffectXp.Play();
}