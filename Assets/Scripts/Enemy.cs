using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        if(!TryGetComponent<Animator>(out animator))
        {
            Debug.Log("Enemy.cs - Awake() - animator 참조실패");
        }
    }

    public void OnHit()
    {
        animator.SetTrigger("Hit");
    }
}
