using System;
using System.Collections.Generic;
using com.spectre7.Engine.Input;
using com.spectre7.Engine.Observers;
using Unity.VisualScripting;
using UnityEngine;

namespace com.spectre7.Engine.Events
{
    public class HEventMgr : MonoBehaviour
    {
        
        private List<PlayerComponent> _listeners;

        public delegate void NotificationOnlyEvent();
        public delegate void Vector2Event(Vector2 vector);
        
        public event NotificationOnlyEvent PlayerStartedRunning;
        public event NotificationOnlyEvent PlayerStoppedRunning;
        public event Vector2Event MoveInputFound;
        public event NotificationOnlyEvent MoveInputLost;
        public event NotificationOnlyEvent PlayerJumpInputFound;
        public event NotificationOnlyEvent PlayerJumpInputLost;
        public event NotificationOnlyEvent PlayerStartedJumpingAnimation;
        public event NotificationOnlyEvent PlayerStartedJumpLandAnimation;


        public void FireStartedRunningEvent()
        {
            PlayerStartedRunning?.Invoke();
        }
        
        public void FireStartedJumpAnimationEvent()
        {
            PlayerStartedJumpingAnimation?.Invoke();
        }

        public void FireStartedJumpAnimationLandEvent()
        {
            PlayerStartedJumpLandAnimation?.Invoke();
        }
        
        public void FirePlayerJumpInputFoundEvent()
        {
            PlayerJumpInputFound?.Invoke();
        }
        
        public void FirePlayerJumpInputLostEvent()
        {
            PlayerJumpInputLost?.Invoke();
        }
        public void FireMoveInputFoundEvent(Vector2 moveData)
        {
            MoveInputFound?.Invoke(moveData);
        }
        
        public void FireMoveInputLostEvent()
        {
            MoveInputLost?.Invoke();
        }
        
        public void FireStoppedRunningEvent()
        {
            PlayerStoppedRunning?.Invoke();
        }
        
        
    }
}
