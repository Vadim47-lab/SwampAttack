using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;
    private readonly string _celebration = "_Celebration";
    private readonly string _attack = "_Attack";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetBool(_attack, false);
        _animator.SetBool(_celebration, true);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}