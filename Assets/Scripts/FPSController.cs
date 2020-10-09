using System;
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
        m_shootAction.performed += _context => { Shoot(); };
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        m_lookAction.Enable();
        m_moveAction.Enable();
        m_shootAction.Enable();
    }

    private void OnDisable()
    {
        m_lookAction.Disable();
        m_moveAction.Disable();
        m_shootAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        var lookVector = m_lookAction.ReadValue<Vector2>();
        var moveVector = m_moveAction.ReadValue<Vector2>();

        Look(lookVector);
        Move(moveVector);
    }

    private void Move(Vector2 _moveVector)
    {
        if (_moveVector.sqrMagnitude < 0.01) return;

        var moveSpeedPerFrame = m_moveSpeed * Time.deltaTime;
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(_moveVector.x, 0, _moveVector.y);
    }

    private void Look(Vector2 _lookVector)
    {
        if (_rotate.sqrMagnitude < 0.01) return;

        var rotateSpeedPerFrame = m_rotateSpeed;
    }
    
    private void Shoot()
    {
        Instantiate(m_bulletPrefab, m_spawnPoint.position, m_spawnPoint.rotation);
    }
}
