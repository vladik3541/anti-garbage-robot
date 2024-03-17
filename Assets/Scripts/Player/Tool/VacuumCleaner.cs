using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VacuumCleaner : MonoBehaviour
{
    //size container
    private int maxVolumContainer = 10;
    [SerializeField] private int sizeFromLevel;
    [SerializeField] private int currentVolumeContainer;
    [Header("UI")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI textVolume;

    private PlayerInput playerInput;
    private void Awake()
    {
        volumeSlider.maxValue = maxVolumContainer;
        UpdateUI();
        
    }

    private void OnEnable()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }
    private void AddDebris(GameObject debris)
    {
        if (currentVolumeContainer >= maxVolumContainer) return;
        Destroy(debris );
        currentVolumeContainer++;
        UpdateUI();
    }
    public int GetDebris()
    {
        return currentVolumeContainer;
    }
    public bool RemoveDebris(int value)
    {
        print("RemoveDebris");
        if(currentVolumeContainer >= value)
        {
            currentVolumeContainer -= value;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }
        
        
    }
    public void UpgradeMaxContainer(int size)
    {
        maxVolumContainer = size;
        volumeSlider.maxValue = maxVolumContainer;
    }
    private void UpdateUI()
    {
        volumeSlider.value = currentVolumeContainer;
        textVolume.text = currentVolumeContainer.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Debris"))
        {
            AddDebris(other.gameObject);
            print("DestroyDebris");
            
            
        }
    }
}
