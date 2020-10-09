using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSController : MonoBehaviour
{
    public InputAction m_moveAction;

    public InputAction m_lookAction;

    public InputAction m_shootAction;

    [SerializeField] private float m_rotateSpeed;

    [SerializeField] 
    private float m_moveSpeed;
    private Vector3 m_rotation;

    [SerializeField] private GameObject m_bulletPrefab;

    [SerializeField] private Transform m_spawnPoint;

    private void Awake()
    {
        m_shootAction.performed += _ctx => {Shoot()}
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move(Vector2 _moveVector)
    {
        if (_moveVector.sqrMagnitude < 0.01) return;

        var moveSpeedPerFrame = m_moveSpeed * Time.deltaTime;
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(_moveVector.x, 0, _moveVector.y);
    }

    private void Shoot()
    {
        Instantiate(m_bulletPrefab, m_spawnPoint.position, m_spawnPoint.rotation);
    }
}
