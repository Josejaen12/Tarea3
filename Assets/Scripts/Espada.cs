using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public float velocidadMinima = 0.1f;
    public AudioSource audioSource;
    public AudioClip sonidoCorte;   

    private Rigidbody2D rb;
    private Vector3 ultimaPosicionMouse;
    private Vector3 velocidadMouse;

    private Collider2D col;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        // Asegurarse de que el AudioSource y el clip de sonido están referenciados
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (sonidoCorte == null)
        {
            Debug.LogError("El clip de sonido no está asignado.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        AsociarEspadaAlMouse();
        col.enabled = SeMueveElMouse();
    }

    private void AsociarEspadaAlMouse()
    {
        var mousePosicion = Input.mousePosition;
        mousePosicion.z = 10;

        rb.position = Camera.main.ScreenToWorldPoint(mousePosicion);
    }

    private bool SeMueveElMouse()
    {
        Vector3 posicionMouseActual = transform.position;
        float desplazamiento = (ultimaPosicionMouse - posicionMouseActual).magnitude;
        ultimaPosicionMouse = posicionMouseActual;

        return desplazamiento > velocidadMinima;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            audioSource.PlayOneShot(sonidoCorte);
        }
    }
}
