using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip[] audios;
    AudioSource audiosAS;
    [SerializeField] GameObject prefab;
    // Start is called before the first frame update
    public static AudioController instance;
    void Awake()
    {
        instance = this;
    }
    public void PlaySound(int i = 0, float volume = 1f, bool isLoopback = false, bool repeat = false)
    {
        Play(audios[i], ref audiosAS);
    }

    void Play(AudioClip clip, ref AudioSource audioSource, float volume = 1f, bool isLoopback = false, bool repeat = false)
    {
        audioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();
        audioSource.volume = volume;
        audioSource.loop = isLoopback;
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
