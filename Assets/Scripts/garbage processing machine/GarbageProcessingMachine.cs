using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GarbageProcessingMachine : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider sliderForCapacity;

    [Header("Capacity")]
    public int currentCapacity;
    [SerializeField] private int maxCapacity;

    [Header("Procesing")]
    [SerializeField] private float timeProcesing = 10f;
    [SerializeField] private Transform endPositionProduct;
    [SerializeField] private GameObject resultProduct;
    [SerializeField] private int maxRes, minRes;

    private float timer;

    private void Start()
    {
        timer = timeProcesing;
        sliderForCapacity.maxValue = maxCapacity;
        UpdateUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out VacuumCleaner vacuumCleaner))
        {
            int getDebris = vacuumCleaner.GetDebris();
            if (vacuumCleaner.RemoveDebris(getDebris))
            {
                currentCapacity += getDebris;
            }
            
        }
        if (currentCapacity >= maxCapacity)
        {
            StartCoroutine(StartProcesed());
        }

        UpdateUI();
    }
    IEnumerator StartProcesed()
    {
        
        currentCapacity -= maxCapacity;

        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            sliderForCapacity.maxValue = timeProcesing;
            sliderForCapacity.value = timer;

            //animation
            yield return null;
        }
        //resultat
        timer = timeProcesing;
        sliderForCapacity.maxValue = maxCapacity;
        UpdateUI();

        for (int i = 0; i < Random.Range(minRes, maxRes); i++)
        {
            Instantiate(resultProduct, endPositionProduct.position, resultProduct.transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("result");
    }
    void UpdateUI()
    {
        sliderForCapacity.value = currentCapacity;
    }
}
