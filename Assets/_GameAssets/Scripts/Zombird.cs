using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Zombird : MonoBehaviour
{

    [SerializeField] private float fuerza = 3f;
    [SerializeField] private Text marcadorPuntos;
    [SerializeField] ParticleSystem prefabExplosion;
    [Header("Audio")]
    [SerializeField] AudioSource hit;
    [SerializeField] AudioClip points;
    [SerializeField] AudioClip wings;
    private Rigidbody rb;
    private int puntuation = 0;
    private AudioSource source;


    void Start()
    {
        rb= GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        
        ActualizarPuntos();
        GameConfig.ArrancaJuego();

    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.up * fuerza);
            source.PlayOneShot(wings, 1);
        }

    }
    //Metodo que actualiza los puntos
    void ActualizarPuntos()
    {
        marcadorPuntos.text = "Score: " + puntuation;
        if (puntuation > 0)
        {
            source.PlayOneShot(points, 1);
        }

    }

    //Metodo que destruye el pajaro cada vez que choca
    private void OnCollisionEnter(Collision collision)
    {
        //Detener el juego
        hit.Play();
        GameConfig.ParaJuego();
        
        //Crear sistema de particulas
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        //Desactivar Renderer
        gameObject.SetActive(false);
        Invoke("FinalizarPartida", 3f);
    }

    //Metodo que da los puntos
    private void OnTriggerExit(Collider other)
    {
        puntuation++;
        ActualizarPuntos();
    }

    void FinalizarPartida()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
    }
    
}
