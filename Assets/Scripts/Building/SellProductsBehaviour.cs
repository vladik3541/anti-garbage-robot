using UnityEngine;
using DG.Tweening;

public class SellProductsBehaviour : MonoBehaviour
{
    [SerializeField] private int countToProgres = 5;
    [SerializeField] private Transform StartPosition;
    [SerializeField] private Transform EndPosition;
    [SerializeField] private float speed;
    [SerializeField] private float timeToDestroy = 5;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Resource"))
        {
            ProgressManager.instans.AddProgres(countToProgres);
            collision.gameObject.transform.position = StartPosition.position;
            MoveResource(collision.gameObject);
        }
    }

    private void MoveResource(GameObject res)
    {
        res.transform.DOMove(EndPosition.position, speed);
        Destroy(res.gameObject, timeToDestroy);
    }

}
