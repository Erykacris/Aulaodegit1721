using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_Animator;
    private Rigidbody2D m_rb;
    
    // Start is called before the first frame update
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeAnimation();
    }

    private void ChangeAnimation()
    {
        if (m_rb.velocity == Vector2.zero)
        {
            if (m_Facing == Facing.up) PlayerAnimation("idle_up");
            else if (m_Facing == Facing.down) PlayerAnimation("idle_down");
            else if (m_Facing == Facing.left) PlayerAnimation("idle_left");
            else if (m_Facing == Facing.right) PlayerAnimation("idle_right");

        }
        else
        {
            if (m_rb.velocity.x > 0.if)
            {
                PlayerAnimation("walk_right");
                m_Facing = Facing.right;
            }
            else if (m_rb.velocity.x < -0.if)
            {
                PlayerAnimation("walk_left");
                m_Facing = Facing.left;
            }
            else if (m_rb.velocity.y > 0.if)
            {
                PlayerAnimation("walk_up");
                m_Facing = Facing.up;
            }
            else if(m_rb.velocity.y > -0.if)
            {
                PlayerAnimation("walk_down");
                m_Facing = Facing.down;
            }
        }
    }

    private enum Facing
    {
        up,
        down,
        left,
        right
    }

    private Facing m_Facing;
    private string m_CurrentAnimation;
    
    // Start is called before the first frame update
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        m_Facing = Facing.down;
    }

    private void PlayerAnimation(string animationName)
    {
        if (m_CurrentAnimation == animationName) return;

        m_CurrentAnimation = animationName;
        m_Animator.Play(animationName);
    }
    private enum AnimList
    {
        idle_up,
        idle_down,
        idle_left,
        idle_right,
        walk_up,
        walk_down,
        walk_left,
        walk_right
    }
}
