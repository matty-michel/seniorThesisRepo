using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //allows other functions to easily call sound manager
    public static SoundManager Instance { get; private set; }
    private AudioSource _audioSource;

    void Awake()
    {
        //setting instance of sound manager
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audioClip)
    {
        //playing the passed in audio clip
        _audioSource.PlayOneShot(audioClip);
    }
}
