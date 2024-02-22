using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDetect : MonoBehaviour
{
    public static Action<GameObject> OnSpawn;
    public static Action<GameObject> OnDestroy;
    

    private void OnEnable()
    {
        OnSpawn?.Invoke(this.gameObject);
    }
    private void OnDisable()
    {
        OnDestroy?.Invoke(this.gameObject);    
    }
}
