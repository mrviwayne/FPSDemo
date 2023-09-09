using System;
using com.spectre7.Engine.Enums;
using com.spectre7.Engine.Events;
using UnityEngine;

namespace com.spectre7.Engine.Movement
{
    public class Locomotion : MonoBehaviour
    {
        private HEventMgr _hEventMgr;
        private Animator _anim;
        private CharacterController _skin;

        private bool _isRunning, _isJumping, _crouchKeyHeld;

        private Vector2 _movement;
        private float _oldBlendValue;
        private float _animStartTime;
        
        [SerializeField]
        [Range(0.1f,1f)]
        private float AnimBlendDuration = 0.5f;

        private float AnimationBlendStep => (Time.time - _animStartTime) / AnimBlendDuration;

        [SerializeField]
        [Range(1f,10f)]
        private float playerSpeed;

        [SerializeField]
        [Range(0.1f,1f)]
        private float crouchSpeed;
        
        [SerializeField]
        private float jumpHeight;
        
        private float CrouchModifier => _crouchKeyHeld ? 1 : crouchSpeed;
        
        
            
        // Start is called before the first frame update
        void Start()
        {
            _hEventMgr = GetComponent<HEventMgr>();
            _hEventMgr.CrouchInputFound += OnCrouchInputFound;
            _hEventMgr.PlayerStartedJumpingAnimation += OnPlayerJumpAnimStart;
            _hEventMgr.JumpInputFound += OnJumpInputFound;
            _hEventMgr.PlayerStartedJumpLandAnimation += OnPlayerJumpAnimStop;
            _hEventMgr.PlayerStartedRunning += () => _isRunning = true;
            _hEventMgr.PlayerStoppedRunning += () => _isRunning = false;
            _hEventMgr.MoveInputFound += OnMoveInputFound;
            _hEventMgr.MoveInputLost += OnMoveInputLost;
            _anim = GetComponent<Animator>();
            _skin = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            Vector3 moveValue = Vector3.zero;
            if (!_crouchKeyHeld)
            {
                _anim.SetFloat(AnimHash.Parameter.IsCrouching, -Mathf.SmoothStep(-_oldBlendValue, 0, AnimationBlendStep));
            }
            else
            {
                _anim.SetFloat(AnimHash.Parameter.IsCrouching, Mathf.SmoothStep(_oldBlendValue, 1, AnimationBlendStep));
            }
            if (_isRunning)
            {
                moveValue.x = _movement.x;
                moveValue.z = _movement.y;
                moveValue *= (Time.fixedDeltaTime * playerSpeed * CrouchModifier);
            }
            if (_isJumping)
            {
                moveValue.y = _anim.GetFloat(AnimHash.Parameter.AnimCurveY) *  jumpHeight *Time.fixedDeltaTime;
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

        void OnJumpInputFound()
        {
            if (_skin.isGrounded)
            {
                _anim.SetInteger(AnimHash.Parameter.AnimChain, (int)AnimChain.Jumping);
            }
        }

        void OnPlayerJumpAnimStart()
        {
            Debug.Log("SEt to jump");
            _anim.SetInteger(AnimHash.Parameter.AnimChain, (int)AnimChain.Idling);
            _isJumping = true;
        }

        void OnPlayerJumpAnimStop()
        {
            _isJumping = false;
        }
        void OnMoveInputLost()
        {
            Debug.Log("Move input lost");
            _anim.SetInteger(AnimHash.Parameter.AnimChain, 0);
            //_movement = Vector2.zero;
        }

        void OnCrouchInputFound()
        {
            _crouchKeyHeld = !_crouchKeyHeld;
            _oldBlendValue = _anim.GetFloat(AnimHash.Parameter.IsCrouching);
            _animStartTime = Time.time;
        }
        
        private void OnDestroy()
        {
            
        }
    }
}
