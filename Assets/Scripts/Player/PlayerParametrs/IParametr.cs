using System;
using UnityEngine;

[Serializable]
public class IParametr
{
    private event Action<string> _changeParametr;

    [SerializeField] private float _parametrMaxCount;
    [SerializeField] private protected float _parametr;
    [SerializeField] private protected DataParametr _data;

    public float MaxCountParametr { get; set; }
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
        if (_parametr > MaxCountParametr)
            _parametr = MaxCountParametr;

        _changeParametr?.Invoke($"{_parametr}/{MaxCountParametr}");
    }

    public virtual void DownParametr(float s)
    {
        if (_parametr >= 0)
            _parametr -= s;

        _changeParametr?.Invoke($"{_parametr}/{MaxCountParametr}");
    }

    public virtual void ShopDopParametr(float s)
    {
        MaxCountParametr += s;
        _changeParametr?.Invoke($"{_parametr}/{MaxCountParametr}");
    }
}

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
        base.DownParametr(s);
        if (_parametr <= 0)
            _death?.Invoke();
    }

}

public class Experience : IParametr
{
    public override void ShopDopParametr(float s) { }
}

[Serializable]
public struct DataParametr
{
    public float TimeRegen;
    public float OneRegenCount;
}