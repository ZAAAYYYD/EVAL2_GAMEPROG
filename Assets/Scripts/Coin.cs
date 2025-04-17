using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    [Header("Valeur & Son")]
    public int value = 1;
    public AudioClip pickupSound;

    AudioSource src;

    void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // 1) Ajoute le score
            GameManager.Instance.AddScore(value);

            // 2) Joue le son
            AudioManager.instance.PlaySongCoin();

            // 3) Detruit l’objet après le son
            Destroy(gameObject);
        }
    }
}
