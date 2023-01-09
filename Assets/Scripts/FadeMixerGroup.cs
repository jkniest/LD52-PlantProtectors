using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class FadeMixerGroup
{
    public static IEnumerator StartFade(AudioMixer mixer, string param, float duration, float targetVolume)
    {
        var currentTime = 0f;
        var currentVol = 0f;

        mixer.GetFloat(param, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        var targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1f);
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            var newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            mixer.SetFloat(param, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }
}