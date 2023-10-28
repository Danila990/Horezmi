using UnityEngine;

public abstract class NumberTypeLogick : MonoBehaviour
{
    public TypeNumber TypeNumber => _typeNumber;
    public string SignType => _signType;

    [SerializeField] private TypeNumber _typeNumber;
    [SerializeField] private string _signType;

    public abstract int SumNumber(Number number1, Number number2);

    public abstract int GenerateValue(int minRange, int maxRange);
}