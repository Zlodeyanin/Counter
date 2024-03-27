using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private CounterController _controller;

    private Coroutine _counter;
    private float _value = 0;
    private bool _isWork = false;

    public event Action<float> ValueChanged;

    private void OnEnable()
    {
        _controller.ButtonPressed += ChangeStatus;
    }

    private void OnDisable()
    {
        _controller.ButtonPressed -= ChangeStatus;
    }

    private void ChangeStatus()
    {
        if (_isWork == false)
        {
            _isWork = true;
            _counter = StartCoroutine(StartCounter());
        }
        else
        {
            StopCoroutine(_counter);
            _isWork = false;
        }
    }

    private IEnumerator StartCounter()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return delay;
            _value++;
            ValueChanged?.Invoke(_value);
        }
    }
}