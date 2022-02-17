using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingAI : MonoBehaviour
{
    public Rigidbody rb;

    public Animator animator;

    private int pattern;
    
    void Start()
    {
        animator.SetInteger("pattern", pattern);
    }

    void Update()
    {


        
    }

    public void setPattern(int num)
    {
        pattern = num;
    }
}
