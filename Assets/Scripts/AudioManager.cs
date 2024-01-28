using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource source;

    public Dictionary<JokeCategory, List<AudioClip>> introAudiosDictionary = new Dictionary<JokeCategory, List<AudioClip>>();
    public Dictionary<JokeCategory, List<AudioClip>> middleAudiosDictionary = new Dictionary<JokeCategory, List<AudioClip>>();
    public Dictionary<JokeCategory, List<AudioClip>> finalAudiosDictionary = new Dictionary<JokeCategory, List<AudioClip>>();

    public AudioClip GetAudio(int indexSection, int indexJoke, JokeCategory category) 
    {
        switch (indexSection)
        {
            case 0:
                return introAudiosDictionary[category][indexJoke];
            case 1:
                return middleAudiosDictionary[category][indexJoke];
            case 2:
                return finalAudiosDictionary[category][indexJoke];
            default:
                return null;
        }
    }

}
