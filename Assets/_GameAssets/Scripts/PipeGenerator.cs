using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] Transform tuberia;
    [SerializeField] private int tiempo;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("GeneratePipe", 0, tiempo);
        

    }
    // Update is called once per frame
    void Update()
    {

    }

    void GeneratePipe()
    {
        //Generamos tuberias

        if (GameConfig.IsPlaying())
        {
            Instantiate(tuberia, transform.position, Quaternion.identity);
        }
        
        
    }
    
}
