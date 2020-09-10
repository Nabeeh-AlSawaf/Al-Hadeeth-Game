using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class V_LevelActivation : MonoBehaviour
{

    Animator animator;
    bool activate=false;
    public bool LastLevel = false;
    private GameObject canvas = null;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        if (LastLevel) animator.SetTrigger("LastLevel");

        if (SceneManager.GetActiveScene().name.Equals("Start"))
            canvas = GameObject.FindGameObjectWithTag("Canvas");
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
            if(canvas != null)
            {
                // Enable selection menu in the start scene TO BE IMPROVED LATER
                canvas.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            animator.SetTrigger("DeActivate");
            activate = false;
            if (canvas != null)
            {
                // Disable selection menu in the start scene TO BE IMPROVED LATER
                canvas.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    
}
