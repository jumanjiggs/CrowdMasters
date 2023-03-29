using System;
using UnityEngine;

namespace CodeBase
{
    public class CrowdSpawner : MonoBehaviour
    {
        public GameObject characterPrefab;
        public CrowdAnimator animator;
        public float radius;
        public float radiusRate;
        public int totalCount;
        public int startCount;
        public int countAdd;

        private void Start()
        {
            SpawnAroundPoint(3);
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
                    GameObject currentCharacter = Instantiate(characterPrefab, spawnPos, Quaternion.identity, transform);
                    animator.AddToList(currentCharacter.GetComponentInChildren<Animator>());
                    totalCount++;
                    if(totalCount >= total)
                        break;
                }
                startCount += countAdd;
                radius += radiusRate;
                animator.ResetAnimationRun();
            }
        }
        
    }
}