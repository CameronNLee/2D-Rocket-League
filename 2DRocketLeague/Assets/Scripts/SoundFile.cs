using UnityEngine;
namespace Sound.Control
{
    [System.Serializable]
    
    public class SoundFile
    {
        public string Filename;
        public AudioClip SoundClip;

        [Range(0f,1f)]
        public float Volume;

        [HideInInspector]
        public AudioSource Source;
        
        public bool IsLooping;
        public bool PlayOnAwake;
    }
}