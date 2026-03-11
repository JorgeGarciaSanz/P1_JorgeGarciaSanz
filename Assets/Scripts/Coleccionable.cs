using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        GameManagerClase.instancia.addMoneda();
        Destroy(gameObject);
    }
}