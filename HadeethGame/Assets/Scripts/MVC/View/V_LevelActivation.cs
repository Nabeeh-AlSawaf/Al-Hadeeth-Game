using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_LevelActivation : MonoBehaviour
{

    Animator animator;
    bool activate=false;
    public bool LastLevel = false;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (LastLevel) animator.SetTrigger("LastLevel");

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (!activate)
            {
                animator.SetTrigger("Activate");
                activate = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            animator.SetTrigger("DeActivate");
            activate = false;
        }
    }
    
}
