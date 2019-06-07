// Disclaimer: SoundManager largely derived from following these tutorials:
// https://www.technoob.me/2019/01/how-to-make-advanced-audio-manager-unity.html
// https://www.daggerhart.com/unity-audio-and-sound-manager-singleton-script/
using System;
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
        if (!Singleton)
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
        
        // Note: size of SoundFiles array is set inside the Unity Scene Editor.
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
    
    // Takes in a filename as an argument and searches through the array.
    // If it finds the audio file inside it, then simply play it.
    public void Play(string filename)
    {
        // Uses an anonymous function for the second parameter.
        SoundFile file = Array.Find(Singleton.SoundFiles, match => match.Filename == filename);
        if (file == null)
        {
            Debug.LogError("Cannot play audio! Sound name" + filename + "not found!");
            return;
        }    
        file.Source.Play();
    }

    public static void Pause(string filename)
    {
        // Uses an anonymous function for the second parameter.
        SoundFile file = Array.Find(Singleton.SoundFiles, match => match.Filename == filename);
        if (file == null)
        {
            Debug.LogError("Cannot pause audio! Sound name" + filename + "not found!");
            return;
        }    
        file.Source.Pause();
    }
    
    public static void UnPause(string filename)
    {
        // Uses an anonymous function for the second parameter.
        SoundFile file = Array.Find(Singleton.SoundFiles, match => match.Filename == filename);
        if (file == null)
        {
            Debug.LogError("Cannot pause audio! Sound name" + filename + "not found!");
            return;
        }    
        file.Source.UnPause();
    }
}