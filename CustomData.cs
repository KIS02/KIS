using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomData : MonoBehaviour
{

    public Sprite[] image;
    public Object[] dummy;

    public static CustomData instance;

    void Start()
    {
        instance = GetComponent<CustomData>();
    }

}