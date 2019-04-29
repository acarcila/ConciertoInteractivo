using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoCamarax2 : MonoBehaviour {
    float tiempo;
    
    public AudioSource song;

    // Use this for initialization
    void Start () {

  
		
	}
	
	// Update is called once per frame
	void Update () {
        tiempo = 4.27f * 2 * (song.time);
        transform.position = new Vector3((tiempo - 5), 6, 0);

        //transform.position = new Vector3((2.17391304f * tiempo)-5, 6, 0);
        //transform.position = new Vector3((4.27f* tiempo) - 5, 6, 0);
        //transform.position = new Vector3((8.69565216f * tiempo) - 9, 6, 0);

    }
}
