using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instans;
    
    private int progress;
    [SerializeField] private int goal;

    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI timeCount;
    [SerializeField] private float timer;

    public int Progres => progress;
    private void Awake()
    {
        instans = this;
        UpdateUI();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timeCount.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
    public void AddProgres(int value)
    {
        progress += value;
        UpdateUI();
    }

    private void UpdateUI()
    {
        progressText.text = progress.ToString() + "/" + goal.ToString();
    }
}
