using com.spectre7.Engine.Enums;
using com.spectre7.Engine.Events;
using UnityEngine;
using UnityEngine.Animations;

namespace com.spectre7.Engine.AnimatorBehaviours
{
    public class UpdateChainInfo : StateMachineBehaviour
    {
        private HEventMgr _hEventMgr;
        [SerializeField] private int currentChain;
        private int _lastPlayedChain = 0;
    
        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash, AnimatorControllerPlayable controller)
        {
            if (_hEventMgr is null)
            {
                _hEventMgr = animator.transform.GetComponent<HEventMgr>();
            }
            _lastPlayedChain = currentChain;
            Debug.Log(currentChain);
            switch (currentChain)
            {
                case (int)AnimChain.Jumping:
                {
                    _hEventMgr.FireStartedJumpAnimationEvent();
                    break;
                }
                case (int)AnimChain.Running:
                {
                    Debug.Log("Started running from Animator");
                    _hEventMgr.FireStartedRunningEvent();
                    break;
                }
            
            }
        
        }

        public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
        {
            switch (_lastPlayedChain)
            {
                case (int)AnimChain.Jumping:
                {
                    Debug.Log("Stopped jumping.");
                    _hEventMgr.FireStartedJumpAnimationLandEvent();
                    break;
                }
                case (int)AnimChain.Running:
                {
                    Debug.Log("Stopped running from Animator");
                    _hEventMgr.FireStoppedRunningEvent();
                    break;
                }
            }
        
        }
 
    }
}
