using UnityEngine;
using System.Collections;

public class Stunned : MonoBehaviour
{
    [SerializeField] float stunDuration;
    private Enemy _enemyAttack;
    private EnemyPatrol _enemyPatrol;
    private EnemyChase _enemyChase;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //getting enemy movement & combat scripts
        _enemyAttack = GetComponentInChildren<Enemy>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _enemyChase = GetComponentInChildren<EnemyChase>();
    }

    public void StartStunCoroutine()
    {
        StartCoroutine(StunCoroutine());
    }

    private IEnumerator StunCoroutine()
    {
        _enemyAttack.enabled = false;
        _enemyChase.enabled = false;
        _enemyPatrol.enabled = false;
        Debug.Log("Stunned");
        
        yield return new WaitForSeconds(stunDuration);
        
        _enemyAttack.enabled = true;
        _enemyChase.enabled = true;
        _enemyPatrol.enabled = true;
        Debug.Log("Not stunned");
    }
}
