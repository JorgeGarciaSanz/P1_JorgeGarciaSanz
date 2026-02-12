using NUnit.Framework.Interfaces;
using UnityEngine;

public class MovingPlantform : MonoBehaviour
{

    private  Vector3 posicionInicial;
    private Vector3 posicionFinal;

    private bool voyAlaFInal = true;
    [SerializeField]private GameObject destino;
    [SerializeField]private float velocidad = 1f;

    private Rigidbody rb;

    

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position ;
        posicionFinal = destino.transform.position;

        destino.GetComponent<Renderer>().enabled = false;

        rb = GetComponent<Rigidbody>();





    }

    // Update is called once per frame
    private void  FixedUpdate() {
       
        Vector3 posActual = transform.position;

        
       
         Vector3 newPosition;

        if (voyAlaFInal)
        {
            
            newPosition = Vector3.MoveTowards(posActual, posicionFinal, velocidad * Time.fixedDeltaTime);

        }
        else
        {
            newPosition = Vector3.MoveTowards(posActual, posicionInicial, velocidad * Time.fixedDeltaTime);
        }

        if (Vector3.Distance(posActual, posicionFinal) < 0.1f)
        {
            voyAlaFInal = false;
        }
        else if (Vector3.Distance(posActual, posicionInicial) < 0.1f)
        {
            voyAlaFInal = true;
        }

        //Vector3 newPosition = Vector3.MoveTowards(posActual, posicionFinal, velocidad * Time.fixedDeltaTime);

        rb.MovePosition(newPosition);

    }
}
