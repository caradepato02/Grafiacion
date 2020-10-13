using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    public Animator transition;
    public float velocidadRotacion = 100;
    public float velocidadMovimiento = 2;
    private bool seMueve;
    // Start is called before the first frame update
    void Start () {
 
    }

    // Update is called once per frame
    void Update () {
        
        if (Input.GetKey (KeyCode.A)) {
            transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
            transition.SetTrigger("Girar");
        }

        if (Input.GetKey (KeyCode.D)) {
            transform.Rotate(-Vector3.forward * velocidadRotacion * Time.deltaTime);
            transition.SetTrigger("Girar");
        }

        if (Input.GetKey (KeyCode.W)) {
            transform.position += (transform.up * velocidadMovimiento *  Time.deltaTime);
            transition.SetTrigger("Moverse");
        }
        if (Input.GetKey (KeyCode.S)) {
            transform.position += (-transform.up * (velocidadMovimiento/2) * Time.deltaTime);
            transition.SetTrigger("Atras");
        }
        if(!Input.anyKey){
            transition.SetTrigger("Quieto");
        }
    }
}