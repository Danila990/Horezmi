using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Number : MonoBehaviour, IPointerDownHandler
{
    public TypeNumber TypeNumber => _typeNumber;
    public int ValueNumber => _valueNumber;

    [SerializeField] private Image _backgroundNumberUI;
    [SerializeField] private TMP_Text _textValue;
    [SerializeField] private NumberSelect _numberSelecter;

    private TypeNumber _typeNumber = TypeNumber.Default;
    private int _valueNumber = 0;

    private void Awake() => gameObject.SetActive(false);

    private void OnEnable() => DeactivateLight();

    public void SetValue(int value) => _valueNumber = value;

    public void SetType(TypeNumber typeNumber, string signType)
    {
        _typeNumber = typeNumber;
        OutputNumber(signType);
    }

    public void OnPointerDown(PointerEventData eventData) => _numberSelecter.NumberUIClick(this);

    public void ActivateLight() => _backgroundNumberUI.enabled = true;

    public void DeactivateLight() => _backgroundNumberUI.enabled = false;

    private void OutputNumber(string signType) => _textValue.text = signType + ValueNumber.ToString();
}