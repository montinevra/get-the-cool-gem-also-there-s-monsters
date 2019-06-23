using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Player m_player;
	Vector2 m_force;
	bool m_up_is_pressed = false;
	bool m_attack_is_pressed = false;

    void Update()
    {
		Vector2 force;

		force.x = Input.GetAxis("Horizontal");
		force.y = 0;
		if (Input.GetAxis("Vertical") > 0 && !m_up_is_pressed)
		{
			m_up_is_pressed = true;
			m_player.jump();
		}
		if (Input.GetAxis("Vertical") == 0)
		{
			m_up_is_pressed = false;
		}
		/*
		if (Input.GetKeyDown(KeyCode.Space))
		{
			m_player.attack();
		}
		//*/
		if (Input.GetAxis("Fire1") > 0 && !m_attack_is_pressed)
		{
			m_attack_is_pressed = true;
			m_player.attack();
		}
		if (Input.GetAxis("Fire1") == 0)
		{
			m_attack_is_pressed = false;
		}

		m_player.move(force);
	}
}
