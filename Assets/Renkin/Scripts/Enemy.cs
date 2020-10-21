using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Transform _playerTrans;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private bool _isDead;
    private EnemyResponer _enemyResponer;

    void Start()
    {
        _playerTrans = GameObject.Find("CenterEyeAnchor").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("MoveSpeed", _navMeshAgent.speed * 5);
        _isDead = false;
        _enemyResponer = FindObjectOfType<EnemyResponer>();
    }

    void Update()
    {
        _navMeshAgent.destination = _playerTrans.position;
    }

    public void Kill()
    {
        if(_isDead) return;
        _isDead = true;

        _animator.SetTrigger("Dead");

        _navMeshAgent.isStopped = true;
    }

    public void OnDestroyMySelf()
    {
        gameObject.SetActive(false);
        _enemyResponer.Respone(gameObject);
    }
}
