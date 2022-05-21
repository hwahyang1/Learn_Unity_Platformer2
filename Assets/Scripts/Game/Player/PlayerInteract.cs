using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Namespace] _20220515_Platform2.Game.Player
 * 플레이어와 관련된 내용을 처리합니다.
 */
namespace _20220515_Platform2.Game.Player
{
	/*
	 * [Class] PlayerInteract
	 * 플레이어와 다른 GameObject의 상호작용을 관리합니다.
	 */
	public class PlayerInteract : MonoBehaviour
	{
		public bool availableInteract = false;

		[SerializeField]
		private KeyCode interactKey = KeyCode.E;

		private GameObject interactObject; // 1.주변에 인식된 2.가장 가까운 3.상호작용이 가능한 GameObject

		private void Update()
		{
			if (availableInteract & Input.GetKeyDown(interactKey))
			{
				// TODO: GameObject 상호작용 시작
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.tag == "Interactable" || collision.transform.parent.tag == "Interactable")
			{
				interactObject = collision.gameObject;
				availableInteract = true;
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.tag == "Interactable" || collision.transform.parent.tag == "Interactable")
			{
				interactObject = null;
				availableInteract = false;
			}
		}
	}
}
