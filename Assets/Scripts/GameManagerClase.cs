using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerClase : MonoBehaviour
{
    public static GameManagerClase instancia;

    [SerializeField] private int vidasIniciales = 3;

    private int monedas = 0;
    private int vidas;

    public Action<int> AlCambiarMonedas;
    public Action<int> AlCambiarVidas;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        vidas = vidasIniciales;

        // Para que la UI se pinte al empezar
        AlCambiarMonedas?.Invoke(monedas);
        AlCambiarVidas?.Invoke(vidas);
    }

    public int Monedas { get { return monedas; } }
    public int Vidas { get { return vidas; } }

    public void addMoneda()
    {
        monedas++;
        AlCambiarMonedas?.Invoke(monedas);
    }

    public void LoseLife(PlayerControler jugador)
    {
        vidas--;
        AlCambiarVidas?.Invoke(vidas);

        if (vidas > 0) jugador.Respawn();
        else
        {
            monedas = 0;
            AlCambiarMonedas?.Invoke(monedas);

            vidas = vidasIniciales;
            AlCambiarVidas?.Invoke(vidas);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}