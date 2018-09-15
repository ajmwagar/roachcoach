using UnityEngine;
using System;

public class BasicCont : MonoBehaviour
{

    private readonly Rigidbody rb;

    [SerializeField]
    private float speed = 150.0f;

    [SerializeField]
    private float rotateSpeed = 3.0f;

    private const float MAX_VELOCITY = 70;

    private event Action OnHit = delegate { };

    void Start()
    {

    }

    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * rotateSpeed;

        transform.Rotate(0, moveHorizontal, 0);
        transform.Translate(0, 0, moveVertical);
    }

    public void OnCollisionEnter(Collision collision)
    {

        float velocity = collision.rigidbody.velocity.magnitude;

        if (velocity >= MAX_VELOCITY)
        {

            //Stop mouse input
            Debug.Log("The velocity was greater than max!");
        }
        else
        {
            Debug.Log("It is colling but not greater than max. Velocity: " + velocity);
        }
    }
}
