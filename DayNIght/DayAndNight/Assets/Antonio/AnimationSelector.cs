using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations;

public class AnimationSelector : MonoBehaviour
{
    SpriteRenderer sr;
    Player player;
    Animator animator;
    public float stationaryTreshold = 0.01f;
    public bool isGoindDownOnPlatform = false;

    // we can't use "UnityEditor.Animations.AnimatorController" so we use "RuntimeAnimatorController"

    public RuntimeAnimatorController run;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController jump;
    public RuntimeAnimatorController fall;

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
            isGoindDownOnPlatform = false;
        }
        
        if (player.velocity.y < 0 && isGoindDownOnPlatform == false)
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
            isGoindDownOnPlatform = false;
        }
        
        if (player.velocity.x < -stationaryTreshold && player.velocity.y == 0)
        {
            sr.flipX = true;
            animator.runtimeAnimatorController = run;
            isGoindDownOnPlatform = false;
        }
        

        if ( (player.velocity.x < stationaryTreshold && player.velocity.x > -stationaryTreshold) && (player.velocity.y < stationaryTreshold && player.velocity.y > -stationaryTreshold) )
        {
            animator.runtimeAnimatorController = idle;
            isGoindDownOnPlatform = false;
        }
    }

    public void TestFunction()
    {
        Debug.Log("step Down");
    }

}
