using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Velocidad de movimiento del enemigo")]
    public float speed = 1;
    private Rigidbody2D _rigidbody;
    private bool isMoving;
    [Tooltip("Tiempo que tarda el enemigo entre pasos sucesivos")]
    public float timeBetweenSteps;
    private float timeBetweenStepsCounter;

    public Vector2 directionToMove;

    [Tooltip("Tiempo que tarda un enemigo en dar un paso")]
    public float timeToMakeStep;
    private float timeToMakeStepCounter;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        timeBetweenStepsCounter = timeBetweenSteps;
        timeToMakeStepCounter = timeToMakeStep;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            _rigidbody.velocity = directionToMove * speed; 
            //Cuando me quedo sin tiempo de movimiento
            //paramos al enemigo
            if (timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                _rigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if (timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                directionToMove = new Vector2(Random.Range(-1,2), Random.Range(-1,2 ));
            }

        }
    }
}
