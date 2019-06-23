using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy:MonoBehaviour
{
	//public PolygonCollider2D m_pickaxe_collider;
	//public BoxCollider2D m_player_collider;
	protected BoxCollider2D m_collider;

	void Start()
	{
		m_collider = GetComponent<BoxCollider2D>();
	}
}