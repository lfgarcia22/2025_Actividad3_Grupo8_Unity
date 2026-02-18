using UnityEngine;

public enum SoundType
{
    SHOT
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;
    private static float volume = 1.0f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // default settings
        volume = PlayerPrefs.GetFloat("SoundVolume");
    }

    public static void PlaySound(SoundType sound)
    {
        Debug.Log("Playing sound: " + sound.ToString());
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }
}
