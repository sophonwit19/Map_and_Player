using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float helth;

    protected Rigidbody2D rb;
    protected Animator anim;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
}
