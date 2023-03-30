using System.Collections.Generic;
using System.Linq;
using GPUInstancer;
using GPUInstancer.CrowdAnimations;
using UnityEngine;
using Zenject;

namespace CodeBase.Crowd
{
    public class CrowdAnimator : MonoBehaviour
    {
        public AnimationClip runAnim;
        public AnimationClip winAnim;

        [Inject] private CrowdControl _control;
        [HideInInspector] public List<Animator> crowd;

        private float _startTime;
        
        public void PlayRun()
        {
            List<GPUInstancerPrefab> instanceList = _control.crowdManager.GetRegisteredPrefabsRuntimeData()[_control.crowdManager.prototypeList[0]];
            foreach (var crowdInstance in instanceList.Cast<GPUICrowdPrefab>())
            {
                GPUICrowdAPI.StartAnimation(crowdInstance, runAnim, _startTime);
            }
        }

        public void PlayWin()
        {
            List<GPUInstancerPrefab> instanceList = _control.crowdManager.GetRegisteredPrefabsRuntimeData()[_control.crowdManager.prototypeList[0]];
            foreach (var crowdInstance in instanceList.Cast<GPUICrowdPrefab>())
            {
                GPUICrowdAPI.StartAnimation(crowdInstance, winAnim, _startTime);
            }
        }
        
        public void AddToList(Animator character) => 
            crowd.Add(character);

        public void RemoveFromList(Animator character) => 
            crowd.Remove(character);
    }
}