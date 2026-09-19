using UnityEngine;
using TMPro;
public class CoinCounterController : MonoBehaviour {
    [SerializeField] private Inventory inventory;
    private TMP_Text coinText;
    private Animator _animator;

    void Awake()
    {
        coinText = GetComponentInChildren<TMP_Text>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        inventory.OnInventoryUpdated += UpdateCoinText;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = $"{inventory.GetCoins()}";
        _animator.SetTrigger("CoinCollected");
    }
}