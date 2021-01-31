/*  
    Interfaces Inteligentes
    Proyecto Final
        Rafael Cala González - alu0101121901
        Jorge Acevedo de León - alu0101123622
        David Valverde Gómez - alu0101100296
    
    Descripción:
        Se utilizará este script como controlador de la sala de la brújula,
        se instancian diferentes métodos a utilizar.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControllerSalaBrujula : MonoBehaviour
{
    // Texto donde aparecerá el nombre de cada constelación
    public TextMeshProUGUI constellationName;

    // Elementos de audio
    public AudioClip constelationClip;
    public AudioSource audioSource;
    public AudioClip finalClip;
    
    // Array de estrellas relativo a la constelación de la Osa Mayor
    private GameObject[] constellationStars;    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
        constellationStars = GameObject.FindGameObjectsWithTag("OsaMayor");
    }

    // Se cambia el mensaje inicial
    public void finishedMessage ()
    {
        TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.SetText("Has resuelto el puzle.\n Al ESTE encontrarás la salida.");

    }

    // Se muestra el nombre de la constelación
    public void write()
    {
        constellationName.text = $"{gameObject.name}";
        audioSource.PlayOneShot(constelationClip, 0.2f);
    }

    // Se pone la osa mayor de color rojo y se da la sala por completada
    public void addRangeLightToConstellation() 
    {
        foreach (GameObject light in constellationStars)
        {
            light.GetComponent<Light>().range = 0.8F;
            light.GetComponent<Light>().color = new Color(0.9F, 0.1F, 0.2F);
        }
        audioSource.PlayOneShot(finalClip, 0.3f);
        CompletedLevels.brujula = true;
    }
}
