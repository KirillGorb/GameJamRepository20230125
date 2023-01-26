using UnityEngine;

[CreateAssetMenu()]
public class PlayerParametrsSaver : ScriptableObject
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