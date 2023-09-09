using System;
using System.Collections.Generic;
using com.spectre7.Engine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.spectre7.Engine.Input
{
    [RequireComponent(typeof(HEventMgr))]
    public class InputManager : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputActionMap _actionMap;
        private HEventMgr _eventMgr;
        private Animator _anim;

        private void Awake()
        {
            _eventMgr = GetComponent<HEventMgr>();
            _playerInput = GetComponent<PlayerInput>();
            _actionMap = GetComponent<PlayerInput>().currentActionMap;
            _anim = GetComponent<Animator>();
            _actionMap.actionTriggered += OnActionTriggered;
        }
        
        private void OnActionTriggered(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                HandleButtonPress(context);
            }
            else if (context.canceled)
            {
                HandleButtonRelease(context);
            }
        }


        private void HandleButtonPress(InputAction.CallbackContext context)
        {
            switch (context.action.name)
            {
                case Crouch:
                {
                    _eventMgr.FireCrouchInputFoundEvent();
                    break;
                }
                case Jump:
                {
                    _eventMgr.FirePlayerJumpInputFoundEvent();
                    break;
                }
                case Shoot:
                {
                    //_eventMgr.FireShotButtonHeldEvent();
                    break;
                }
                case Move:
                {
                    var moveValue = context.action.ReadValue<Vector2>();
                    if (moveValue != Vector2.zero)
                    {
                        _eventMgr.FireMoveInputFoundEvent(moveValue);
                    }

                    break;
                }
            }
           
        }
        
        private void HandleButtonRelease(InputAction.CallbackContext context)
        {
            switch (context.action.name)
            {
                case Jump:
                {
                    _eventMgr.FirePlayerJumpInputLostEvent();
                    break;
                }
                case Shoot:
                {
                    //_eventMgr.FireShotButtonReleasedEvent();
                    break;
                }
                case Move:
                {
                    _eventMgr.FireMoveInputLostEvent();     
                    break;
                }
            }
        }

        #region Action Map Constants
        
        private const int NeutralModeIndex = 0;
        private const int OffenseModeIndex = 1;
        private const int DefenseModeIndex = 2;
        private const string OffenseMode = "Offense_Mode";
        private const string DefenseMode = "Defense_Mode";
        private const string NeutralMode = "Neutral_Mode";

        #endregion

        #region Action Name Constants
        
        private const string Move = "Move";
        private const string Jump = "Jump";
        private const string Shoot = "Shoot";
        private const string Crouch = "Crouch";

        #endregion


    }
}
