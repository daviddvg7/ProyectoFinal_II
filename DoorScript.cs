/*  
    Interfaces Inteligentes
    Proyecto Final
        Rafael Cala González - alu0101121901
        Jorge Acevedo de León - alu0101123622
        David Valverde Gómez - alu0101100296
    
    Descripción:
        En esta clase se tratan las animaciones de las puertas, así como sus
        sonidos.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Se instancia el animator y los recursos necesarios para el audio
    private Animator _animator;
    public AudioClip openDoorClip;
    public AudioClip secondDoorClip;
    public AudioClip finalDoorClip;
    public AudioSource audioSource;

    // Este flag nos indica cuándo la sala relativa a una puerta
    // ha sido completada, por lo que la puerta no debe volver a abrirse
    public  bool completed = false;

    // Este flag indica cuándo se debe abrir la puerta final
    public bool finalDoor = false;

    // Este contador ayuda a que la puerta final solo se abra una vez
    private int timesOpened = 0;

    void Start()
    {
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (finalDoor == true)
        {
            if (timesOpened == 0)
            {
                OpenDoor();
                timesOpened++;
            }
        }        
    }

    // Se activa la animación de apertura de la puerta, así como su correspondiente sonido
    public void OpenDoor()
    {
        if(!completed)
        {
            _animator.SetBool("open", true);
            audioSource.PlayOneShot(openDoorClip, 0.07f);
        }

        if (finalDoor)
        {
            _animator.SetBool("open", true);
            audioSource.PlayOneShot(finalDoorClip, 1.3f);
        }
    }

    // Se activa la animación de cerrado de la puerta
    public void CloseDoor()
    {
        StartCoroutine(Close());

    }

    // Se utiliza una función IEnumerator para poder utilizar la función
    // WaitForSeconds y así ajustar el sonido con la animación
    public IEnumerator Close()
    {
        _animator.SetBool("open", false);
        float time = 0.8f;
        yield return new WaitForSeconds(time);
        audioSource.PlayOneShot(secondDoorClip, 0.07f);

    }
}
