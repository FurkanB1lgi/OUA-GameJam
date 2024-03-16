using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioPlay;
    public AudioSource soundPlay;
    float timer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnPlaySound, OnPlaySound);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnPlaySound, OnPlaySound);
    }


    private void OnPlaySound(object value)
    {
        audioPlay.clip = Resources.Load<AudioClip>((string)value);
        audioPlay.PlayOneShot(audioPlay.clip);
    }

    private void OnPlaySoundBg(object value, object volume)
    {
        soundPlay.volume = (float)volume;

        soundPlay.clip = Resources.Load<AudioClip>((string)value);
        soundPlay.PlayOneShot(soundPlay.clip);
    }
}