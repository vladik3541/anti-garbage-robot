using System;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    public Action OnSelectItemEvent;

    [SerializeField] private GameObject hands;
    [SerializeField] private Transform pointCollected;
    private GameObject item;
    private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        //
        playerInput.OnSelect += RemoveCollected;
    }
    private void OnDisable()
    {
        //
        playerInput.OnSelect -= RemoveCollected;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (item != null) return;
        if(other.CompareTag("Resource"))
        {
            OnSelectItemEvent?.Invoke();
            hands.SetActive(true);
            item = other.gameObject;

            item.transform.parent = pointCollected;
            item.GetComponent<Collider>().enabled = false;
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.position = pointCollected.transform.position;
            
        }
    }
    private void RemoveCollected()
    {
        if (item == null) return;
        hands.SetActive(false);

        item.transform.parent = null;
        item.GetComponent<Collider>().enabled = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item = null;
        
    }
}
