using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaPorTiempo : MonoBehaviour
{
    public string Scene_2 = "Scene_2"; // Nombre de la escena a la que quieres cambiar
    public float tiempoEnZona = 5.0f; // Tiempo que el jugador debe permanecer en el área

    private float contadorTiempo = 0.0f;
    private bool jugadorEnZona = false;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el área es el jugador
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del área, se reinicia el contador y el flag
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = false;
            contadorTiempo = 0.0f;
        }
    }

    private void Update()
    {
        // Si el jugador está en el área, comienza a contar el tiempo
        if (jugadorEnZona)
        {
            contadorTiempo += Time.deltaTime;

            // Si ha pasado el tiempo requerido, cambia de escena
            if (contadorTiempo >= tiempoEnZona)
            {
                SceneManager.LoadScene(Scene_2);
            }
        }
    }
}
