using UnityEngine;
public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string trigger;

    public void Play()
    {
        animator.SetTrigger(trigger);
    }
}
