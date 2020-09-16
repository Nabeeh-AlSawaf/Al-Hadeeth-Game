using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PickableChecker : MonoBehaviour
{
    public ParticleSystem pickupEffect;
    public GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            pickupEffect.gameObject.SetActive(true);
            float duration = pickupEffect.duration;
            StartCoroutine(DeactivateAfrer(duration));
        }
    }
    

    IEnumerator DeactivateAfrer(float duration)
    {
        star.SetActive(false);
        yield return new WaitForSeconds(duration+2);
        gameObject.SetActive(false);

    }
}
