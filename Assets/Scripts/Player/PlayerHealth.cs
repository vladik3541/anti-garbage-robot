using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public event Action OnDeadPlayer;
    [SerializeField] private TextMeshProUGUI textHP;
    [SerializeField] private ParticleSystem explosion;

    protected override void UpdateUI()
    {
        base.UpdateUI();
        textHP.text = health.ToString("F1");
    }
    protected override void Die()
    {
        base.Die();

        OnDeadPlayer?.Invoke();
        GameObject effect = Instantiate(explosion.gameObject, transform.position, Quaternion.identity);
        Destroy(effect, 0.9f);
        Time.timeScale = 0.3f;
        gameObject.SetActive(false);
        Invoke(nameof(End), 2f);

    }
    private void End()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
}
