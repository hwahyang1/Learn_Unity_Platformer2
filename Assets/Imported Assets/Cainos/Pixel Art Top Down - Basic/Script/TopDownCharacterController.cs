using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using _20220515_Platform2.Game.Managers;

namespace Cainos.PixelArtTopDown_Basic
{
	public class TopDownCharacterController : MonoBehaviour
	{
		public float speed;

		[SerializeField]
		private AudioManager manager;

		private Animator animator;

		private float nowCooldown = 0f;
		private float soundCooldown = 0.5f;

		private void Start()
		{
			animator = GetComponent<Animator>();
			manager.PlayBackground();
		}


		private void Update()
		{
			Vector2 dir = Vector2.zero;
			if (Input.GetKey(KeyCode.A))
			{
				dir.x = -1;
				animator.SetInteger("Direction", 3);
			}
			else if (Input.GetKey(KeyCode.D))
			{
				dir.x = 1;
				animator.SetInteger("Direction", 2);
			}

			if (Input.GetKey(KeyCode.W))
			{
				dir.y = 1;
				animator.SetInteger("Direction", 1);
			}
			else if (Input.GetKey(KeyCode.S))
			{
				dir.y = -1;
				animator.SetInteger("Direction", 0);
			}

			dir.Normalize();
			animator.SetBool("IsMoving", dir.magnitude > 0);

			if (animator.GetBool("IsMoving"))
			{
				if (nowCooldown >= soundCooldown)
				{
					nowCooldown = 0f;
					manager.PlayFootsteps();
				}
				else
				{
					nowCooldown += Time.deltaTime;
				}
			}
			else
			{
				nowCooldown = soundCooldown;
			}

			GetComponent<Rigidbody2D>().velocity = speed * dir;
		}
	}
}
