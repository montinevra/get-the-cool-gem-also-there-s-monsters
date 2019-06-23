using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
	public Text m_message_text;
	readonly string m_cavebug_message = "oh no a cave bug i'll kill with with my trusy pickaxe leftctrl";
	readonly string m_spikes_message = "shouldn't touch spikes without consent";
	readonly string m_bat_message = "goddamn bats i'll kill them too";
	readonly string m_gem_message = "that's not the cool gem oh well i'll get it anyway";
	readonly string m_coolgem_message = "got the cool gem i'll go home now";

	// Start is called before the first frame update
	void Start()
    {
		m_message_text.text = "there's a cool gem in this cave i'm gonna get it";
    }

    // Update is called once per frame
    public void update_text(string t_name)
    {
		switch (t_name)
		{
		case "CavebugMessage":
			m_message_text.text = m_cavebug_message;
			break;
		case "SpikesMessage":
			m_message_text.text = m_spikes_message;
			break;
		case "BatMessage":
			m_message_text.text = m_bat_message;
			break;
		case "NoMessage":
		case "NoMessage (1)":
			m_message_text.text = "";
			break;
		case "GemMessage":
			m_message_text.text = m_gem_message;
			break;
		case "CoolgemMessage":
			m_message_text.text = m_coolgem_message;
			break;
		}
	}
}
