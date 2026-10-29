using UnityEngine;

public class ArrowTrap : MonoBehaviour, IActivable {
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform spawnPoint;

    public void Activate(bool activate)
    {
        if (activate && arrowPrefab != null && spawnPoint != null)
        {
            Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
