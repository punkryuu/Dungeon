using Gameplay.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour {
    [SerializeField] private Damageable damageable;
    private TMP_Text hpText;
    [SerializeField] private Image hpBar;

    void Awake()
    {
        hpText = GetComponentInChildren<TMP_Text>();
    }

    void Start()
    {
        damageable.OnDamageTaken += UpdateBar;
        UpdateBar(0);
    }

    private void UpdateBar(float dmg)
    {
        hpBar.fillAmount = damageable.CurrentHitpoints / damageable.MaxHitpoints;
        hpText.text = $"{damageable.CurrentHitpoints} / {damageable.MaxHitpoints}";
    }

}