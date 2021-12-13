using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {
	
	Player player;
	public KeyCode left;
	public KeyCode right;
	public KeyCode up;
	public KeyCode down;

	void Start () {
		player = GetComponent<Player> ();
	}

	public float LeftRight()
    {
        if (Input.GetKey(left))
        {
			return -1f;
        }
		else if (Input.GetKey(right))
        {
			return 1f;
        }

		return 0;
    }
	public float UpDown()
	{
		if (Input.GetKey(down))
		{
			return -1f;
		}
		else if (Input.GetKey(up))
		{
			return 1f;
		}

		return 0;
	}
	void Update () {
		//Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 directionalInput = new Vector2 (LeftRight(), UpDown());
		player.SetDirectionalInput (directionalInput);

		if (Input.GetKeyDown (up)) {
			player.OnJumpInputDown ();
		}
		if (Input.GetKeyUp (up)) {
			player.OnJumpInputUp ();
		}
	}
	public KeyCode GetKeyJump()
    {
		return up;
    }
}
