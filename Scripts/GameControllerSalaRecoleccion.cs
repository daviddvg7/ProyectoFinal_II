/*  
    Interfaces Inteligentes
    Proyecto Final
        Rafael Cala González - alu0101121901
        Jorge Acevedo de León - alu0101123622
        David Valverde Gómez - alu0101100296
    
    Descripción:
        Se utilizará este script como controlador de la sala de la recolección
        de libros, se instancian diferentes métodos a utilizar.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControllerSalaRecoleccion : MonoBehaviour
{
    // Conjunto de libros
    private GameObject[] books;
    // Puerta de salida
    public GameObject door;
    // Mensaje para la cuenta de libros
    public TextMeshProUGUI finishedLevelMessage;
    // Pista de la sala
    public GameObject hintGame;
    // Elementos de audio
    public AudioClip bookClip;
    public AudioClip allTakenClip;
    public AudioSource audioSource;
    
    void Start()
    {
        books = GameObject.FindGameObjectsWithTag("Libro");
        finishedLevelMessage.text = $"Libros restantes: {books.Length}";
        audioSource = GetComponent<AudioSource>();
    }

    // Se carga el conjunto de libros restante (cada libro se desactiva cuando
    // la retícula lo toca), y se muestran los que quedan.
    // Una vez recogidos todos los libros, se mueve la librería y 
    // aparece la puerta de salida

    public void collectBook()
    {
        books = GameObject.FindGameObjectsWithTag("Libro");
        finishedLevelMessage.text = $"Libros restantes: {books.Length}";
        audioSource.PlayOneShot(bookClip, 0.03f);

        if (books.Length == 0) 
        {
            finishedLevelMessage.text = "";
            hintGame.SetActive(false);
            audioSource.PlayOneShot(allTakenClip, 0.3f);
            door.SetActive(true);
            boofShelf.slide = true;
            CompletedLevels.recoleccion = true;

        }
    }
}
