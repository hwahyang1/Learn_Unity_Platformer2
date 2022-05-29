using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220515_Platform2.Game.Managers;
using _20220515_Platform2.Game.Player;

/*
 * [Namespace] _20220515_Platform2.Game.Prop
 * Prop GameObject와 관련된 내용을 처리합니다.
 */
namespace _20220515_Platform2.Game.Props
{
	/*
	 * [Class] Statue
	 * 동상의 상호작용을 관리합니다.
	 */
	public class Statue : EventProp
	{
		[SerializeField]
		private Sprite image;

		[SerializeField]
		private GameObject[] gates = new GameObject[2];

		protected override void Start()
		{
			base.Start();
		}

		public override void OnInteract(PlayerInventory inventory)
		{
			if (isUsed)
			{
				script.ShowMesssage("(평범한 여신상이다.)");
			}
			else
			{
				if (inventory.IsContainsItem(useItem))
				{
					script.ShowMesssage("(" + ItemManager.Instance.GetItemName(useItem) + "에 있는 주문을 외웠더니 문이 열리는 소리가 들렸다!)");

					for (int i = 0; i < 2; i++)
					{
						gates[i].GetComponent<SpriteRenderer>().sprite = image;
						gates[i].GetComponent<Gate>().isOpened = true;
						DestroyImmediate(gates[i].GetComponent<BoxCollider2D>());
						gates[i].transform.GetChild(0).gameObject.SetActive(false);
					}
					isUsed = true;
				}
				else
				{
					script.ShowMesssage("(평범한 여신상이다.)");
				}
			}
		}
	}
}
