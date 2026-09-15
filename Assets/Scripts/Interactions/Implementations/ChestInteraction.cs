using UnityEngine;

namespace Gameplay.Interactions{
    public class ChestInteraction : MonoBehaviour
    {
        private Interactable _interactable;
        private Animator _animator;
        bool isOpen;
        bool hasReward;
        public GameObject rewardPrefab;
        public int rewardCount = 1;

        void Awake()
        {
            _interactable = GetComponent<Interactable>();
            _interactable.OnInteract += Interact;
            hasReward = true;
            _animator = GetComponent<Animator>();
        }

        private void Interact(CharacterInteractor interactor)
        {
            isOpen = !isOpen;
            _animator.SetBool("IsOpen",isOpen);

            //_interactable.InteractionEnabled = false;
        }

        public void SpawnReward()
        {
            if (hasReward)
            {
                for (int i = 0; i < rewardCount; i++)
                {

                    GameObject reward = Instantiate(rewardPrefab, transform.position + Vector3.up * 0.2f, Quaternion.identity);
                    LaunchableReward launchableReward = reward.GetComponent<LaunchableReward>();
                    if (launchableReward != null)
                    {
                        launchableReward.LaunchReward();
                    }
                  
                }
                hasReward = false;
            }
        }
    }
}
