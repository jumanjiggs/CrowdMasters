using UnityEngine;

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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CrowdSpawner crowdSpawner))
            {
                if (typeGate == TypeGate.Increase)
                    crowdSpawner.SpawnAroundPoint(increaseCrowd);
                else if (typeGate == TypeGate.Multiplier)
                    crowdSpawner.SpawnAroundPoint(crowdSpawner.totalCount * multiplierCrowd);
            }
        }
    }
}