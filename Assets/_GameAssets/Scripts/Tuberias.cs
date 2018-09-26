using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuberias : MonoBehaviour {

    [SerializeField] private int speed = 3;
    

    void Start () {
        float factorPosicion = Random.Range(-5,10);
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
