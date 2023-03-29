using UnityEngine;

namespace CodeBase
{
    public class FXHolder : MonoBehaviour
    {
        [SerializeField] private ParticleSystem deathFX;

        public void SpawnDeathFx(Transform spawnPosition) => 
            Instantiate(deathFX, spawnPosition.position, Quaternion.identity);
    }
}
