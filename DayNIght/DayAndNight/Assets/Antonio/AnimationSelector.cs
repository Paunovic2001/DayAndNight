using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationSelector : MonoBehaviour
{
    SpriteRenderer sr;
    Player player;
    Animator animator;
    public float stationaryTreshold = 0.01f;
    public UnityEditor.Animations.AnimatorController run;
    public UnityEditor.Animations.AnimatorController idle;
    public UnityEditor.Animations.AnimatorController jump;
    public UnityEditor.Animations.AnimatorController fall;

    private void Start()
    {
        player = GetComponent<Player>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player.velocity.y > 0)
        {
            if(player.velocity.x > 0)
            {
                sr.flipX = false;
            }
            else if(player.velocity.x < 0)
            {
                sr.flipX = true;
            }
            animator.runtimeAnimatorController = jump;
        }
        
        if (player.velocity.y < 0)
        {
            if (player.velocity.x > 0)
            {
                sr.flipX = false;
            }
            else if (player.velocity.x < 0)
            {
                sr.flipX = true;
            }
            animator.runtimeAnimatorController = fall;
        }
        
        if (player.velocity.x > stationaryTreshold && player.velocity.y == 0)
        {
            sr.flipX = false;
            animator.runtimeAnimatorController = run;
        }
        
        if (player.velocity.x < -stationaryTreshold && player.velocity.y == 0)
        {
            sr.flipX = true;
            animator.runtimeAnimatorController = run;
        }
        

        if ( (player.velocity.x < stationaryTreshold && player.velocity.x > -stationaryTreshold) && (player.velocity.y < stationaryTreshold && player.velocity.y > -stationaryTreshold) )
        {
            animator.runtimeAnimatorController = idle;
        }
    }

    public void TestFunction()
    {
        Debug.Log("step Down");
    }

}
