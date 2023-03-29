using System;
using UnityEngine;
using Zenject;

namespace CodeBase
{
    public class CrowdSpawner : MonoBehaviour
    {
        public GameObject characterPrefab;
        public float radius;
        public float radiusRate;
        public int totalCount;
        public int startCount;
        public int countAdd;

        [Inject] private CrowdAnimator _animator;
        [Inject] private DiContainer _diContainer;
        
        private const int StartCrowd = 3;

        private void Start()
        {
            SpawnAroundPoint(StartCrowd);
        }

        public void SpawnAroundPoint(int total)
        {
            totalCount = 0;
            while (totalCount < total)
            {
                for (int j = 0; j < startCount; j++)
                {
                    float radians = 2 * MathF.PI / startCount * j;
                    float vertical = MathF.Sin(radians);
                    float horizontal = MathF.Cos(radians);
                    Vector3 spawnDir = new Vector3(horizontal, 0, vertical);
                    Vector3 spawnPos = transform.position + spawnDir * radius;
                    GameObject currentCharacter =_diContainer.InstantiatePrefab(characterPrefab, spawnPos, Quaternion.identity, transform);
                    _animator.AddToList(currentCharacter.GetComponentInChildren<Animator>());
                    totalCount++;
                    if(totalCount >= total)
                        break;
                }
                startCount += countAdd;
                radius += radiusRate;
            }
        }
        
    }
}