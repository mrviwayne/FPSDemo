using UnityEngine;

namespace com.spectre7.Engine.Observers
{
    public abstract class PlayerComponent : MonoBehaviour
    {

        /// <summary>
        /// Callback that lets observers know what the current animation chain (substate) is.
        /// </summary>
        /// <param name="newAnimChain"></param>
        internal virtual void OnAnimationChainChange(int newAnimChain){}

        /// <summary>
        /// Callback that lets observers know that movement input has been lost.
        /// </summary>
        internal virtual void OnMoveInputLost(){}
        
        /// <summary>
        /// Callback that lets observers know that movement input has been lost.
        /// </summary>
        /// <param name="moveVector"></param> The vector
        internal virtual void OnMoveInputFound(Vector2 moveVector){}

        /// <summary>
        /// Callback that lets observers know that the basketball has changed hands.
        /// </summary>
        /// <param name="newHand"></param> The current dribbling hand
        internal virtual void OnBallChangedHands(int newHand){}

        /// <summary>
        /// Callback that lets observers know that the animator is looking for a MoveID to play a dribble move.
        /// </summary>
        internal virtual void OnDribbleMovePlayRequest(){}
        
        /// <summary>
        /// Callback that lets observers know that the animator has just played a dribble move.
        /// </summary>
        internal virtual void OnDribbleMovePlayed(){}

        /// <summary>
        /// Callback that lets observers know that the input system has detected a chance in the player's input direction.
        /// </summary>
        internal virtual void OnDirectionChangeDetected(){}

        /// <summary>
        /// Callback that lets observers know that the animator has started playing a shooting animation
        /// </summary>
        /// <param name="animationType"></param>
        internal virtual void OnShootingMotionStarted(int animationType){}

        /// <summary>
        /// Callback that lets observers know that the animator has stopped playing a shooting animation
        /// </summary>
        internal virtual void OnShootingMotionEnded() {}
        
        /// <summary>
        /// Callback that lets observers know that the player is holding the shot button down
        /// </summary>
        internal virtual void OnShotButtonHeld() {}        
        
        /// <summary>
        /// Callback that lets observers know that the player has released the shot button
        /// </summary>
        internal virtual void OnShotButtonReleased() {}

        /// <summary>
        /// Callback that lets observers know that the player has started running.
        /// </summary>
        internal virtual void OnRunStart(){}
        
        /// <summary>
        /// Callback that lets observers know that the player has stopped running.
        /// </summary>
        internal virtual void OnRunStop(){}
    }
}
