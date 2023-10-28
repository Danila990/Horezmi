using System.Collections.Generic;
using UnityEngine;

public class NumberGenerator : MonoBehaviour
{
    [SerializeField] private List<Number> _numberList;
    [SerializeField] private NumberTypeLogick[] _typeLogickArray;

    private ChanceType[] _availableOdds;
    private DefaultTypeLogick _defaultTypeLogick;
    private LevelSetting _levelSetting;
    private LevelManager _levelManager;
    private int _mixRangeNumber;
    private int _maxRangeNumber;
    private void OnDestroy()
    {
        _levelSetting.OnChangeLevelSetting -= CgangeSetting;
        _levelManager.OnStartGame += StartNumbers;
    }

    public void Init(LevelSetting levelSetting, LevelManager levelManager)
    {
        _levelSetting = levelSetting;
        _levelManager = levelManager;
        _defaultTypeLogick = GetComponent<DefaultTypeLogick>();

        CgangeSetting(_levelSetting.GetCurrentSetting());

        _levelSetting.OnChangeLevelSetting += CgangeSetting;
        _levelManager.OnStartGame += StartNumbers;
    }

    public void OverwriteNumbers(List<Number> numbers)
    {
        foreach (Number number in numbers)
        {
            number.SetValue(0);
            number.SetType(TypeNumber.Default,"");
            number.gameObject.SetActive(false);
        }
            

        GenerateNumbers(numbers);
    }

    public bool CheckSelectResult(List<Number> numbers)
    {
        NumberTypeLogick typeLogick = FindNumberLogick(numbers[1].TypeNumber);

        return typeLogick.SumNumber(numbers[0], numbers[1]) == numbers[2].ValueNumber;
    }

    private void GenerateNumbers(List<Number> numbers)
    {
        foreach (Number number in numbers)
        {
            int countLessMidleNumbers = CountLessMiddle();
            if (countLessMidleNumbers <= _numberList.Count - 4 || (countLessMidleNumbers >= 3 && Random.Range(0,100) >= 75))
                GenerateNumberData(number);
            else GenerateResultNumberData(number);

            number.gameObject.SetActive(true);
        }
    }

    private void GenerateNumberData(Number number)
    {
        foreach (ChanceType changeType in _availableOdds)
        {
            if (Random.Range(0, 101) <= changeType.Chance)
            {
                NumberTypeLogick typeLogick = FindNumberLogick(changeType.TypeNumber);

                number.SetValue(typeLogick.GenerateValue(_mixRangeNumber, _maxRangeNumber));
                number.SetType(typeLogick.TypeNumber, typeLogick.SignType);

                return;
            }
        }

        number.SetValue(_defaultTypeLogick.GenerateValue(_mixRangeNumber, _maxRangeNumber));
        number.SetType(_defaultTypeLogick.TypeNumber, _defaultTypeLogick.SignType);
    }

    private void GenerateResultNumberData(Number number)
    {
        Number firstNumber = GetRandomNumber(true);
        Number secondNumber = GetRandomNumber(firstNumber);

        number.SetValue(_defaultTypeLogick.SumNumber(firstNumber, secondNumber));
        number.SetType(_defaultTypeLogick.TypeNumber, _defaultTypeLogick.SignType);

        //Debug.Log($"first: {firstNumber.ValueNumber}, second: {secondNumber.ValueNumber}, result:{number.ValueNumber}");
    }

    private Number GetRandomNumber(bool needDefaultType = false, Number skipNumber = null)
    {
        Number randomNumber = null;
        int _eror = 0;

        while (true)
        {
            randomNumber = _numberList[Random.Range(0, _numberList.Count)];
            _eror++;
            if (_eror >= 1000)
            {
                Debug.LogError("randomEror");
                break;
            }
                
            if (skipNumber == randomNumber || randomNumber.gameObject.activeSelf == false 
                || randomNumber.ValueNumber > _maxRangeNumber / 2)
                continue;

            if (needDefaultType)
                if (randomNumber.TypeNumber != TypeNumber.Default)
                    continue;

            break;
        }

        return randomNumber;
    }

    private NumberTypeLogick FindNumberLogick(TypeNumber typeNumber)
    {
        foreach (NumberTypeLogick typeLogick in _typeLogickArray)
        {
            if (typeLogick.TypeNumber == typeNumber)
                return typeLogick;
        }

        Debug.LogError($"No number Logick: {typeNumber}");
        return null;
    }

    private int CountLessMiddle()
    {
        int count = 0;

        foreach (Number number in _numberList)
            if (number.ValueNumber <= _maxRangeNumber / 2 && number.ValueNumber != 0)
                count++;

        return count;
    }

    private void CgangeSetting(SettingData settingData)
    {
        _availableOdds = settingData.ChanceType;
        _mixRangeNumber = settingData.MixRangeNumber;
        _maxRangeNumber = settingData.MaxRangeNumber;
    }

    private void StartNumbers()
    {
        OverwriteNumbers(_numberList);
    }
}