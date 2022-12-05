using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PTEnemySound : MonoBehaviour
{
    private AudioCycle audioCycle;
    private AudioSource source;
    private void OnEnable()
    {
        GameEvents.OnDeath += DeathAudio;
    }
    private void OnDisable()
    {
        GameEvents.OnDeath -= DeathAudio;
    }
    private void Start()
    {
        audioCycle = GetComponent<AudioCycle>();
        source = GetComponent<AudioSource>();
    }
    void DeathAudio()
    {
        GameEvents.OnRuralplayAudio?.Invoke(audioCycle.GetNextAudioSource(), AudioManager.RuralClipTags.TargetDeath);
    }
}
