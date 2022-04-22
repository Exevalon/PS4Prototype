using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionOutline : MonoBehaviour
{
    public Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
}
