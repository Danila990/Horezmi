using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class Number : MonoBehaviour, IPointerDownHandler
{
    public TypeNumber TypeNumber => _typeNumber;
    public int ValueNumber => _valueNumber;

    [SerializeField] private TMP_Text _textValue;

    private Image _backgroundImage;
    private NumberSelect _numberSelecter;
    private TypeNumber _typeNumber = TypeNumber.Default;
    private int _valueNumber = 0;

    [Inject]
    private void Construct(NumberSelect numberSelect)
    {
        _numberSelecter = numberSelect;
    }

    private void Awake()
    {
        _backgroundImage = GetComponent<Image>();
        gameObject.SetActive(false);
    }

    private void OnEnable() => DeactivateLight();

    public void SetValue(int value) => _valueNumber = value;

    public void SetType(TypeNumber typeNumber, string signType)
    {
        _typeNumber = typeNumber;
        OutputNumber(signType);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _numberSelecter.NumberUIClick(this);
    }

    public void ActivateLight() => _backgroundImage.enabled = true;

    public void DeactivateLight() => _backgroundImage.enabled = false;

    private void OutputNumber(string signType)
    {
        _textValue.text = signType + ValueNumber.ToString();
    }
}