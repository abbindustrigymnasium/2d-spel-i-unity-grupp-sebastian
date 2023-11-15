
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
        public void Stop (string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);

        s.source.Stop();
    }
    void Start()
    {
        Play("Theme");
        Play("ambientSound1");
        Play("ambientSound2");
                Play("ambientSound3");
                Play("ambientSound4");
                Play("ambientSound5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
