using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavebug:Enemy
{
	public float m_speed = 1f;
	public CompositeCollider2D m_ground_collider;
	Transform				 m_transform;
	Vector3					 m_scale = new Vector3(1, 1, 1);
	BoxCollider2D			m_wall_detetector;
	int						m_direction = -1;

	void Start()
	{
		m_transform = GetComponent<Transform>();
		m_wall_detetector = GetComponents<BoxCollider2D>()[1];
		m_collider = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		Vector3 pos;

		pos = m_transform.position;
		pos.x += m_speed * m_direction * Time.deltaTime;
		m_transform.position = pos;
	}

	void FixedUpdate()
	{
		if (m_wall_detetector.IsTouching(m_ground_collider))
		{
			m_scale.x *= -1;
			m_transform.localScale = m_scale;
			m_direction *= -1;
		}
	}
}