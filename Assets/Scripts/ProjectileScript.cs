using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private bool isLaunched = false;
    
    public void Awake()
    {
        
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        float moveSpeed = 15f;
        rigidbody.AddForce(Vector3.forward * moveSpeed, ForceMode.Impulse);
    }
    

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    IEnumerator WaitDestruction()
    {
        yield return new  WaitForSeconds(0.5f);
        isLaunched = true;
    }
}
