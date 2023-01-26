using UnityEngine;
using System;
using System.Collections;

[CreateAssetMenu()]
public class ss : ScriptableObject
{
    [SerializeField] private IParametr _endurance;
    [SerializeField] private IParametr _strong;
    [SerializeField] private Health _health;
    [SerializeField] private Experience _experience;

    public IParametr Strong => _strong;
    public IParametr Endurance => _endurance;
    public Health Health => _health;
    public Experience Experience => _experience;
}

public class PlayerData : MonoBehaviour
{
    [SerializeField] private ss _s;

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
            if (isAttack)
                enemy.DamageOnEnemy(_s.Strong, _s.Experience);
            else
                enemy.Attack(_s.Health);
        }
    }

    private IEnumerator RegenHelth(DataParametr data, IParametr parametr)
    {
        yield return new WaitForSeconds(data.TimeRegen);
        parametr.AddParametr(data.OneRegenCount);
    }
}

public class EnemyData : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private float _damage;
    [SerializeField] private float _level;

    private bool isCreate = false;

    public void Attack(Health hp)
    {
        hp.DownParametr(_damage);
    }

    public void DamageOnEnemy(IParametr strong, Experience xp)
    {
        if (!isCreate)
        {
            isCreate = true;
            _health._Init_(() => DeathEnemy(xp));
        }

        _health.DownParametr(strong.CountParametr);
    }

    private void DeathEnemy(Experience xp)
    {
        xp.AddParametr(_level - xp.CountParametr / 2);
        Destroy(gameObject);
    }
}