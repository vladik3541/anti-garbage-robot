using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instans;
    
    private int progress;

    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private Slider progressSlider;
    [SerializeField] private TextMeshProUGUI timeCount;
    [SerializeField] private float timer;

    public int Progres => progress;
    private void Awake()
    {
        instans = this;
        progressSlider.maxValue = 100;
        progressSlider.value = 0;
        UpdateUI();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timeCount.text = "Timer: " + string.Format("{0}:{1:00}", minutes, seconds);
    }
    public void AddProgres(int value)
    {
        progress += value;
        UpdateUI();
    }

    private void UpdateUI()
    {
        progressText.text = "progress: " + progress.ToString() + "%";
        progressSlider.value = progress;
    }
}
