using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class GameAudioClip 
{
    public AudioClip audioClip;

    public bool Loop = false;
    public float Pitch = 1f;
    public float Volume = 1f;

    public void PlayClip(AudioSource source, AudioClip libraryClip, bool Loop, float Pitch, float Volume)
    {
        if (libraryClip != null)
        {
            source.clip = libraryClip;
            source.loop = Loop;
            source.pitch = Pitch;
            source.volume = Volume;
            source.Play();
        }
        else
        {
            Debug.Log("Error no Clip");
        }
    }
}

public class UniversalAudioClip : GameAudioClip
{
    public AudioManager.UniversalClipTags UniversalClipTag;
}
public class SlumsAudioClip : GameAudioClip
{
    public AudioManager.SlumsClipTags SlumsClipTag;
}
public class CorporateAudioClip : GameAudioClip
{
    public AudioManager.CorporateClipTags CorporateClipTag;
}
public class ApartmentAudioClip : GameAudioClip
{
    public AudioManager.ApartmentClipTags ApartmentClipTag;
}
public class RuralAudioClip : GameAudioClip
{
    public AudioManager.RuralClipTags RuralClipTag;
}