using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
	public float m_speed = 1f;
	public CompositeCollider2D m_ground_collider;
	Transform m_transform;
	BoxCollider2D m_ceiling_detetector;
	BoxCollider2D m_floor_detetector;
	int m_direction = -1;

	void Start()
    {
		m_transform = GetComponent<Transform>();
		m_collider = GetComponent<BoxCollider2D>();
		m_ceiling_detetector = GetComponents<BoxCollider2D>()[1];
		m_floor_detetector = GetComponents<BoxCollider2D>()[2];
	}

	void Update()
    {
		Vector3 pos;

		pos = m_transform.position;
		pos.y += m_speed * m_direction * Time.deltaTime;
		m_transform.position = pos;
	}

	void FixedUpdate()
	{
		if (m_ceiling_detetector.IsTouching(m_ground_collider) && m_direction == 1)
		{
			m_direction = -1;
		}
		else if (m_floor_detetector.IsTouching(m_ground_collider) && m_direction == -1)
		{
			m_direction = 1;
		}
	}
}
