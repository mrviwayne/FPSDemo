using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.spectre7.Engine.Enums
{
    public class AnimHash : MonoBehaviour
    {
        public class PlayerState
        {
            public static readonly int Run = Animator.StringToHash("Run");
            public static readonly int RunStart = Animator.StringToHash("Run Start");
            public static readonly int RunStop = Animator.StringToHash("Run Stop");
            public static readonly int Idle = Animator.StringToHash("Idling");
            public static readonly int Pivot = Animator.StringToHash("Pivot");
            public static readonly int DribbleIdle = Animator.StringToHash("Dribble Idle");
            public static readonly int DribbleStanceF = Animator.StringToHash("Dribble Stance F");
            public static readonly int DribbleStanceB = Animator.StringToHash("Dribble Stance B");
            public static readonly int DribbleStanceFToIdle = Animator.StringToHash("Stance F to Dribble Idle");
            public static readonly int DribbleStanceBToIdle = Animator.StringToHash("Stance B to Dribble Idle");
        }

        public class Chain
        {
            public static readonly int BallHandling = Animator.StringToHash("Base Layer.Stationary Dribble Moves");
            public static readonly int Running = Animator.StringToHash("Base Layer.Running");
            public static readonly int Idling = Animator.StringToHash("Base Layer.Idling");
        }

        public class Substate
        {
            public static readonly int LeftHandDribbleMoves = Animator.StringToHash("Base Layer.Ball Handling.Left Hand Moves");
            public static readonly int RightHandDribbleMoves = Animator.StringToHash("Base Layer.Ball Handling.Right Hand Moves");
            public static readonly int StationaryDribbleMoves = Animator.StringToHash("Base Layer.Ball Handling.Stationary Moves");
            public static readonly int DribbleMovesOnTheGo = Animator.StringToHash("Base Layer.Ball Handling.Moves On The Go");
            public static readonly int TripleThreatMoves = Animator.StringToHash("Base Layer.Ball Handling.Triple Threat Moves");

        }

        public class Parameter
        {
            public static readonly int AnimChain = Animator.StringToHash("Anim Chain");
            public static readonly int IsCrouching = Animator.StringToHash("IsCrouching");
            public static readonly int SpecialMoveBuffer = Animator.StringToHash("Special Move Buffer");
            public static readonly int Continue = Animator.StringToHash("Continue");
            public static readonly int PivotAngle = Animator.StringToHash("Pivot Angle");
            public static readonly int BallHandlingMirror = Animator.StringToHash("Arms Mirrored");
            public static readonly int BodyMirror = Animator.StringToHash("Body Mirrored");
            public static readonly int FootPlantedParam = Animator.StringToHash("Foot Planted");
            public static readonly int RepeatParam = Animator.StringToHash("Repeat");
            public static readonly int Repeat = Animator.StringToHash("RepeatMe");
            public static readonly int MoveID = Animator.StringToHash("Move ID");
            public static readonly int AnimCurveY = Animator.StringToHash("AnimCurveY");
            public static readonly int MoveIDB = Animator.StringToHash("Move IDB");
            public static readonly int MoveX = Animator.StringToHash("MoveX");
            public static readonly int HasBall = Animator.StringToHash("Has Ball");
            public static readonly int MoveY = Animator.StringToHash("MoveY");
            public static readonly int RawMoveX = Animator.StringToHash("RawMoveX");
            public static readonly int RawMoveY = Animator.StringToHash("RawMoveY");
            public static readonly int RStickX = Animator.StringToHash("RStickX");
            public static readonly int RStickY = Animator.StringToHash("RStickY");
            public static readonly int LiveParameter = Animator.StringToHash("Live Parameter");
            public static readonly int CachedValue = Animator.StringToHash("Cached Value");
            public static readonly int DribblingHand = Animator.StringToHash("Dribbling Hand");
            public static readonly int ShotButtonHeld = Animator.StringToHash("Shot Button Held");
            public static readonly int Release = Animator.StringToHash("Release");
            public static readonly int CanShoot = Animator.StringToHash("Can Shoot");
            
            public enum ParameterEnum
            {
                AnimChain,
                FootPlantedParam,
                MoveX,
                MoveY,
                RawMoveX,
                RawMoveY,
                CachedValue
            }
        }

        public class Tag
        {
            public static readonly int FootPlantedTag = Animator.StringToHash("CheckFeet");
            public static readonly int RepeatableTag = Animator.StringToHash("Repeatable");
        }
    }

}
