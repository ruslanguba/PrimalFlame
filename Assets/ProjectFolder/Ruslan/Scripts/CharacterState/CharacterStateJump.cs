using System.Collections;
using UnityEngine;

public class CharacterStateJump : CharacterStateBase
{
    public CharacterStateJump(CharacterStateMachine stateMachine, CharacterMovement movement, Rigidbody2D rb, CharacterLedgeHandler ledgeHandler)
        : base(stateMachine, movement, rb, ledgeHandler) { }

    public override void Enter()
    {
        //_ledgeHandler.OnLedgeGrabbed += GrabLedge;
        // �������� �������� � ���� ������
        // _movement.PlayJumpAnimation();
        // _movement.PlayJumpSound();

        // ����������� ��������� � ��������� ������ (��� �������� ��������)
        _stateMachine.SetStateFall();
    }
}
