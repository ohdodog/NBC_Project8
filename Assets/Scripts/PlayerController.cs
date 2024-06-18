using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Enemy enemyScript;

    [SerializeField]
    private GameObject enemy;



    private void Awake()
    {
        if(!TryGetComponent<Animator>(out animator))
        {
            Debug.Log("PlayerController.cs - Awake() - animator ���� ����");
        }
        enemyScript = enemy.GetComponent<Enemy>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            DoAttack();
        }
    }

    private void DoAttack()
    {
        animator.SetTrigger("Attack");
        enemyScript.OnHit();
    }

    IEnumerator AutoClick()
    {
        while(true)
        {
            DoAttack();
            yield return new WaitForSeconds(2f);
        }
    }

    public void StartAutoClick()
    {
        StartCoroutine(AutoClick());
        Debug.Log("�ڵ� ����");
    }

    public void StopAutoClick()
    {
        StopCoroutine(AutoClick());
        Debug.Log("�ڵ� ����");
    }
}
