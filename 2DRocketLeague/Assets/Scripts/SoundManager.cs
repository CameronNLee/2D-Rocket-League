// Disclaimer: SoundManager largely derived from following this tutorial:
// https://www.technoob.me/2019/01/how-to-make-advanced-audio-manager-unity.html

using Sound.Control;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Singleton;
    public SoundFile[] SoundFiles;

    void Awake()
    {
        if (Singleton)
        {
            Singleton = this;
        }
        else if (Singleton != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        
        // Loads each sound clip into the manager and all their properties.
        // These can be inspected and set inside the unity editor under the
        // SoundManager game object inside SampleScene.
        foreach (SoundFile s in SoundFiles)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.SoundClip;
            s.Source.volume = s.Volume;
            s.Source.loop = s.IsLooping;
            if(s.PlayOnAwake)
            {
                s.Source.Play();
            }
        }
    }

}