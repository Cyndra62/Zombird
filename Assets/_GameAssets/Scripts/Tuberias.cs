using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuberias : MonoBehaviour {

    [SerializeField] private int speed = 3;
    [Header("Variables Rango Altura Tuberias")]
    [SerializeField] private int UpLimit = 10;
    [SerializeField] private int DownLimit = -5;

    void Start () {
        float factorPosicion = Random.Range(DownLimit,UpLimit);
        transform.position = new Vector3(transform.position.x, transform.position.y + factorPosicion, transform.position.z);
       
    }
	
	// Update is called once per frame
	void Update () {
        if (GameConfig.IsPlaying()==true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        
      
        if (transform.position.z > 20f)
            {
                Destroy(this.gameObject);
            }
    }

   
}
