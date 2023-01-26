using System.Collections;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private PlayerParametrsSaver _s;

    private DataParametr _dataParametrHealth;
    private DataParametr _dataParametrEndurance;

    private bool isAttack => Input.GetMouseButton(0);

    private void Start()
    {
        _dataParametrHealth = _s.Health.DataParametr;
        _dataParametrEndurance = _s.Endurance.DataParametr;

        StartCoroutine(RegenHelth(_dataParametrHealth, _s.Health));
        StartCoroutine(RegenHelth(_dataParametrEndurance, _s.Endurance));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyData enemy))
        {
            StartCoroutine(Damage(enemy));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out EnemyData enemy))
        {
            StopCoroutine(Damage(enemy));
        }
    }

    private IEnumerator Damage(EnemyData enemy)
    {
        while (true)
        {
            yield return new WaitForSeconds(_s.Strong.DataParametr.TimeRegen);

            if (isAttack)
                enemy.DamageOnEnemy(_s.Strong, _s.Experience);
            else
                enemy.Attack(_s.Health);
        }
    }

    private IEnumerator RegenHelth(DataParametr data, IParametr parametr)
    {
        while (true)
        {
            yield return new WaitForSeconds(data.TimeRegen);
            parametr.AddParametr(data.OneRegenCount);
        }
    }
}