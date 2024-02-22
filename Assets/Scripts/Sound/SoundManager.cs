using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private AudioClip explosion;

    private void OnEnable()
    {
        Bomb.OnDestroyBomb += PlayExplosion;
    }
    private void OnDisable()
    {
        Bomb.OnDestroyBomb -= PlayExplosion;
    }
    private void PlayExplosion()
    {
        m_audioSource.pitch = Random.Range(0.9f, 1);
        m_audioSource.PlayOneShot(explosion);
    }
}
