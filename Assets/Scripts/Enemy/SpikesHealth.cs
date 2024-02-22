using UnityEngine;
using UnityEngine.AI;

public class SpikesHealth : Health
{
    [SerializeField] private GameObject effectBlood;
    protected Camera cam;
    protected override void Start()
    {
        base.Start();
        cam = Camera.main;
    }
    protected virtual void LateUpdate()
    {
        UpdateUI();
    }
    protected override void Die()
    {
        base.Die();
        //
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Spike>().enabled = false;
        sliderHp.enabled = false;
        //
        GameObject effect = Instantiate(effectBlood, transform.position, Quaternion.identity);
        Destroy(effect, 2);
        //
        Destroy(gameObject);
    }
    protected override void UpdateUI()
    {
        base.UpdateUI();
        sliderHp.transform.rotation = cam.transform.rotation;
    }
}
