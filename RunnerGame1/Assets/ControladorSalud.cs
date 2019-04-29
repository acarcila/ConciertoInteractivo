using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControladorSalud : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    
    public Image petaloIzquierda1;
    public Image petaloIzquierda2;
    public Image petaloIzquierda3;
    public Image petaloDerecha1;
    public Image petaloDerecha2;
    public Image petaloDerecha3;

    private float saludMaximaP1;
    private float saludP1;
    private float saludMaximaP2;
    private float saludP2;

    // Start is called before the first frame update
    void Start()
    {
        saludMaximaP1 = player1.GetComponent<MovimientoPlayerOpcion2>().vidas;
        saludP1 = saludMaximaP1;

        saludMaximaP2 = player2.GetComponent<MovimientoPlayerOpcion2>().vidas;
        saludP2 = saludMaximaP2;
    }

    // Update is called once per frame
    void Update()
    {
        saludP1 = player1.GetComponent<MovimientoPlayerOpcion2>().vidas;
        petaloIzquierda3.fillAmount = (saludP1-(2*saludMaximaP1/3))/(saludMaximaP1/3);
        petaloIzquierda2.fillAmount = (saludP1-(saludMaximaP1/3))/(saludMaximaP1/3);
        petaloIzquierda1.fillAmount = (saludP1)/(saludMaximaP1/3);

        saludP2 = player2.GetComponent<MovimientoPlayerOpcion2>().vidas;
        petaloDerecha3.fillAmount = (saludP2-(2*saludMaximaP2/3))/(saludMaximaP2/3);
        petaloDerecha2.fillAmount = (saludP2-(saludMaximaP2/3))/(saludMaximaP2/3);
        petaloDerecha1.fillAmount = (saludP2)/(saludMaximaP2/3);
    }
}
