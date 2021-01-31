/*  
    Interfaces Inteligentes
    Proyecto Final
        Rafael Cala González - alu0101121901
        Jorge Acevedo de León - alu0101123622
        David Valverde Gómez - alu0101100296
    
    Descripción:
        Se utilizará este script como controlador de la sala de la adivinanza,
        se instancian diferentes métodos a utilizar, como el reconocimiento de voz
        o las llamadas a las diferentes animaciones
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

public class GameControllerSalaAdivinanza : MonoBehaviour
{

    // Idioma para el reconocimiento de voz
    const string LANG_CODE = "es-ES";

    // Solución a la adivinanza
    private string solution = "luna";

    // Se instancian los diferentes objetos a los que se activarán animaciones
    private GameObject puertaSalida;
    private GameObject ojo;
    private GameObject luna;

    // Se indica si se ha resuelto la adivinanza
    private bool solved = false;

    // Elementos de audio
    public AudioSource audioSource;
    public AudioClip finalClip;

    // Elementos de texto para la pista y la adivinanza
    private GameObject pista;
    private GameObject adivinanza;


    void Awake()
    {
        // La puerta de salida comenzará desactivada, así como la luna
        puertaSalida = GameObject.Find("PuertaSalida");
        puertaSalida.SetActive(false);
        luna = GameObject.Find("Luna");
        luna.SetActive(false);

        // Se cargan el resto de objetos
        ojo = GameObject.Find("Eye");
        audioSource = GetComponent<AudioSource>();   
        pista = GameObject.Find("PistaJuego");
        adivinanza = GameObject.Find("Adivinanza");

    }

    // Los siguientes métodos sirven para configurar y
    // ejecutar el reconocimiento de voz 
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
 
    // Estos métodos reciben el resultado del reconocimiento de voz 
    // y comprueban palabra por palabra si coincide con la solución
    void OnPartialSpeechResult(string result)
    {
        if (!solved)
        {
            string[] palabras = parser(result);
            for (int i = 0; i < palabras.Length; i++)
            {
                if (palabras[i] == solution)
                {
                    solved = true;
                    solve();
                    break;
                }
            }

            if (solved)
            {
               StopListening();
            }
        
        }
    }

    void OnFinalSpeechResult(string result)
    {
        if (!solved)
        {
            string[] palabras = parser(result);
            for (int i = 0; i < palabras.Length; i++)
            {
                if (palabras[i] == solution)
                {
                    solved = true;
                    solve();
                    break;
                }
            }

            if (solved)
            {
               StopListening();
            }
        }
    }

    // Método que recibe la cadena con el resultado del
    // reconocimiento de voz y la tokeniza palabra por palabra
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

    // Método llamado cuándo se ha resuelto la adinanza
    void solve()
    {
        // Se marca la sala como completada
        CompletedLevels.adivinanza = true;

        // Se activan las diferentes animaciones y la puerta de salida
        ojo.GetComponent<Animator>().SetBool("destroy", true);
        puertaSalida.SetActive(true);
        luna.SetActive(true);
        luna.GetComponent<Animator>().SetBool("destroy", true);
        audioSource.PlayOneShot(finalClip, 0.3f);

        // Se cambian los textos iniciales
        pista.GetComponent<TextMeshPro>().SetText("");
        adivinanza.GetComponent<TextMeshPro>().SetText("Respuesta Correcta.\nContinúa tu aventura.");
    }
}