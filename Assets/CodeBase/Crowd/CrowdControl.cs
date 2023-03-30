using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services.UI;
using DG.Tweening;
using GPUInstancer;
using GPUInstancer.CrowdAnimations;
using UnityEngine;
using Zenject;

namespace CodeBase.Crowd
{
    public class CrowdControl : MonoBehaviour
    {
        public GPUICrowdManager crowdManager;
        public float radius;
        public float radiusRate;
        public int count;
        public int countAdd;

        [Inject] private CrowdAnimator _animator;
        [Inject] private DiContainer _diContainer;
        [Inject] private UiFactory _uiFactory;

        private int _startCount;
        private float _startRadius;
        private int _circleIndex;
        

        private void Start()
        {
            _startCount = count;
            _startRadius = radius;
            if (crowdManager == null)
                return;
            crowdManager.enabled = false;
            var instanceList = SetupCrowd(out var crowdPrototype);

            int totalCount = 0;
            while (totalCount < 3)
            {
                for (int j = 0; j < 3; j++)
                {
                    Vector3 spawnPos = GetCirclePosition(j);
                    GameObject currentCharacter = _diContainer.InstantiatePrefab(crowdPrototype.prefabObject,
                        spawnPos, Quaternion.identity, transform);
                    _animator.AddToList(currentCharacter.GetComponent<Animator>());
                    instanceList.Add(currentCharacter.GetComponent<GPUICrowdPrefab>());
                    _uiFactory.UpdateCrowdCount(_animator.crowd.Count);
                    totalCount++;
                    if (totalCount >= 3)
                        break;
                }
                count += countAdd;
                radius += radiusRate;
            }
           
            
            GPUInstancerAPI.RegisterPrefabInstanceList(crowdManager, instanceList);
            crowdManager.enabled = true;
        }

        public void SpawnAroundPoint(int total)
            {
                GameObject prefabObject = crowdManager.prototypeList[0].prefabObject;
                
                int totalCount = 0;
               
                while (totalCount < total)
                {
                    bool completedCircle = false;
                    for (int j = _circleIndex; j < count; j++)
                    {
                        Vector3 spawnPos = GetCirclePosition(j);
                        GameObject currentCharacter = _diContainer.InstantiatePrefab(prefabObject,
                            spawnPos, Quaternion.identity, transform);
                        _animator.AddToList(currentCharacter.GetComponent<Animator>());
                        GPUInstancerAPI.AddPrefabInstance(crowdManager,
                                currentCharacter.GetComponent<GPUICrowdPrefab>());
                        _uiFactory.UpdateCrowdCount(_animator.crowd.Count);
                        totalCount++;
                        completedCircle = CompletedCircle(j);
                        if (totalCount >= total)
                            break;
                    }
                    
                    if (completedCircle)
                    {
                        count += countAdd;
                        radius += radiusRate;
                    }
                }
                GPUInstancerAPI.InitializeGPUInstancer(crowdManager);
            }

        private bool CompletedCircle(int circleIndex)
        {
            if (circleIndex == count - 1)
            {
                _circleIndex = 0;
                return true;
            }
            
            _circleIndex = circleIndex;
            return false;
        }

        public void ResetPositions()
        {
            count = _startCount;
            radius = _startRadius;
            int totalCount = 0;
            int index = 0;
            while (totalCount < _animator.crowd.Count)
            {
                for (int j = 0; j < count; j++)
                {
                    Transform unit = _animator.crowd[index].transform;
                    var pos = GetCirclePosition(j);
                    pos = transform.InverseTransformPoint(pos);
                    unit.DOLocalMove(pos, 0.15f).SetEase(Ease.Linear);
                    index++;
                    totalCount++;
                    if (totalCount >= _animator.crowd.Count)
                        break;
                }
                count += countAdd;
                radius += radiusRate;
            }
        }

        private Vector3 GetCirclePosition(int index)
        {
            float radians = 2 * MathF.PI / count * index;
            float vertical = MathF.Sin(radians);
            float horizontal = MathF.Cos(radians);
            Vector3 dir = new Vector3(horizontal, 0, vertical);
            Vector3 pos = transform.position + dir * radius;
            return pos;
        }


        private List<GPUInstancerPrefab> SetupCrowd(out GPUICrowdPrototype crowdPrototype)
        {
            List<GPUInstancerPrefab> instanceList = new List<GPUInstancerPrefab>();
            crowdPrototype = (GPUICrowdPrototype)crowdManager.prototypeList[0];
            crowdPrototype.animationData.useCrowdAnimator = true;
            crowdPrototype.enableRuntimeModifications = true; 
            crowdPrototype.addRemoveInstancesAtRuntime = true;
            crowdPrototype.extraBufferSize = 10000;
            return instanceList;
        }

        public void RemovePrefab(GPUInstancerPrefab obj) => 
                crowdManager.RemovePrefabInstance(obj, false);
    }
    }