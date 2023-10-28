using UnityEngine;

[System.Serializable]
public struct ChanceType
{
    public float Chance => _chance;
    public TypeNumber TypeNumber => _typeNumber;

    [SerializeField] private TypeNumber _typeNumber;
    [SerializeField,Range(1,50)] private float _chance;
}