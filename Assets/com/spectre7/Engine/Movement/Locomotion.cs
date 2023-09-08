using System;
using com.spectre7.Engine.Enums;
using com.spectre7.Engine.Events;
using UnityEngine;

namespace com.spectre7.Engine.Movement
{
    public class Locomotion : MonoBehaviour
    {
        private HEventMgr _hEventMgr;

        private bool _isRunning;
        private bool _isJumping;
        
        public bool isGrounded; 
        
        private Animator _anim;
        
        private Vector2 _movement;

        private CharacterController _skin;

        [SerializeField]
        [Range(1f,10f)]
        private float playerSpeed;
        
        [SerializeField]
        private float jumpHeight;
            
        // Start is called before the first frame update
        void Start()
        {
            _hEventMgr = GetComponent<HEventMgr>();
            _hEventMgr.PlayerStartedJumpingAnimation += onPlayerJumpAnimStart;
            _hEventMgr.PlayerJumpInputFound += OnPlayerJumpInputFound;
            _hEventMgr.PlayerStartedJumpLandAnimation += onPlayerJumpAnimStop;
            _hEventMgr.PlayerStartedRunning += OnPlayerRunAnimationStart;
            _hEventMgr.PlayerStoppedRunning += OnPlayerRunAnimationStop;
            _hEventMgr.MoveInputFound += OnMoveInputFound;
            _hEventMgr.MoveInputLost += OnMoveInputLost;
            _anim = GetComponent<Animator>();
            _skin = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            isGrounded = _skin.isGrounded;
            Vector3 moveValue = Vector3.zero;
            if (_isRunning)
            {
                moveValue.x = _movement.x;
                moveValue.z = _movement.y;
                moveValue *= (Time.fixedDeltaTime * playerSpeed);
            }
            if (_isJumping)
            {
                moveValue.y = _anim.GetFloat(AnimHash.Parameter.AnimCurveY) *  jumpHeight *Time.fixedDeltaTime;
            Debug.Log("Jumped!");
            }

            _skin.Move(moveValue);
        }

        void OnMoveInputFound(Vector2 move)
        {
            _anim.SetInteger(AnimHash.Parameter.AnimChain, (int)AnimChain.Running);
            _anim.SetFloat(AnimHash.Parameter.MoveX, move.x);
            _anim.SetFloat(AnimHash.Parameter.MoveY, move.y);
            _movement = move;
        }

        void OnPlayerJumpInputFound()
        {
            if (_skin.isGrounded)
            {
                Debug.Log("Grounded and set.");
                _anim.SetInteger(AnimHash.Parameter.AnimChain, (int)AnimChain.Jumping);
            }
            else
            {
                Debug.Log("Wasn't grounded!");
            }
        }

        void onPlayerJumpAnimStart()
        {
            Debug.Log("SEt to jump");
            _anim.SetInteger(AnimHash.Parameter.AnimChain, (int)AnimChain.Idling);
            _isJumping = true;
        }

        void onPlayerJumpAnimStop()
        {
            _isJumping = false;
        }
        void OnMoveInputLost()
        {
            Debug.Log("Move input lost");
            _anim.SetInteger(AnimHash.Parameter.AnimChain, 0);
            //_movement = Vector2.zero;
        }

        void OnPlayerRunAnimationStart()
        {
            _isRunning = true;
        }
        
        void OnPlayerRunAnimationStop()
        {
            _isRunning = false;
        }

        private void OnDestroy()
        {
            _hEventMgr.PlayerStartedRunning -= OnPlayerRunAnimationStart;
            _hEventMgr.PlayerStoppedRunning -= OnPlayerRunAnimationStart;
        }
    }
}
