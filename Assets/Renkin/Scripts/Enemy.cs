using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTrans;
    [SerializeField]
    private EnemyResponer _enemyResponer;
    [SerializeField]
    private TextMeshPro _scoreNum;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private bool _isDead;
    private float _attackSpan = 2;
    private bool _canAttack = true;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("MoveSpeed", _navMeshAgent.speed * 5);
        _isDead = false;
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
        _scoreNum.text = (int.Parse(_scoreNum.text) + 1).ToString();
        gameObject.SetActive(false);
        _enemyResponer.Respone(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Player") || _isDead || !_canAttack) return;
        
        Player player = other.GetComponent<Player>();
        if(!player) return;

        player.OnGetDamege();
        _animator.SetTrigger("Attack");
        _canAttack = false;
    }

    public IEnumerator CoAttackCoolTime()
    {
        yield return new WaitForSeconds(_attackSpan);

        _canAttack = true;
    }
}
