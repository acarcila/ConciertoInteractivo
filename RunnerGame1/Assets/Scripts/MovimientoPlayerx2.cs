using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoPlayerx2 : MonoBehaviour {

    //Variables de tiempo y posicion para movimientos
    float tiempo;
    float tiempoYPos;
    float tiempoZPos;
    float tiempoCaida;
    bool saltar;
    bool saltarI;
    bool saltarD;
    bool saltoAlto;
    bool subir;
    bool bajar;
    bool izq;
    bool der;
    bool caida;
    float y;
    float z;
    float x;
    //bool velAudio;
    //public float bpm;

    //teclas
    public KeyCode Left;
    public KeyCode Up;
    public KeyCode Right;
    //cambio de color
    public KeyCode green;
    public KeyCode blue;
    public KeyCode black;
    public KeyCode red;
    public KeyCode Neu;

    //Materiales
    public Material matN;
    public Material matGreen;
    public Material matBlue;
    public Material matBlack;
    public Material matRed;
    public Material matTrans;

    //audios
    public AudioSource kick;
    public AudioSource clap;
    public AudioSource snare;
    public AudioSource tom;
    public AudioSource song;

    //Vidas y cubos
    public int vidas;
    public int numVidas;
    public Image[] Cubes;
    public Sprite fullCubes;
    public Sprite emptyCubes;

    //saltos en color
    bool sonidoBlack;
    bool sonidoBlue;
    bool sonidoRed;
    bool sonidoGreen;


    //BPM

    //public float gain = 0.5F;
    //public int signatureHi = 4;
    //public int signatureLo = 4;
    //private double nextTick = 0.0F;
    //private float amp = 0.0F;
    //private float phase = 0.0F;
    //private double sampleRate = 0.0F;
    //private int accent;
    //private bool running = false;


    // Use this for initialization
    void Start () {
      //  rb = GetComponent<Rigidbody>();
        tiempo = 0;
        tiempoYPos = 1;
        tiempoZPos = 0;
        tiempoCaida = 1;
        y = 1;
        z = 0;
        saltar = true;
        saltarI = true;
        saltarD = true;
        subir = false;
        bajar = false;
        izq = false;
        der = false;
        caida = false;
        vidas = 3;
        saltoAlto = false;
       // //BPM
       // accent = signatureHi;
       //// double startTick = AudioSettings.dspTime;
       //// sampleRate = AudioSettings.outputSampleRate;
       //// nextTick = startTick * sampleRate;
       // running = true;



    }

    // Update is called once per frame
    void Update () {


        //double samplesPerTick = sampleRate * 60.0F / bpm * 4.0F / signatureLo;


        //tiempo += Time.deltaTime;
        //Debug.Log("TIEMPO" + AudioSettings.dspTime);
        //Debug.Log("SONG" + song.time);
        //Debug.Log("X" + x);

        //if (velAudio == true)
        //{
        //    x = ((bpm/60) * song.time) + 2;
        //}
        //else {
        //    x = tiempo;
        // }

        tiempo = 4.27f * 2 *(song.time);
        transform.position = new Vector3(tiempo, y, z);

        //Velocidad un Beat cada 4 cuadros
        //transform.position = new Vector3(8.69565216f * tiempo, y, z);

        //Velocidad un Beat cada 2 cuadros
        //transform.position=new Vector3(4.2735042735042735042735042735043f * tiempo, y, z);




        //Velocidad un Beat cada 2 cuadros 124 beats
        //transform.position=new Vector3(4.13333334f * tiempo, 1, 0);

        //Velocidad un Beat por cuadro
        // transform.position = new Vector3(2.17391304f * tiempo, 1, 0);


        //Saltar tecla W
        if (Input.GetKeyDown(Up) && saltar == true)
        {
            if (sonidoBlack == true)
            {
                kick.Play(0);
            }
            subir = true;
            saltar = false;
            saltarI = false;
            saltarD = false;            
        }

        //Saltar izquierda letra A
        if (Input.GetKeyDown(Left) && saltarI == true)
        {
            if (sonidoBlack == true)
            {
                kick.Play(0);
            }
            if (z != 1)          
            {
                subir = true;
                saltar = false;
                saltarI = false;
                saltarD = false;
                izq = true;
            }
        }

        //Saltar izquierda letra D
        if (Input.GetKeyDown(Right) && saltarD == true)
        {
            if (sonidoBlack == true)
            {
                kick.Play(0);
            }
            if (z != -1)
            {
                subir = true;
                saltar = false;
                saltarI = false;
                saltarD = false;
                der = true;
            }
        }

        //Moverse arriba
        if (subir == true)
        {
            tiempoYPos += Time.deltaTime * 10;
            y = tiempoYPos;            


            if (saltoAlto == true){
                 if (tiempoYPos > 3)
            {
                subir = false;
                bajar = true;
                sonidoBlack = false;
                saltoAlto = false;
            }
            }else{

            if (tiempoYPos > 1.5)
            {
                subir = false;
                bajar = true;
                sonidoBlack = false;
            }      
            }
        }

        //Moverse abajo
        if (bajar == true)
        {
            tiempoYPos -= Time.deltaTime * 6;
            y = tiempoYPos;
            if (tiempoYPos < 1)
            {
                y = 1;
                bajar = false;
                saltar = true;
                saltarI = true;
                saltarD = true;
            }
        }

        //Moverse izquierda desde z = 0
        if (izq == true && z < 1 && z >= 0 )
        {
            tiempoZPos += Time.deltaTime * 3;
            z = tiempoZPos;

            if (z > 1)
            {
           tiempoZPos = 1;
           izq = false;
           z = 1;
            }

        }

        //Moverse izquierda desde z = -1
        if (izq == true && z < 0)
        {
            tiempoZPos += Time.deltaTime * 3;
            z = tiempoZPos;

            if (z > 0)
            {
                tiempoZPos = 0;
                izq = false;
                z = 0;
            }
        }

        //Moverse derecha desde z = 0
        if (der == true && z > -1 && z <= 0)
        {
           tiempoZPos -= Time.deltaTime * 3;
           z = tiempoZPos;
        }

        if (z < -1 )
        {
            tiempoZPos = -1;
            der = false;
            z = -1;
        }

        //Moverse izquierda desde z=1
        if (der == true && z > 0)
        {
            tiempoZPos -= Time.deltaTime * 3;
            z = tiempoZPos;

            if (z < 0)
            {
                tiempoZPos = 0;
                der = false;
                z = 0;
            }
        }

        //Caida

        if (caida == true)
        {
            tiempoCaida -= Time.deltaTime * 5;
            y = tiempoCaida;
        }


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
        if (Input.GetKeyDown(red))
        {       
            GetComponent<Renderer>().material = matRed;
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
            caida = true;
         

        }

        // si el cubo es AZUL y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "Blue") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {         

            vidas -= 1;
            contVidas();
            Destroy(other.gameObject);

        }
        else {
        }

        // si el cubo es ROJO y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "Red") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {

            vidas -= 1;
            contVidas();
            Destroy(other.gameObject);

        }
        else
        {
        }

        // si el cubo es Verde y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "Green") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
    {
            vidas -= 1;
            contVidas();
        }

    // si el cubo es Negro y el material del cubo es igual al material de la esfera
    if ((other.gameObject.tag == "Black") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
    {
     
        vidas -= 1;
        contVidas();
    }




    //sonidos cuando la esfera y el cubo son del mismo material

    //Black
    if ((other.gameObject.tag == "Black") && (other.gameObject.GetComponent<Renderer>().sharedMaterial == gameObject.GetComponent<Renderer>().sharedMaterial))
    {
            sonidoBlack = true;            
            saltoAlto = true;
    }

    //Blue
    if ((other.gameObject.tag == "Blue") && (other.gameObject.GetComponent<Renderer>().sharedMaterial == gameObject.GetComponent<Renderer>().sharedMaterial))
    {
            clap.Play(0);
    }
    //Red
    if ((other.gameObject.tag == "Green") && (other.gameObject.GetComponent<Renderer>().sharedMaterial == gameObject.GetComponent<Renderer>().sharedMaterial))
    {
        
            Destroy(other.gameObject);
            snare.Play(0);
    }
    //Green
    if ((other.gameObject.tag == "Red") && (other.gameObject.GetComponent<Renderer>().sharedMaterial == gameObject.GetComponent<Renderer>().sharedMaterial))
    {
            tom.Play(0);

        }

   

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

    if (vidas == 0)
    {
            caida = true;
    }
}

}






                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             