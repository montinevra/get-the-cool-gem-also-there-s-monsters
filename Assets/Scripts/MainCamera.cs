using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
	public Player m_player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 new_position;

		new_position = m_player.transform.position;
		new_position.z = -10;
		transform.position = new_position;
	
    }
}
