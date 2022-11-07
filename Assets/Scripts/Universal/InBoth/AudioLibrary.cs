using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// gets all the clips and makes a library to use afterwards in the audiomanager

[CreateAssetMenu(menuName = "Universal Audio Library", fileName = "Universal Audio Library")] // This is the name of the audio library
public class UniversalLibrary : ScriptableObject
{
    public List<UniversalAudioClip> audioClips; // list of (Universal) sounds
}

[CreateAssetMenu(menuName = "Slums Audio Library", fileName = "Slums Audio Library")] // This is the name of the audio library
public class SlumsLibrary : ScriptableObject
{
    public List<SlumsAudioClip> audioClips; // list of (Slums) sounds
}

[CreateAssetMenu(menuName = "Apartment Audio Library", fileName = "Apartment Audio Library")] // This is the name of the audio library
public class ApartmentLibrary : ScriptableObject
{
    public List<ApartmentAudioClip> audioClips; // list of (Apartment) sounds
}

[CreateAssetMenu(menuName = "Corporate Audio Library", fileName = "Corporate Audio Library")] // This is the name of the audio library
public class CorporateLibrary : ScriptableObject
{
    public List<CorporateAudioClip> audioClips; // list of (Corpo) sounds
}

[CreateAssetMenu(menuName = "Rural Audio Library", fileName = "Rural Audio Library")] // This is the name of the audio library
public class RuralLibrary : ScriptableObject
{
    public List<RuralAudioClip> audioClips; // list of (Rural) sounds
}
