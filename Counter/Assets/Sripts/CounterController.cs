using System;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    public event Action ButtonPressed; 
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ButtonPressed?.Invoke();
        }
    }
}