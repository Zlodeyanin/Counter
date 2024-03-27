using TMPro;
using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ChangeValue;
    }

    private void ChangeValue(float value)
    {
        _value.text = value.ToString();
    }
}