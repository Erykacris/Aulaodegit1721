using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    private InputActions m_InputMap;
    private Vector2 m_Direction;
    private Rigidbody2D m_rb;
    [SerializeField] private float speed;
    private enum Facing{
        up,
        down,
        left,
        right
    }

    private Facing m_Facing;

    // Start is called before the first frame update
    void Awake()
    {
        m_InputMap = new InputActions();
        m_rb = GetComponent<Rigidbody2D>();
        m_Facing = Facing.down;

        m_InputMap.Player.Moviment.performed += ctx => m_Direction = ctx.ReadValue<Vector2>();
        m_InputMap.Player.Moviment.canceled += ctx => m_Direction = Vector2.zero;
    }

    private void OnEnable() => m_InputMap.Enable();
    private void OnDisable() => m_InputMap.Disable();

    // Update is called once per frame
    void fixedUpdate()
    {
        m_rb.velocity = m_Direction * speed; 
    }
}