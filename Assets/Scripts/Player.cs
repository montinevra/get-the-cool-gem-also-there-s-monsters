using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float m_move_speed = 1f;
	public float m_jump_speed = 1f;
	public Vector2 m_max_speed = new Vector2(10, 10);
	Transform m_transform;
	SpriteRenderer m_sprite;
	Animator m_animator;
	Rigidbody2D m_rb;
	BoxCollider2D m_collider;
	BoxCollider2D m_feet_collider;
	PolygonCollider2D m_pickaxe_collider;
	public CompositeCollider2D m_ground_collider;
	public TextController m_text_controller;

	void Start()
    {
		m_rb = GetComponent<Rigidbody2D>();
		m_collider = GetComponents<BoxCollider2D>()[0];
		m_feet_collider = GetComponents<BoxCollider2D>()[1];
		m_transform = GetComponent<Transform>();
		m_sprite = GetComponent<SpriteRenderer>();
		m_animator = GetComponent<Animator>();
		m_pickaxe_collider = GetComponentInChildren<PolygonCollider2D>();
		m_pickaxe_collider.enabled = false;
		//print(m_collider.name);
		//print(m_feet_collider.name);
	}

	void Update()
	{
		if (m_rb.velocity.x > 0)
		{
			m_transform.localScale = new Vector3(1, 1, 1);
		}
		else if (m_rb.velocity.x < 0)
		{
			m_transform.localScale = new Vector3(-1, 1, 1);
		}
		m_animator.SetFloat("speed", Mathf.Abs(m_rb.velocity.x));
	}

	void FixedUpdate()
    {
		Vector2 velocity;

		velocity = m_rb.velocity;
		velocity.x = limit_velocity(velocity.x, m_max_speed.x);
		velocity.y = limit_velocity(velocity.y, m_max_speed.y);
		if (velocity.y >= 0)
		{
			m_rb.gravityScale = 2;
		}
		else
		{
			m_rb.gravityScale = 4;
		}
		m_rb.velocity = velocity;
	}

	float limit_velocity(float t_vel, float t_limit)
	{
		if (Mathf.Abs(t_vel) > t_limit)
		{
			t_vel = t_limit * Mathf.Sign(t_vel);
		}
		return (t_vel);
	}

	public void move(Vector2 t_force)
	{
		t_force.x *= m_move_speed;

		if (!m_feet_collider.IsTouching(m_ground_collider))
		{
			t_force.x *= .5f;
		}
		m_rb.AddForce(t_force);
	}

	public void jump()
	{
		if (m_feet_collider.IsTouching(m_ground_collider))
		{
			m_rb.AddForce(new Vector2(0, m_jump_speed));
		}
	}

	public void attack()
	{
		m_animator.SetBool("is_attacking", true);
		m_pickaxe_collider.enabled = true;
	}

	public void attack_end()
	{
		m_animator.SetBool("is_attacking", false);
		m_pickaxe_collider.enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D t_collision)
	{
		if (t_collision.tag == "Enemy")
		{
			if (m_collider.IsTouching(t_collision) || m_feet_collider.IsTouching(t_collision))
			{
				//print(t_collision.tag);                                             //debug
				SceneManager.LoadScene("SampleScene");
			}
			else if (m_pickaxe_collider.IsTouching(t_collision))
			{
				Destroy(t_collision.gameObject);
			}
		}
		else if(t_collision.tag == "Pickup")
		{
			Destroy(t_collision.gameObject);
		}
		else if (t_collision.tag == "Message")
		{
			//print(t_collision.name);                    ////debug
			m_text_controller.update_text(t_collision.name);
		}

		//Destroy(gameObject);
	}
}
