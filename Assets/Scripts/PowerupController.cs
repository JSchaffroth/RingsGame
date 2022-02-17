using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public Animator animator;

    private int pattern;

    public Rigidbody rb;
    private float initx;
    private float inity;
    private float initz;

    // Start is called before the first frame update
    void Start()
    {
        initx = transform.position.x;
        inity = transform.position.y;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.TransformVector(-initx, -inity, -initz) * 500);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GameObject.Find("Game Manager").GetComponent<Game>().insertItem(this.gameObject);
        }
    }
}
