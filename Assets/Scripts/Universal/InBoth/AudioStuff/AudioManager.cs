using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public UniversalAudioLibrary UniversalAudioLibrary;
    public SlumsAudioLibrary SlumsAudioLibrary;
    public ApartmentAudioLibrary ApartmentAudioLibrary;
    public RuralAudioLibrary RuralAudioLibrary;
    public CorporateAudioLibrary CorporateAudioLibrary;
    // Get the music clips you need for each game you can add more to the library when you need them,
    public enum UniversalClipTags
    {
        Gunfire,
        PlayerHurt,
        PlayerJump,
        PlayerWalk
    }
    public enum SlumsClipTags
    {

    }
    
    public enum ApartmentClipTags
    {

    }
    
    public enum CorporateClipTags
    {

    }
    public enum RuralClipTags
    {

    }

    public void OnEnable()
    {
        GameEvents.OnUniversalplayAudio += UniversalOnPlayAudio;
        GameEvents.OnSlumsplayAudio += SlumsOnPlayAudio;
        //GameEvents.OnCorporateplayAudio += UniversalOnPlayAudio;
        //GameEvents.OnUniversalplayAudio += UniversalOnPlayAudio;
    }
    public void OnDisable()
    {
        GameEvents.OnUniversalplayAudio -= UniversalOnPlayAudio;
        GameEvents.OnSlumsplayAudio += SlumsOnPlayAudio;
    }
    private void UniversalOnPlayAudio(AudioSource source, UniversalClipTags clipTag)
    {
        if (source == null)
        {
            Debug.LogError("No Audio Source");
            return;
        }

        UniversalAudioClip libraryClip = UniversalAudioLibrary.audioClips.FirstOrDefault(clip => clip.UniversalClipTag == clipTag);

        libraryClip.PlayClip(source, libraryClip.audioClip, libraryClip.Loop, libraryClip.Pitch, libraryClip.Volume);

    }
    private void SlumsOnPlayAudio(AudioSource source, SlumsClipTags clipTag)
    {
        if (source == null)
        {
            Debug.LogError("No Audio Source");
            return;
        }
        SlumsAudioClip libraryClip = SlumsAudioLibrary.audioClips.FirstOrDefault(clip => clip.SlumsClipTag == clipTag);

        libraryClip.PlayClip(source, libraryClip.audioClip, libraryClip.Loop, libraryClip.Pitch, libraryClip.Volume);
    }
    
    private void ApartmentOnPlayAudio(AudioSource source, ApartmentClipTags clipTag)
    {
        if (source == null)
        {
            Debug.LogError("No Audio Source");
            return;
        }
        ApartmentAudioClip libraryClip = ApartmentAudioLibrary.audioClips.FirstOrDefault(clip => clip.ApartmentClipTag == clipTag);

        libraryClip.PlayClip(source, libraryClip.audioClip, libraryClip.Loop, libraryClip.Pitch, libraryClip.Volume);
    }
    
    private void CorporateOnPlayAudio(AudioSource source, CorporateClipTags clipTag)
    {
        if (source == null)
        {
            Debug.LogError("No Audio Source");
            return;
        }
        CorporateAudioClip libraryClip = CorporateAudioLibrary.audioClips.FirstOrDefault(clip => clip.CorporateClipTag == clipTag);

        libraryClip.PlayClip(source, libraryClip.audioClip, libraryClip.Loop, libraryClip.Pitch, libraryClip.Volume);
    }
    
    private void RuralOnPlayAudio(AudioSource source, RuralClipTags clipTag)
    {
        if (source == null)
        {
            Debug.LogError("No Audio Source");
            return;
        }
        RuralAudioClip libraryClip = RuralAudioLibrary.audioClips.FirstOrDefault(clip => clip.RuralClipTag == clipTag);

        libraryClip.PlayClip(source, libraryClip.audioClip, libraryClip.Loop, libraryClip.Pitch, libraryClip.Volume);
    }

    //void Awake()
    //{
    //    foreach(Sound s in sounds)
    //    {
    //        s.source=gameObject.AddComponent<AudioSource>();
    //        s.source.clip = s.clip;
    //        s.source.volume = s.volume;
    //        s.source.pitch = s.pitch;
    //        s.source.loop = s.loop;
    //    }
    //}

    //// Update is called once per frame
    //public void Play(string name )
    //{
    //  Sound s=  Array.Find(sounds, sound => sound.name == name);
    //    if (s == null)
    //        return;
    //    s.source.Play();
    //}
    //private void Start()
    //{
    //    Play("Theme");
    //}
}