using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimientoJugador : MonoBehaviour {


    //velocidad
    public float velocidad1;
    private float velocidad;

    //audios
    public AudioSource kick;
    public AudioSource clap;
    public AudioSource song;

    //teclas
    public KeyCode Ini;
 

    //cambio de color
    public KeyCode green;
    public KeyCode blue;
    public KeyCode black;
    public KeyCode Neu;

    //variables
    public bool onGround;
    //private Rigidbody rb;
    public Material matN;
    public Material matGreen;
    public Material matBlue;
    public Material matBlack;
    public Material matTrans;

    public int vidas;
    public int numVidas;
    public Image[] Cubes;
    public Sprite fullCubes;
    public Sprite emptyCubes;
    private int pos;

    float tiempo;
    bool empezar;

    // Use this for initialization
    void Start () {
      //  rb = GetComponent<Rigidbody>();
        
       
    }

    // Update is called once per frame
    void Update() {



   

        
    //cambios


            //Cambios de material

        if (Input.GetKeyDown(Neu))
        {
           GetComponent<Renderer>().material = matN;
        }
        if (Input.GetKeyDown(green))
        {
           GetComponent<Renderer>().material = matGreen;
        }
        if (Input.GetKeyDown(blue))
        {
           GetComponent<Renderer>().material = matBlue;
        }
        if (Input.GetKeyDown(black))
        {
           GetComponent<Renderer>().material = matBlack;
        }

        contVidas();
    }

    void OnCollisionEnter(Collision other)
{
        // si el cubo es TRASNPARENTE y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "Transparente") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {
            //Debug.Log("Azul: "+tiempo);
            clap.Play(0);
            vidas -= 1;
            contVidas();
            // Destroy(other.gameObject);
        }

        // si el cubo es AZUL y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "Blue") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
    {
        //Debug.Log("Azul: "+tiempo);
        clap.Play(0);
        vidas -= 1;
        contVidas();
      // Destroy(other.gameObject);
    }
    // si el cubo es Verde y el material del cubo es igual al material de la esfera
    if ((other.gameObject.tag == "Green") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
    {
        vidas -= 1;
        //Destroy(other.gameObject);
        contVidas();
    }
    // si el cubo es Negro y el material del cubo es igual al material de la esfera
    if ((other.gameObject.tag == "Black") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
    {
        //Debug.Log("Negro: "+tiempo);
        kick.Play(0);
        vidas -= 1;
       // Destroy(other.gameObject);
        contVidas();
    }
    // si el cubo es BLANCO y el material del cubo es igual al material de la esfera
    //if ((other.gameObject.tag == "Blue") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
    //{
    //    vidas -= 1;
      // Destroy(other.gameObject);
    //}
}

void contVidas()
{
    for (int i = 0; i < Cubes.Length; i++)
    {

        if (i < vidas)
        {
            Cubes[i].sprite = fullCubes;
        }
        else
        {
            Cubes[i].sprite = emptyCubes;
        }
        if (i < numVidas)
        {
            Cubes[i].enabled = true;
        }
        else
        {
            Cubes[i].enabled = false;
        }
    }
    if (vidas <= 0)
    {
        // velPj = 0;
    }
    }
}





