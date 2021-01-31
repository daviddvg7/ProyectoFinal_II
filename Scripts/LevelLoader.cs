/*  
    Interfaces Inteligentes
    Proyecto Final
        Rafael Cala González - alu0101121901
        Jorge Acevedo de León - alu0101123622
        David Valverde Gómez - alu0101100296
    
    Descripción:
        Este script se utiliza para realizar la carga entre diferentes escenas,
        mostrando el texto 'Cargando...' bajo la retícula.
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

public class LevelLoader : MonoBehaviour
{
    // Texto de progreso de la carga
    public GameObject progressText;

    void Awake()
    {
        CheckPermission();
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    // Se carga la escena indicada y mientras se ejecuta
    // este proceso se muestra un texto de carga
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        progressText = GameObject.FindWithTag("ProgressText");
        TMP_Text text = progressText.GetComponent<TMP_Text>();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone)
        {   
            text.text = "Cargando...";        

            yield return null;
        }
    }

    // Se sale de la aplicación
    public void exit()
    {
        Application.Quit();
    }

    // Se comprueban los permisos de micrófono del dispositivo
    private  void CheckPermission()
    {
#if UNITY_ANDROID
        if(!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }
}
