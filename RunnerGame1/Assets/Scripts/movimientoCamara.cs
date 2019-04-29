using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoCamara : MonoBehaviour {
    float tiempo;
	public float y;
	public float z;
    
    public AudioSource song;

    // Use this for initialization
    void Start () {

  
		
	}
	
	// Update is called once per frame
	void Update () {
        tiempo = 4.27f * (song.time);
        transform.position = new Vector3((tiempo - 2.6f), y, z);

        //transform.position = new Vector3((2.17391304f * tiempo)-5, 6, 0);
        //transform.position = new Vector3((4.27f* tiempo) - 5, 6, 0);
        //transform.position = new Vector3((8.69565216f * tiempo) - 9, 6, 0);

    }
}
