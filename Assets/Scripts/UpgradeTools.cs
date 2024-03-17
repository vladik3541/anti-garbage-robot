using System;
using TMPro;
using UnityEngine;

public class UpgradeTools : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI toolsText, containerText;

    public UpgradeLaser[] upTools;
    public UpgradeContainer[] upContainers;
    [Header("Audio")]
    [SerializeField] private AudioSource upgradeSound;
    private int levelTools;
    private int levelContainer;

    private Laser laser;
    private Bomb bomb;
    private VacuumCleaner vacuumCleaner;
    private void Start()
    {
        laser = FindAnyObjectByType<Laser>();
        bomb = FindAnyObjectByType<SpawnBomb>().bomb.GetComponent<Bomb>();
        vacuumCleaner = FindAnyObjectByType<VacuumCleaner>();
    }
    public void UpLevelTools()
    {
        int getDebris = vacuumCleaner.GetDebris();
        if (getDebris >= upTools[levelTools].cost)
        {
            vacuumCleaner.RemoveDebris(upTools[levelTools].cost);
            laser.UpgradeLaser(upTools[levelTools].damageLaser);
            bomb.UpgradeDamage(upTools[levelTools].damageBomb);
            levelTools++;
            upgradeSound.Play();
            toolsText.text = "Damage: " + upTools[levelTools].cost;

        }
        

    }
    public void UpLevelContainer()
    {
        int getDebris = vacuumCleaner.GetDebris();
        if (getDebris >= upContainers[levelContainer].cost)
        {
            vacuumCleaner.RemoveDebris(upContainers[levelContainer].cost);
            vacuumCleaner.UpgradeMaxContainer(upContainers[levelContainer].size);
            levelContainer++;
            upgradeSound.Play();
            containerText.text = "Container: " + upContainers[levelContainer].cost;
        }
    }


}
[Serializable]
public class UpgradeLaser
{
    public int cost;
    public float damageLaser, damageBomb;
}
[Serializable]
public class UpgradeContainer
{
    public int cost;
    public int size;
}

