using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220515_Platform2.Game.Props;

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
		private string interactTag = "Interactable";

		[SerializeField]
		private KeyCode interactKey = KeyCode.E;

		private GameObject interactObject; // 1.주변에 인식된 2.가장 가까운 3.상호작용이 가능한 GameObject

		private PlayerInventory inv;

		private void Start()
		{
			inv = GetComponent<PlayerInventory>();
		}

		private void Update()
		{
			if (availableInteract & Input.GetKeyDown(interactKey))
			{
				EventProp prop = interactObject.GetComponent<EventProp>();
				if (prop != null)
				{
					prop.OnInteract(inv);
				}
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			ChangeInteractState(interactTag, collision, true);
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			ChangeInteractState(interactTag, collision, false);
		}

		private void ChangeInteractState(string tag, Collider2D collision, bool isAvailable)
		{
			if (collision.tag == tag || collision.transform.parent.tag == tag)
			{
				availableInteract = isAvailable;
				interactObject = isAvailable ? collision.gameObject : null;
			}
		}
	}
}
