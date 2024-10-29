using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Jugar()
    {
        // Cargar la escena principal del juego, cambia "NombreDeTuEscena" por el nombre de tu escena.
        SceneManager.LoadScene("Scene_1");
    }

    public void Controles()
    {
        // Aquí podrías cargar una escena de opciones o mostrar un menú de opciones.
        Debug.Log("Opciones seleccionadas");
    }

    public void Salir()
    {
        // Salir de la aplicación
        Application.Quit();
        Debug.Log("El juego se ha cerrado"); // Este mensaje no aparece al compilar, solo en el editor.
    }
}
