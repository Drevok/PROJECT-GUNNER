using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public void Setup(Vector3 shootDir)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        float moveSpeed = 100f;
        rigidbody.AddForce(shootDir * moveSpeed, ForceMode.Impulse);
    }
}
