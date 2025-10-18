using UnityEngine;

public class PlayerAttackControls : MonoBehaviour
{
    private PlayerMoveControls playerMoveControls;
    private GatherInput gatherInput;
    private Animator animator;

    public bool attackStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMoveControls = GetComponent<PlayerMoveControls>();
        gatherInput = GetComponent<GatherInput>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        //if player presses the attack button
        if (gatherInput.tryAttack)
        {
            animator.SetBool("Attack", true);
            attackStarted = true;
        }
    }
    /// <summary>
    /// to reset and stop the attack animation
    /// </summary>
    public void ResetAttack()
    {
        // set the attack animation to false
        animator.SetBool("Attack", false);
        gatherInput.tryAttack = false;
        attackStarted = false;
    }
}