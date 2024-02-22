using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaggageFuel : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI textInfo;

    
    
    private float maxFuel = 100;
    private float fuel;
    private void Start()
    {
        fuel = maxFuel;
        slider.maxValue = fuel;
        UpdateUI();
    }
    public bool AddFuel(float value)
    {
        if(fuel < maxFuel)
        {
            fuel += value;
            if (fuel > maxFuel)
            {
                fuel = maxFuel;
            }
            UpdateUI();
            return true;
            
        }
        else
        {
            return false;
        }
    }
    public bool RemoveFuel(float value)
    {
        if(fuel > 0)
        {
            fuel-= value;
            UpdateUI();
            return true;
        }
        else {
            return false;
        }
    }
    private void UpdateUI()
    {
        slider.value = fuel;
        textInfo.text = fuel.ToString("F1");
    }
}
