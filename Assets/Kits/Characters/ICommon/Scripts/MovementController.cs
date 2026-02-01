using UnityEngine;

namespace Assets.Kits.Characters.ICommon.Scripts
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        [Header("Movement setup")]
        [SerializeField] private float walkSpeed = 2f;


        protected Animator animator;
        protected Rigidbody2D rb2d;
        protected virtual void Awake()
        {
            animator = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
        }


        protected Vector2 DesiredMove { get; set; } = Vector2.zero;
        protected virtual void Update()
        {

            rb2d.linearVelocityX = DesiredMove.x * walkSpeed;
            rb2d.linearVelocityY = DesiredMove.y * walkSpeed;

            animator.SetBool("IsWalking", DesiredMove != Vector2.zero);
            animator.SetBool("IsGoingLeft", false);
            animator.SetBool("IsGoingRight", false);
            animator.SetBool("IsGoingUp", false);
            animator.SetBool("IsGoingDown", false);

            if (DesiredMove.x < 0)
            {
                animator.SetBool("IsGoingLeft", true);
            }
            else if (DesiredMove.x > 0)
            {
                animator.SetBool("IsGoingRight", true);
            }
            else if (DesiredMove.y > 0)
            {
                animator.SetBool("IsGoingUp", true);
            }
            else if (DesiredMove.y < 0)
            {
                animator.SetBool("IsGoingDown", true);
            }
        }
    }
}
