using System.Collections; // Required for IEnumerator
using UnityEngine;

public class ClimbTrigger : MonoBehaviour
{
    public float velocidadSubida = 5f; // Velocidad a la que subirá el objeto
    public float alturaSubida = 2f; // Altura que el objeto debe subir

    private bool isClimbing = false; // Indica si el jugador está actualmente subiendo

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que tocó es el personaje
        if (other.CompareTag("Player") && !isClimbing) // Asegúrate de que tu personaje tenga la etiqueta "Player"
        {
            StartCoroutine(Subir(other.transform)); // Pasar la referencia del transform del jugador
        }
    }

    private IEnumerator Subir(Transform playerTransform)
    {
        isClimbing = true; // Indica que el jugador está subiendo
        float tiempo = 0f;
        Vector3 posicionInicial = playerTransform.position; // Usar la posición del jugador
        Vector3 posicionObjetivo = new Vector3(posicionInicial.x, posicionInicial.y + alturaSubida, posicionInicial.z); // Subir la altura definida

        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime * velocidadSubida;
            playerTransform.position = Vector3.Lerp(posicionInicial, posicionObjetivo, tiempo);
            yield return null; // Espera un frame
        }

        playerTransform.position = posicionObjetivo; // Asegúrate de que llegue a la posición final
        isClimbing = false; // Permite que el jugador vuelva a activar el trigger
    }
}


