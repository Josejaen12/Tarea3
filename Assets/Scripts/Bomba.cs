using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public AudioClip bombSound; 
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada espada = collision.GetComponent<Espada>();

        if (!espada)
        {
            return;
        }
       
        if (audioSource != null && bombSound != null)
        {
            audioSource.PlayOneShot(bombSound);
        }

        FindObjectOfType<GameManger>().AlTocarBomba();
    }
}