using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private float addHealth;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.AddHealth(addHealth);
            Destroy(gameObject);
        }
    }
}
