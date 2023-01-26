using System;
using UnityEngine;

[Serializable]
public class IParametr
{
    private event Action<string> _changeParametr;

    [SerializeField] private protected float _parametrMaxCount;
    [SerializeField] private protected float _parametr;
    [SerializeField] private protected DataParametr _data;

    public float MaxCountParametr { get => _parametrMaxCount; set => _parametrMaxCount = value; }
    public float CountParametr => _parametr;

    public DataParametr DataParametr => _data;

    public virtual void _Init_(Action<string> change)
    {
        MaxCountParametr = _parametrMaxCount;
        _changeParametr += change;
    }

    public virtual void AddParametr(float s)
    {
        _parametr += s;
        if (_parametr > _parametrMaxCount)
            _parametr = _parametrMaxCount;

        _changeParametr?.Invoke($"{_parametr}/{_parametrMaxCount}");
    }

    public virtual void DownParametr(float s)
    {
        if (_parametr >= 0)
            _parametr -= s;

        _changeParametr?.Invoke($"{_parametr}/{_parametrMaxCount}");
    }

    public virtual void ShopDopParametr(float s)
    {
        _parametrMaxCount += s;
        _changeParametr?.Invoke($"{_parametr}/{_parametrMaxCount}");
    }
}

[Serializable]
public class Health : IParametr
{
    private event Action _death;

    public void _Init_(Action death, Action<string> change)
    {
        base._Init_(change);
        _death += death;
    }
    public void _Init_(Action death)
    {
        _death += death;
    }

    public override void DownParametr(float s)
    {
        if (_parametr <= 0) return;

        base.DownParametr(s);

        if (_parametr <= 0)
            _death?.Invoke();
    }

}

[Serializable]
public class Experience : IParametr
{
    public override void ShopDopParametr(float s) { }
    public override void AddParametr(float s)
    {
        _parametrMaxCount += s;
        base.AddParametr(s);
    }
}

[Serializable]
public struct DataParametr
{
    public float TimeRegen;
    public float OneRegenCount;
}