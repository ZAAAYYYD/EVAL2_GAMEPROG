using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }


    private AudioClip _SongCoin;
    private AudioSource _audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);

        }

        else
        {
            instance = this;

        }
        _SongCoin = Resources.Load<AudioClip>("Sounds/coin01");

        _audioSource = GetComponent<AudioSource>();

    }

  

    public void PlaySongCoin()
    {
        _audioSource.PlayOneShot(_SongCoin);
    }

}
