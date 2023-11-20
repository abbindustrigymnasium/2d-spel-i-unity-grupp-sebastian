
using System;
using System.Security.AccessControl;
using System;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {
    public AudioClip clip;


    public string name;

    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
            public float fadeInTime = 100f;

    public Sound[] sounds;



    void Awake()
    {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        /*if (s == null) {
            return;
        }*/
        s.source.Play();
    }
        public void Resume (string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        /*if (s == null) {
            return;
        }*/
        s.source.UnPause();
    }
            public void Pause (string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        /*if (s == null) {
            return;
        }*/
        s.source.Pause();
    }
        public void Stop (string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);

        s.source.Stop();
    }

    public void FadeInAudio(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s.source != null)
        {
            // Set the initial volume to 0
            float targetVolume = s.volume;
            s.source.volume = 0;
            s.volume = 0;

            // Start playing the audio
            s.source.Play();

            // Start a coroutine for fading in the audio
            StartCoroutine(FadeIn(s, targetVolume));
        }
    }

    // Coroutine for fading in the audio
    private System.Collections.IEnumerator FadeIn(Sound s, float targetVolume)
    {

        while (s.source.volume < targetVolume)
        {
            s.source.volume += (Time.deltaTime/fadeInTime);
            s.volume += (Time.deltaTime/fadeInTime);
            yield return null;
        }

        // Make sure the volume is set to the target volume after fading in
        s.source.volume = targetVolume;
    }


    public void click() {
        Play("click");
    }

    void Start()
    {
        FadeInAudio("Theme");
        FadeInAudio("ambientSound1");
        FadeInAudio("ambientSound2");
                FadeInAudio("ambientSound3");
                FadeInAudio("ambientSound4");
                FadeInAudio("ambientSound5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
