using UnityEngine;
using UnityEngine.Events;
public class Inventory : MonoBehaviour {
    [SerializeField] int coins;

    public UnityAction OnInventoryUpdated;

    public int GetCoins()
    {
        return coins;
    }

    public void AddOrSubtractCoins(int amount)
    {
        coins += amount;
        OnInventoryUpdated?.Invoke();
    }
}
