using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinAudio : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
   
    private void DeathSound()
    {
        source = GetComponent<AudioSource>();
        GameEvents.OnCorporateplayAudio?.Invoke(source,AudioManager.CorporateClipTags.CokeDeath);
    }
    private void CokePuffSound()
    {
        source=GetComponent<AudioSource>();
        GameEvents.OnCorporateplayAudio?.Invoke(source,AudioManager.CorporateClipTags.PuffNoise);
    }
}
