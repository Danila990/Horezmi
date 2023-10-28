using UnityEngine;

public class DefaultTypeLogick : NumberTypeLogick
{
    public override int SumNumber(Number number1, Number number2)
    {
        return number1.ValueNumber + number2.ValueNumber;
    }

    public override int GenerateValue(int minRange, int maxRange)
    {
        return Random.Range(minRange, (maxRange + 1) / 2) ;
    }
}
