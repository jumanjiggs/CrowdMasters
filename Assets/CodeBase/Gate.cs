using UnityEngine;
using Zenject;

namespace CodeBase
{
    public enum TypeGate
    {
        Increase,
        Multiplier
    }

    public class Gate : MonoBehaviour
    {
        [SerializeField] private TypeGate typeGate;
        
        [SerializeField] private int increaseCrowd;
        [SerializeField] private int multiplierCrowd;

        private CrowdAnimator _crowdAnimator;

        [Inject]
        private void Construct(CrowdAnimator crowdAnimator)
        {
            _crowdAnimator = crowdAnimator;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CrowdSpawner crowdSpawner))
            {
                if (typeGate == TypeGate.Increase)
                    crowdSpawner.SpawnAroundPoint(increaseCrowd);
                else if (typeGate == TypeGate.Multiplier)
                    crowdSpawner.SpawnAroundPoint(crowdSpawner.totalCount * multiplierCrowd);
                
                _crowdAnimator.ResetAnimation();
                _crowdAnimator.PlayRun();
            }
        }
    }
}