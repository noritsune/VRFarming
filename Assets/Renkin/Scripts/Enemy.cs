using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform _playerTrans;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

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
}
