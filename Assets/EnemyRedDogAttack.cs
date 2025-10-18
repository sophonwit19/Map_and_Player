using UnityEngine;

public class EnemyRedDogAttack : EnemyAttack
{
    PlayerMoveControls playerMoveControls;

    public float forceX;
    public float forceY;
    public float duration;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SpecialAttack()
    {
        base.SpecialAttack();
        playerMoveControls = playerStats.GetComponentInParent<PlayerMoveControls>();
        StartCoroutine(playerMoveControls.KnockBack(forceX, forceY, duration, transform));
    }
}
