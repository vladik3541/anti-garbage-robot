using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] private float countFuel = 25;
    [SerializeField] private float health = 25;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out BaggageFuel baggageFuel))
        {
            
            baggageFuel.AddFuel(countFuel);
            Destroy(gameObject);
        }
    }
}
