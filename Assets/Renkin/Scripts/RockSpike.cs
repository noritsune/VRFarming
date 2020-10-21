using UnityEngine;
using DG.Tweening;

public class RockSpike : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}に衝突した");
        if(!other.tag.Equals("Enemy")) return;

        Enemy enemy = other.GetComponent<Enemy>();
        if(!enemy) return;

        enemy.Kill();
    }
}
