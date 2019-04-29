using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovimientoPlayerOpcion2 : MonoBehaviour
{

    //Variables de tiempo y posicion para movimientos
    float tiempo;
    float tiempoYPos;
    float tiempoZPos;
    float tiempoCaida;
    float tiempoBlink;
    float tiempoGameOver;
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
    bool blink;
    bool blinkI;
    bool blinkD;
    bool gameOverBool;
    bool movZ;
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

    //render
    public Renderer renderer;
    public GameObject GUI;
    public RawImage gameOver;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;

    public Transform puntoInicio;

    private float xInicial;
    private float yInicial;
    private float zInicial;



    // Use this for initialization
    void Start()
    {
        //  rb = GetComponent<Rigidbody>();
        tiempo = 0;
        tiempoYPos = 1;
        tiempoZPos = 0;
        tiempoCaida = 1;
        tiempoBlink = 0;
        xInicial = puntoInicio.position.x;
        yInicial = puntoInicio.position.y;
        zInicial = puntoInicio.position.z;
        y = 1;
        z = 0;
        x = 0;
        saltar = true;
        saltarI = true;
        saltarD = true;
        subir = false;
        bajar = false;
        izq = false;
        der = false;
        caida = false;
        saltoAlto = false;
        GUI.SetActive(false);
        gameOverBool = false;
        movZ = false;
        vida1.SetActive(true);
        vida2.SetActive(true);
        vida3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {


        tiempo = 4.27f * (song.time);
        transform.position = new Vector3(
            xInicial + tiempo,
            y,
            zInicial + z
        );

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


            if (saltoAlto == true)
            {
                if (tiempoYPos > 3)
                {
                    subir = false;
                    bajar = true;
                    sonidoBlack = false;
                    saltoAlto = false;
                }
            }
            else
            {

                if (tiempoYPos > 2)
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
        if (izq == true && z < 1 && z >= 0)
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

        if (z < -1)
        {
            tiempoZPos = -1;
            der = false;
            z = -1;
        }

        //Moverse drecha desde z = 1
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

        if (blink == true && vidas > 0)
        {
            if (movZ == true)
            {
                z = 0;
            }
            subir = false;
            saltar = false;
            saltarI = false;
            saltarD = false;
            tiempoBlink += Time.deltaTime;
            if (tiempoBlink < 0.1f)
            {
                renderer.enabled = false;
            }
            if (tiempoBlink > 0.1f && tiempoBlink < 0.2f)
            {
                renderer.enabled = true;
            }
            if (tiempoBlink > 0.2f && tiempoBlink < 0.3f)
            {
                renderer.enabled = false;
            }
            if (tiempoBlink > 0.3f && tiempoBlink < 0.4f)
            {
                renderer.enabled = true;
            }
            if (tiempoBlink > 0.5f && tiempoBlink < 0.6f)
            {
                renderer.enabled = false;
            }
            if (tiempoBlink > 0.7f && tiempoBlink < 0.8f)
            {
                renderer.enabled = true;
            }

            if (tiempoBlink > 0.8)
            {
                tiempoBlink = 0;
                blink = false;
                tiempoZPos = 0;
                tiempoYPos = 1;
                saltar = true;
                saltarI = true;
                saltarD = true;
                subir = false;
                movZ = false;

            }
        }


        if (blinkD == true && vidas > 0)
        {
            if (movZ == true)
            {
                z = -1;
            }
            subir = false;
            saltar = false;
            saltarI = false;
            saltarD = false;
            tiempoBlink += Time.deltaTime;
            if (tiempoBlink < 0.1f)
            {
                renderer.enabled = false;
            }
            if (tiempoBlink > 0.1f && tiempoBlink < 0.2f)
            {
                renderer.enabled = true;
            }
            if (tiempoBlink > 0.2f && tiempoBlink < 0.3f)
            {
                renderer.enabled = false;
            }
            if (tiempoBlink > 0.3f && tiempoBlink < 0.4f)
            {
                renderer.enabled = true;
            }
            if (tiempoBlink > 0.5f && tiempoBlink < 0.6f)
            {
                renderer.enabled = false;
            }
            if (tiempoBlink > 0.7f && tiempoBlink < 0.8f)
            {
                renderer.enabled = true;
            }

            if (tiempoBlink > 0.8)
            {
                tiempoBlink = 0;
                blinkD = false;
                tiempoZPos = -1;
                tiempoYPos = 1;
                saltar = true;
                saltarI = true;
                saltarD = true;
                subir = false;
                movZ = false;

            }
        }



        if (blinkI == true && vidas > 0)
        {
            if (movZ == true)
            {
                z = 1;
            }
            subir = false;
            saltar = false;
            saltarI = false;
            saltarD = false;
            tiempoBlink += Time.deltaTime;
            if (tiempoBlink < 0.1f)
            {
                renderer.enabled = false;
            }
            if (tiempoBlink > 0.1f && tiempoBlink < 0.2f)
            {
                renderer.enabled = true;
            }
            if (tiempoBlink > 0.2f && tiempoBlink < 0.3f)
            {
                renderer.enabled = false;
            }
            if (tiempoBlink > 0.3f && tiempoBlink < 0.4f)
            {
                renderer.enabled = true;
            }
            if (tiempoBlink > 0.5f && tiempoBlink < 0.6f)
            {
                renderer.enabled = false;
            }
            if (tiempoBlink > 0.7f && tiempoBlink < 0.8f)
            {
                renderer.enabled = true;
            }

            if (tiempoBlink > 0.8)
            {
                tiempoBlink = 0;
                blinkI = false;
                tiempoZPos = 1;
                tiempoYPos = 1;
                saltar = true;
                saltarI = true;
                saltarD = true;
                subir = false;
                movZ = false;
            }
        }


        if (gameOverBool == true && tiempoGameOver < 9)
        {
            tiempoGameOver += Time.deltaTime;
            gameOver.GetComponent<RectTransform>().sizeDelta = new Vector2(200 * tiempoGameOver, 140 * tiempoGameOver);


        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0);
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

            if (blink == true || blinkD == true || blinkI == true)
            {
            }
            else
            {

                if (z > 0 || z < 0)
                {
                    vidas -= 1;
                    blink = true;
                    movZ = true;

                }
                if (vidas == 0)
                {
                    caida = true;
                }
            }



        }


        if ((other.gameObject.tag == "TransparenteI") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {

            if (blink == true || blinkD == true || blinkI == true)
            {
            }
            else
            {

                vidas -= 1;
                blinkI = true;
                movZ = true;

                if (vidas == 0)
                {
                    caida = true;
                }

            }




        }


        if ((other.gameObject.tag == "TransparenteD") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {

            if (blink == true || blinkD == true || blinkI == true)
            {
            }
            else
            {

                vidas -= 1;
                blinkD = true;
                movZ = true;

                if (vidas == 0)
                {
                    caida = true;
                }

            }


        }



        // si el cubo es AZUL y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "Blue") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {
            movZ = true;
            blink = true;
            vidas -= 1;
            contVidas();
            Destroy(other.gameObject);

        }

        // si el cubo es AZUL y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "BlueI") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {
            movZ = true;
            blinkI = true;
            vidas -= 1;
            contVidas();
            Destroy(other.gameObject);

        }

        // si el cubo es AZUL y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "BlueD") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {
            movZ = true;
            blinkD = true;
            vidas -= 1;
            contVidas();
            Destroy(other.gameObject);

        }


        // si el cubo es ROJO y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "Red") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {
            blink = true;
            vidas -= 1;
            contVidas();
            Destroy(other.gameObject);


        }

        // si el cubo es Verde y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "Green") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {
            blink = true;
            vidas -= 1;
            contVidas();
        }

        // si el cubo es Negro y el material del cubo es igual al material de la esfera
        if ((other.gameObject.tag == "Black") && (other.gameObject.GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial))
        {

        }




        //sonidos cuando la esfera y el cubo son del mismo material

        //Black
        if ((other.gameObject.tag == "Black") && (other.gameObject.GetComponent<Renderer>().sharedMaterial == gameObject.GetComponent<Renderer>().sharedMaterial))
        {

        }

        //Blue
        if ((other.gameObject.tag == "Blue") && (other.gameObject.GetComponent<Renderer>().sharedMaterial == gameObject.GetComponent<Renderer>().sharedMaterial))
        {
            sonidoBlack = true;
            saltoAlto = true;
        }

        if ((other.gameObject.tag == "BlueI") && (other.gameObject.GetComponent<Renderer>().sharedMaterial == gameObject.GetComponent<Renderer>().sharedMaterial))
        {
            sonidoBlack = true;
            saltoAlto = true;
        }

        if ((other.gameObject.tag == "BlueD") && (other.gameObject.GetComponent<Renderer>().sharedMaterial == gameObject.GetComponent<Renderer>().sharedMaterial))
        {
            sonidoBlack = true;
            saltoAlto = true;
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
            Destroy(other.gameObject);
            tom.Play(0);
        }



    }

    void contVidas()
    {

        if (vidas == 3)
        {

            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
        }

        if (vidas == 2)
        {
            vida1.SetActive(false);
            vida2.SetActive(true);
            vida3.SetActive(true);
        }

        if (vidas == 1)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(true);
        }


        //Agregar el && false
        if (vidas == 0)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
            song.Pause();
            GUI.SetActive(true);
            gameOverBool = true;

        }
    }




}






