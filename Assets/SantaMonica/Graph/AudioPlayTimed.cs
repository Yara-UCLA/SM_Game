using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioPlayTimed : MonoBehaviour
{
    [SerializeField] private float startTime;
    [SerializeField] private ulong delay;
    [SerializeField] private bool playOnAwake;

    private void Awake()
    {
        if (!playOnAwake)
        {
            return;
        }
        var audioSource = this.GetComponent<AudioSource>();
        audioSource.time = startTime;
        audioSource.Play();
    }

    public void PlayAudio()
    {
        var audioSource = this.GetComponent<AudioSource>();
        audioSource.time = startTime;
        audioSource.Play();
    }

    public void PlayAudioDelay()
    {
        var audioSource = this.GetComponent<AudioSource>();
        audioSource.Play(delay * 44100);
    }

    public void StopAudio()
    {
        var audioSource = this.GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
