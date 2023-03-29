using System.Collections.Generic;
using UnityEngine;

namespace CodeBase
{
    public class CrowdAnimator : MonoBehaviour
    {
        public List<Animator> crowd;
        
        public void ResetAnimationRun()
        {
            foreach (var character in crowd)
            {
                character.Rebind();
                character.Update(0f);
            }
        }
        
        public void AddToList(Animator character) => 
            crowd.Add(character);
    }
}