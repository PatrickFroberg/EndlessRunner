using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpForce = 10;
    public float SprintModifier = 1.5f;
    public float gravityModifier;
    public bool IsOnGround = true;
    public bool GameOver;
    public ParticleSystem ExplosionParticle;
    public ParticleSystem DirtParticle;
    public AudioClip JumpSound;
    public AudioClip CrashSound;
    public bool IsSprinting;

    private Rigidbody _playerRb;
    private Animator _playerAnim;
    private AudioSource _playerAudio;
    private float _jumps;
    private bool _respondToCollisions;

    void Awake()
    {
        _respondToCollisions = false;
    }

    void Start()
    {
        _jumps = 2;
        _playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
        _respondToCollisions = true;
        DirtParticle.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !GameOver
            || Input.GetKeyDown(KeyCode.Space) && _jumps != 0 && !GameOver)
        {
            Jump();
        }

        SprintCheck();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!GameOver && _respondToCollisions)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                IsOnGround = true;
                _jumps = 2;
                DirtParticle.Play();
            }

            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                ExplosionParticle.Play();
                DirtParticle.Stop();
                _playerAudio.PlayOneShot(CrashSound, 0.6f);

                Debug.Log("GAME OVER!");
                GameOver = true;
                _playerAnim.SetBool("Death_b", true);
                _playerAnim.SetInteger("DeathType_int", 1);
            }
        }
    }

    private void Jump()
    {
        _jumps--;
        DirtParticle.Stop();
        _playerAudio.PlayOneShot(JumpSound, 1.5f);
        _playerAnim.SetTrigger("Jump_trig");
        _playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        IsOnGround = false;
    }

    private void SprintCheck()
    {
        if (IsOnGround)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                IsSprinting = true;
            else
                IsSprinting = false;
        }
    }
}
