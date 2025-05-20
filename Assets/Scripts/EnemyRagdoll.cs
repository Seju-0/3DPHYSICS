using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    private Rigidbody rb;
    private Animator animator;
    public bool isFallen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        rb.isKinematic = false;
        animator.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFallen) return;
        //simple chase to player
        Vector3 dir = (player.position - transform.position).normalized;
        dir.y = 0;
        transform.position += dir * moveSpeed * Time.deltaTime;
        transform.LookAt(player);
        animator.SetBool("isWalking", true);
    }

    public void FallDown()
    {

    }

    public void GetUp()
    {
        //stop all physics
        foreach (var boneRb in GetComponentsInChildren<Rigidbody>())
        {
            boneRb.linearVelocity = Vector3.zero;
            boneRb.angularVelocity = Vector3.zero;
            boneRb.isKinematic = true;
        }
    }
}
