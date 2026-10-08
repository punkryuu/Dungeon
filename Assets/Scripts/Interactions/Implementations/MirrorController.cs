using UnityEngine;
using Gameplay.Interactions;

public class MirrorController : MonoBehaviour
{
    private Interactable _interactable;
    public LaserController _laserController { get; private set; }
    private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _interactable = GetComponent<Interactable>();
        _interactable.OnInteract += Interact;

        _laserController = GetComponent<LaserController>();
        _animator = GetComponent<Animator>();
    }
    private void Interact(CharacterInteractor interactor)
    {
        _animator.SetTrigger("rotate");

    }
   


}
