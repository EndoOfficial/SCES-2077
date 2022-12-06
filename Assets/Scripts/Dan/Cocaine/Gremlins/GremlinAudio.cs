using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinAudio : Enemy
{
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void DeathSound()
    {
        GameEvents.OnCorporateplayAudio?.Invoke(source,AudioManager.CorporateClipTags.CokeDeath);
    }
}
