/*  
    Interfaces Inteligentes
    Proyecto Final
        Rafael Cala González - alu0101121901
        Jorge Acevedo de León - alu0101123622
        David Valverde Gómez - alu0101100296
    
    Descripción:
        Se utilizará este script como controlador de la sala general, 
        se instancian diferentes métodos a utilizar, como los 
        necesarios para el control de las letras y las puertas y la inicialización
        del reconocimiento de voz.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Android;
using TextSpeech;
using System;

public class GameControllerSalaGeneral : MonoBehaviour
{
    // Diferentes flags que indican si se ha completado cada nivel
    public bool currentBrujulaLevelFlag;
    public bool currentRecoleccionLevelFlag;
    public bool currentColoresLevelFlag;
    public bool currentAdivinanzaLevelFlag;

    // Elementos de la puerta final
    private GameObject puertaFin;
    private GameObject doorWingFinal;
    private GameObject finalButton;

    // Idioma para el reconocimiento de voz
    const string LANG_CODE = "es-ES";

    // Indica si se ha dicho la clave final
    private bool claveFinal = false;

    // Clave final del juego
    private string finalKey = "fuego";

    // Texto de la pista de la sala
    private GameObject texto;

    void Awake()
    {        
        // Se desactivan los elementos relativos a la puerta final            
        puertaFin = GameObject.Find("PuertaFinal");
        finalButton = GameObject.Find("BotonFinal");
        puertaFin.SetActive(false);
        finalButton.SetActive(false);
    }

    void Start()
    {
        texto = GameObject.Find("PistaJuegoFinal");
        checkCompletedLevels();
        puertaFinal();
    }

    // Se revisa cada nivel para ver si ha sido completado.
    // Aquellos niveles que hayan sido completados, harán
    // desaparecer su puerta y mostrarán su correspondiente letra
    void checkCompletedLevels()
    {
        currentBrujulaLevelFlag = CompletedLevels.brujula;
        if(currentBrujulaLevelFlag == true)
        {
            GameObject letra = GameObject.Find("LetraBrujula");
            GameObject puerta = GameObject.Find("PuertaBrujula");
            letra.GetComponent<TextMeshPro>().SetText("U");
            GameObject.Find("doorWingBrujula").GetComponent<DoorScript>().completed = true;
            puerta.GetComponent<Animator>().SetBool("completedBrujula", true);
        }

        currentRecoleccionLevelFlag = CompletedLevels.recoleccion;
        if(currentRecoleccionLevelFlag == true)
        {
            GameObject letra = GameObject.Find("LetraRecoleccion");
            GameObject puerta = GameObject.Find("PuertaRecoleccion");
            letra.GetComponent<TextMeshPro>().SetText("G");
            GameObject.Find("doorWingRecoleccion").GetComponent<DoorScript>().completed = true;
            puerta.GetComponent<Animator>().SetBool("completedRecoleccion", true);
        }

        currentColoresLevelFlag = CompletedLevels.colores;
        if(currentColoresLevelFlag == true)
        {
            GameObject letra = GameObject.Find("LetraColores");
            GameObject puerta = GameObject.Find("PuertaColores");
            letra.GetComponent<TextMeshPro>().SetText("F");
            GameObject.Find("doorWingColores").GetComponent<DoorScript>().completed = true;
            puerta.GetComponent<Animator>().SetBool("completedColores", true);
        }

        currentAdivinanzaLevelFlag = CompletedLevels.adivinanza;
        if(currentAdivinanzaLevelFlag == true)
        {
            GameObject letra = GameObject.Find("LetraAdivinanza");
            GameObject puerta = GameObject.Find("PuertaAdivinanza");
            letra.GetComponent<TextMeshPro>().SetText("O");
            GameObject.Find("doorWingAdivinanza").GetComponent<DoorScript>().completed = true;
            puerta.GetComponent<Animator>().SetBool("completedAdivinanza", true);
        }

    }

    // Si todas las salas han sido superadas, se muestra la puerta final con
    // su letra correspondiente y se cambia la pista de la sala
    public void puertaFinal()
    {
        if(CompletedLevels.brujula && CompletedLevels.recoleccion && CompletedLevels.colores && CompletedLevels.adivinanza)
        {
            puertaFin.SetActive(true);

            texto.GetComponent<Transform>().position += Vector3.up * 3.5f;
            texto.GetComponent<TextMeshPro>().SetText("La puerta final ha aparecido\npero aún no estás libre de peligro\naunque la clave hayas conseguido descifrar\nen voz alta la debes pronunciar.");
            GameObject letra = GameObject.Find("LetraFinal");
            letra.GetComponent<TextMeshPro>().SetText("E");
        }
    }

    // Métodos para la configuración del reconocimiento de voz,
    // que se activará cuando la retícula apunte a la puerta final
    public void SetUpListener()
    {
        SetUpVoiceRecognizer();
        StartListening();
    }

    void SetUpVoiceRecognizer()
    {
        SpeechToText.instance.Setting(LANG_CODE);
#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif

        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
    } 

    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }
 
    // Estos métodos analizarán la cadena generada por el reconocimiento de voz
    // en busca de la clave final
    void OnPartialSpeechResult(string result)
    {
        if (!claveFinal)
        {
            string[] palabras = parser(result);
            for (int i = 0; i < palabras.Length; i++)
            {
                if (palabras[i] == finalKey)
                {
                    claveFinal = true;
                    finalSucceed();
                    break;
                }
            }

            if (claveFinal)
            {
               StopListening();
            }
        
        }
    }

    void OnFinalSpeechResult(string result)
    {
        if (!claveFinal)
        {
            string[] palabras = parser(result);
            for (int i = 0; i < palabras.Length; i++)
            {
                if (palabras[i] == finalKey)
                {
                    claveFinal = true;
                    finalSucceed();
                    break;
                }
            }

            if (claveFinal)
            {
               StopListening();
            }
        }
    }
    
    // Este método recibe la cadena de texto resultante del reconocimiento de voz
    // y la convierte en un array de palabras
    string[] parser(string result)
    {
        string[] palabras = new string[1];
        int i = 0;
        int j = 0;

        while (i < result.Length)
        {
            while(result[i] != ' ' )
            {
                palabras[j] += result[i];
                i++;

                if (i == result.Length)
                {
                    break;
                }
            }
            Array.Resize(ref palabras, palabras.Length + 1);
            i++;
            j++;
        }
        return palabras;
    }

    // Cuando se dice la clave final, todas las letras desaparecen,
    // se abre la puerta final y se cambia la pista
    void finalSucceed()
    {
        clearLetters();

        doorWingFinal= GameObject.Find("doorWingFinal");
        doorWingFinal.GetComponent<DoorScript>().finalDoor = true;

        finalButton.SetActive(true);
        texto.GetComponent<TextMeshPro>().SetText("Enhorabuena, has completado la Scape Room.\nSe te permite salir.");

    }

    // Desaparecen todas las letras
    void clearLetters()
    {
        GameObject.Find("LetraBrujula").GetComponent<TextMeshPro>().SetText("");
        GameObject.Find("LetraRecoleccion").GetComponent<TextMeshPro>().SetText("");
        GameObject.Find("LetraColores").GetComponent<TextMeshPro>().SetText("");
        GameObject.Find("LetraFinal").GetComponent<TextMeshPro>().SetText("");
        GameObject.Find("LetraAdivinanza").GetComponent<TextMeshPro>().SetText("");
    }

    // Se sale de la aplicación
    public void exit()
    {
        Application.Quit();
    }

}
