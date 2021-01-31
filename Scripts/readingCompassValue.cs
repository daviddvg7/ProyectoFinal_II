/*  
    Interfaces Inteligentes
    Proyecto Final
        Rafael Cala González - alu0101121901
        Jorge Acevedo de León - alu0101123622
        David Valverde Gómez - alu0101100296
    
    Descripción:
        En este script se describen métodos para la utilización de la
        brújula en la sala de las estrellas.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class readingCompassValue : MonoBehaviour
{
    // Texto para mostrar la dirección a la que se apunta
    public TextMeshProUGUI compassValue;

    // Cámara principal de la escena
    public Camera mainCamera;

    // Se desactiva la cámara un instante para poder calibrar
    // bien la brújula
    IEnumerator Start()
    {
        mainCamera.enabled = false;
        Input.location.Start();
        yield return new WaitForSeconds(1);
        Input.compass.enabled = true;
        transform.Rotate(0, Input.compass.trueHeading, 0);
        mainCamera.enabled = true; 
    }

    // Se muestra la dirección a la que se mira en función del trueHeading
    void Update()
    {
        Input.compass.enabled = true;
        if (Input.compass.trueHeading < 45 || Input.compass.trueHeading > 315)
        {
            compassValue.text = "NORTE";
        }
        else if (Input.compass.trueHeading >= 45 && Input.compass.trueHeading < 135)
        {
            compassValue.text = "ESTE";
        }
        else if (Input.compass.trueHeading >= 135 && Input.compass.trueHeading < 225)
        {
            compassValue.text = "SUR";
        }
        else
        {
            compassValue.text = "OESTE";
        }
    }
}
