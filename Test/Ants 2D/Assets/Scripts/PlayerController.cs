using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private const string AXIS_H = "Horizontal", AXIS_V ="Vertical";
    
    public float velocidadRotacion = 100;
    public float velocidadMovimiento = 5;
    private bool camina = false;
    private bool ataca = false;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start () {
         _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
         camina = false;
         ataca= false;
        if(Mathf.Abs(Input.GetAxisRaw(AXIS_H))>0.2f){
           
            transform.Rotate(Vector3.forward * -Input.GetAxisRaw(AXIS_H) * velocidadRotacion * Time.deltaTime);
            camina = true;
        }
        if(Input.GetAxisRaw(AXIS_V)>0.2f){
            transform.position += (transform.up  * velocidadMovimiento *  Time.deltaTime);
            camina = true;
        }
        if(Input.GetAxisRaw(AXIS_V)< -0.2f){
            transform.position += (-transform.up * velocidadMovimiento/2 *  Time.deltaTime);
            camina = true;
        }

        if(Input.GetMouseButtonDown (0)){
            ataca = true;
        }

         if(!camina){
            _rigidbody.velocity = Vector2.zero;
        }
      
    }

    private void LateUpdate() {
        _animator.SetFloat(AXIS_H,Input.GetAxisRaw(AXIS_H));
        _animator.SetFloat(AXIS_V,Input.GetAxisRaw(AXIS_V));
        _animator.SetBool("camina",camina);
        _animator.SetBool("ataca",ataca);
    }
}