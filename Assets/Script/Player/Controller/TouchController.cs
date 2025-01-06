using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    private FixedTouchField _fixedTouchField;
    private Movement _movementCamera;

    void Start()
    { 
        _fixedTouchField = GameObject.FindGameObjectWithTag("Android").GetComponentInChildren<FixedTouchField>();
        _movementCamera = GetComponent<Movement>();
    }

    
    void Update()
    {
        _movementCamera._lookAxis = _fixedTouchField.TouchDist;
    }
}
