using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private const string Mode = "Mode";

    private const int Idle = 0;
    private const int Run = 1;
    private const int Attack = 2;
    private const int Death = 3;
    private const int Victory = 4;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void IdleAnim()
    {
        _animator.SetInteger(Mode, Idle);
    }

    public void AttackAnim()
    {
        _animator.SetInteger(Mode, Attack);
    }

    public void DeathAnim()
    {
        _animator.SetInteger(Mode, Death);
    }

    public void VictoryAnim()
    {
        _animator.SetInteger(Mode, Victory);
    }

    public void RunAnim()
    {
        _animator.SetInteger(Mode, Run);
    }

    IEnumerator PlayAttack()
    {
        _animator.SetInteger(Mode, Attack);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
