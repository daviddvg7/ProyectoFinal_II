/*  
    Interfaces Inteligentes
    Proyecto Final
        Rafael Cala González - alu0101121901
        Jorge Acevedo de León - alu0101123622
        David Valverde Gómez - alu0101100296
    
    Descripción:
        Este script está destinado a la activación de la animación
        de la estantería en la sala de recolección de libros
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boofShelf : MonoBehaviour
{
    // Se instancian los elementos para el audio
    public AudioSource audioSource;
    public AudioClip bookShelfOneClip;

    // Este booleano se activará cuando se quiera ejecutar la animación
    public static bool slide = false;

    // Se instancia el Animator
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();        
    }

    // Se comprueba cuándo debe ejecutarse la animación
    void Update()
    {
        if (slide == true)
            slideBookShelf();
    }

    public void slideBookShelf()
    {
        _animator.SetBool("slide", true);
        audioSource.PlayOneShot(bookShelfOneClip, 0.04f);
    }
}
