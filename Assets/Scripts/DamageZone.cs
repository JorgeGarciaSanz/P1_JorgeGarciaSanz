using UnityEngine;


public class DamageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerControler jugador = other.GetComponent<PlayerControler>();
        if (jugador == null) return;

        GameManagerClase.instancia.LoseLife(jugador);
    }
}
