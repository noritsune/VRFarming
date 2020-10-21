using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform _playerTrans;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private bool _isDead = false;

    void Start()
    {
        _playerTrans = GameObject.Find("CenterEyeAnchor").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("MoveSpeed", _navMeshAgent.speed * 5);
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
        Destroy(gameObject);
    }
}
