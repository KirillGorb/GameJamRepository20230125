using UnityEngine;

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
        var sum = _level > xp.MaxCountParametr / 2 ? _level - xp.MaxCountParametr / 2 : _level / (2 * xp.MaxCountParametr);

        xp.AddParametr(Mathf.Abs(sum));
        Destroy(gameObject);
    }
}