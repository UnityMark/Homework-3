using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Transform _wind;
    private FieldOfViewCondition _fieldOfViewCondition;

    private void Awake()
    {
        _fieldOfViewCondition = new FieldOfViewCondition(this.transform, 90f);
    }

    private void Update()
    {
        if (_fieldOfViewCondition.IsCompleteFor(_wind))
        {
            Debug.Log(true);
        }
        else
        {
            Debug.Log(false);
        }
    }
}
