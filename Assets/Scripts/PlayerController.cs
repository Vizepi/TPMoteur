using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 5.0f;
    public float jumpPower = 10.0f;
    public Rigidbody2D rb;
    public GameObject feet;
    private bool isJumping = false;
    public LayerMask isJumpable;
    public float jumpDuration = 0.2f;
    private float jumpTime = 0.0f;
	public Animator anim;
	public Transform art;

	private bool invincible = false;
	private float invicibleTimer = 0.0f;

	[SerializeField]
	private Transform spawn;

	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<ScoreManager>();
		Debug.Assert(scoreManager != null);
		Debug.Assert(spawn != null);
	}

	void Update()
	{
		scoreManager.AddScore(1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//var p = this.transform.position;
		int moving = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity += new Vector2(-speed, 0);
			art.localScale = new Vector3(-1, 1, 1);
			moving++;
            //p.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity += new Vector2(speed, 0);
			art.localScale = new Vector3(1, 1, 1);
			moving--;
            //p.x += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Space))
        {
            var feet2D = new Vector2(feet.transform.position.x, feet.transform.position.y);
            if (Physics2D.OverlapCircle(feet2D, 0.22f, isJumpable) && isJumping == false)
            {
                jumpTime = jumpDuration;
                isJumping = true;
            }
            //p.x += speed * Time.deltaTime;
        }
        if (rb.velocity.y <= 0 && isJumping == true)
        {
            isJumping = false;
        }
		if (jumpTime > 0)
        {
            rb.velocity += new Vector2(0, jumpPower);
            jumpTime -= Time.deltaTime;
        }

		if(isJumping)
		{
			if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
			{
				anim.SetTrigger("jumping");
			}
		}
		else if(moving != 0)
		{
			if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
			{
				anim.SetTrigger("running");
			}
		}
		else if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			anim.SetTrigger("idling");
		}

        //this.transform.position = p;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			scoreManager.SubScore(100);
			transform.position = spawn.position;
			transform.rotation = spawn.rotation;
			transform.localScale = spawn.localScale;
		}
	}
}
