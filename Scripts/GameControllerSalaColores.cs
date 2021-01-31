/*  
    Interfaces Inteligentes
    Proyecto Final
        Rafael Cala González - alu0101121901
        Jorge Acevedo de León - alu0101123622
        David Valverde Gómez - alu0101100296
    
    Descripción:
        Se utilizará este script como controlador de la sala de las figuras 
        y colores, se instancian diferentes métodos a utilizar.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameControllerSalaColores : MonoBehaviour
{
    // Figuras que sirven de paleta de colores
    public GameObject star;
    public GameObject diamond;
    public GameObject heart;

    // Conjunto de las figuras en blanco
    private GameObject[] stars;
    private GameObject[] diamonds;
    private GameObject[] hearts;

    // Puerta de salida
    public GameObject door;

    // Elementos de audio
    public AudioClip paintClip;
    public AudioClip selectPaintClip;
    public AudioClip allPaintedClip;
    public AudioSource audioSource;

    // Retícula
    public GameObject reticle;

    // Color actual
    private Color currentColor = Color.white;

    void Start()
    {
        stars = GameObject.FindGameObjectsWithTag("Estrella");
        diamonds = GameObject.FindGameObjectsWithTag("Diamante");
        hearts = GameObject.FindGameObjectsWithTag("Corazon");
        audioSource = GetComponent<AudioSource>();
    }

    // En este método se comprueba si el nivel está completo, 
    // de ser así se ponen todas las gemas de color verde, 
    // se activa la puerta de regreso y se da la sala por completada
    public void updatePaintObjects() 
    {
        if (isLevelCompleted()) 
        {
            currentColor = Color.green;
            setGemsColorToGreen();
            setMainGemsToUnvisible();
            door.SetActive(true);
            GameObject pista = GameObject.FindWithTag("PistaColores");
            pista.GetComponent<TextMeshPro>().SetText("");
            CompletedLevels.colores = true;
        }    
    }

    // Se desactivan las figuras grandes
    void setMainGemsToUnvisible()
    {
        star.SetActive(false);
        diamond.SetActive(false);
        heart.SetActive(false);
    }

    // Se ponen todas las figuras de color verde
    void setGemsColorToGreen()
    {        
        foreach (GameObject currentStar in stars) 
        {
            currentStar.GetComponent<Renderer>().material.color = Color.green;
        }
            
        
        foreach (GameObject currentDiamond in diamonds) 
        {
            currentDiamond.GetComponent<Renderer>().material.color = Color.green;  
        }
            
        
        foreach (GameObject currentHearts in hearts)
        {
            currentHearts.GetComponent<Renderer>().material.color = Color.green;
        }

        reticle.GetComponent<GvrReticlePointer>().changeColorGreen();
            
    }

    // Se verifica si cada figura se ha pintado de su color correspondiente
    bool isLevelCompleted()
    {
        foreach (GameObject currentStar in stars) 
        {
            if (star.GetComponent<Renderer>().material.color != currentStar.GetComponent<Renderer>().material.color) 
            {
                return false;
            }
                
        }
            
        
        foreach (GameObject currentDiamond in diamonds) 
        {
            if (diamond.GetComponent<Renderer>().material.color != currentDiamond.GetComponent<Renderer>().material.color)
            {
                return false;
            }

        }
            
        
        foreach (GameObject currentHearts in hearts) 
        {
            if (heart.GetComponent<Renderer>().material.color != currentHearts.GetComponent<Renderer>().material.color) 
            {
                return false;
            }
        }
        audioSource.PlayOneShot(allPaintedClip, 0.3f);
        return true;
    }

    // Se toma el color de la paleta seleccionada
    public void takeColor (GameObject GameObjectToTakeColor)
    {
        audioSource.PlayOneShot(selectPaintClip, 0.1f);
        currentColor = GameObjectToTakeColor.GetComponent<Renderer>().material.color;
    }

    // Se pinta la figura
    public void paint (GameObject gameObjectToPaint)
    {
        audioSource.PlayOneShot(paintClip, 0.09f);
        gameObjectToPaint.GetComponent<Renderer>().material.color = currentColor;
    }
}
