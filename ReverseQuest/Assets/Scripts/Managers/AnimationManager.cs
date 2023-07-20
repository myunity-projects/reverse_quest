using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator _animator;


    private const string attackAnim = "isAttacking";
    private const string idleAnim = "isIdling";
    private const string deathAnim = "Dead";    
    private const string victoryAnim = "Victory";

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AttackAnim(float attackInterval)
    {
        StartCoroutine(AttackAnimation(attackInterval));
    }

    public void DeathAnim()
    {
        StartCoroutine(TriggerdDeathAnimation());
    }

    public void VictoryAnim()
    {
        PlayAnimation(victoryAnim, true);
    }

    public void PlayAnimation(string animationName, bool animationStatus)
    {
        _animator.SetBool(animationName, animationStatus);
    }

    public void TriggerAnimation(string animationName)
    {
        _animator.SetTrigger(animationName);
    }

    public float GetAnimationLength(string animName)
    {
        return _animator.GetCurrentAnimatorClipInfo(0).LongLength + 1;
    }

    IEnumerator TriggerdDeathAnimation()
    {
        _animator.SetTrigger(deathAnim);        
        yield return new WaitForSeconds(GetAnimationLength(deathAnim));
        Destroy(gameObject);
    }

    IEnumerator AttackAnimation(float attackInterval)
    {
        PlayAnimation(idleAnim, true);
        yield return new WaitForSeconds(attackInterval);

        PlayAnimation(attackAnim, true);
        yield return new WaitForSeconds(GetAnimationLength(attackAnim));
        PlayAnimation(attackAnim, false);
    }
}
