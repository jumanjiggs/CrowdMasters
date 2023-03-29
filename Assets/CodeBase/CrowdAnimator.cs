using System.Collections.Generic;
using UnityEngine;

namespace CodeBase
{
    public class CrowdAnimator : MonoBehaviour
    {
        public List<Animator> crowd;
        
        private static readonly int Run = Animator.StringToHash("Run");
        

        public void ResetAnimation()
        {
            foreach (var character in crowd)
            {
                character.Rebind();
                character.Update(0f);
            }
        }
        
        public void PlayRun()
        {
            foreach (var character in crowd) 
                character.SetTrigger(Run);
        }
        
        public void AddToList(Animator character) => 
            crowd.Add(character);
        
        public void RemoveFromList(Animator character) => 
            crowd.Remove(character);
    }
}