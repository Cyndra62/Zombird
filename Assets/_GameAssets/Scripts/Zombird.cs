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
    private Rigidbody rb;
    private int puntuation = 0;
   

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        ActualizarPuntos();
        GameConfig.ArrancaJuego();

    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.up * fuerza);
        }

    }
    //Metodo que actualiza los puntos
    void ActualizarPuntos()
    {
        marcadorPuntos.text = "Score: " + puntuation;


    }

    //Metodo que destruye el pajaro cada vez que choca
    private void OnCollisionEnter(Collision collision)
    {
        //Detener el juego
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
