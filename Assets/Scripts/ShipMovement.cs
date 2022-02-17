using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipMovement : MonoBehaviour
{
    public Rigidbody rb;
    private float xInput, yInput;
    public float speed, rotate_speed;
    public float xMin, xMax, yMin, yMax;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    void Update()
    {
        if (!AnimatorIsPlaying())
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
        }

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(xInput, yInput, 0.0f);
        rb.velocity = move * speed;

        // Ship rotation
        if (Input.GetButton("Horizontal") && xInput < 0)
        {
            if (transform.rotation.eulerAngles.z < 195)
            {
                transform.Rotate(Vector3.forward * rotate_speed);
            }
        }
        else if (Input.GetButton("Horizontal") && xInput > 0)
        {
            if (transform.rotation.eulerAngles.z > 165)
            {
                transform.Rotate(Vector3.back * rotate_speed);
            }
        }

        // Boundaries
        if (rb.position.x < xMin)
        {
            transform.position = new Vector3(xMin, rb.position.y, 0.0f);
        }
        else if (rb.position.x > xMax)
        {
            transform.position = new Vector3(xMax, rb.position.y, 0.0f);
        }
        else if (rb.position.y < yMin)
        {
            transform.position = new Vector3(rb.position.x, yMin, 0.0f);
        }
        else if (rb.position.y > yMax)
        {
            transform.position = new Vector3(rb.position.x, yMax, 0.0f);
        }

        // Corner conditions for boundaries
        if (rb.position.x < xMin && rb.position.y < yMin)
        {
            transform.position = new Vector3(xMin, yMin, 0.0f);
        }
        else if (rb.position.x < xMin && rb.position.y > yMax)
        {
            transform.position = new Vector3(xMin, yMax, 0.0f);
        }
        else if (rb.position.x > xMax && rb.position.y < yMin)
        {
            transform.position = new Vector3(xMax, yMin, 0.0f);
        }
        else if (rb.position.x > xMax && rb.position.y > yMax)
        {
            transform.position = new Vector3(xMax, yMax, 0.0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (other.tag.Equals("ring"))
        {
            GameObject.Find("Game Manager").GetComponent<Game>().increaseScore();
            AudioManager.instance.playSound("CollectSound");
        }
        if (other.tag.Equals("powerup"))
        {
            AudioManager.instance.playSound("CollectSound");
        }
        if (other.tag.Equals("Enemy"))
        {
            GameObject.Find("Game Manager").GetComponent<Game>().decreaseHealth(); ;
        }
    }
}
