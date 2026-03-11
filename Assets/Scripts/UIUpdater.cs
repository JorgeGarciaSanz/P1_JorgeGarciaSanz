using UnityEngine;
using TMPro;
using System.Collections;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoMonedas;
    [SerializeField] private TextMeshProUGUI textoVidas;

    private void Start()
    {
        StartCoroutine(EsperarYConectar());
    }

    private IEnumerator EsperarYConectar()
    {
        while (GameManagerClase.instancia == null)
            yield return null;

        GameManagerClase.instancia.AlCambiarMonedas += ActualizarMonedas;
        GameManagerClase.instancia.AlCambiarVidas += ActualizarVidas;

        ActualizarMonedas(GameManagerClase.instancia.Monedas);
        ActualizarVidas(GameManagerClase.instancia.Vidas);
    }

    private void OnDisable()
    {
        if (GameManagerClase.instancia == null) return;

        GameManagerClase.instancia.AlCambiarMonedas -= ActualizarMonedas;
        GameManagerClase.instancia.AlCambiarVidas -= ActualizarVidas;
    }

    private void ActualizarMonedas(int valor)
    {
        textoMonedas.text = "Monedas: " + valor;
    }

    private void ActualizarVidas(int valor)
    {
        textoVidas.text = "Vidas: " + valor;
    }
}