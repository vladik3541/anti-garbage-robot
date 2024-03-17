using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeBuilding : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject panel, firstButton;
    private void Start()
    {
        panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VacuumCleaner vacuum))
        {
            OpenPanel();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out VacuumCleaner vacuum))
        {
            ClosePanel();
        }
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
}
