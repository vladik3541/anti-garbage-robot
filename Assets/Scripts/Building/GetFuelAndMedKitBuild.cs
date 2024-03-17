using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetFuelAndMedKitBuild : MonoBehaviour
{
    [SerializeField] private int costFuel, costMedKit;
    [SerializeField] private GameObject fuel, medKit;
    [SerializeField] private Transform pointSpawn;
    [SerializeField] private float timeDeliver = 1;

    private VacuumCleaner player;
    [Header("UI")]
    [SerializeField] private GameObject panel, firstButton;
    [Header("Audio")]
    [SerializeField] private AudioSource buySound;

    private void Start()
    {
        panel.SetActive(false);
    }
    public void OpenPanel()
    {   
        panel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    public void ClosePanel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VacuumCleaner vacuum))
        {
            player = vacuum;
            OpenPanel();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out VacuumCleaner vacuum))
        {
            player = null;
            ClosePanel();
        }
    }
    public void DeliverFuel()
    {
        if(player.RemoveDebris(costFuel))
        {
            buySound.Play();
            Instantiate(fuel, pointSpawn.position, Quaternion.identity);
            print("fuel");
        }

    }
    public void DeliverMedkit()
    {
        if (player.RemoveDebris(costMedKit))
        {
            buySound.Play();
            Instantiate(medKit, pointSpawn.position, Quaternion.identity);
            print("MedKit");
            
        }
    }


}
