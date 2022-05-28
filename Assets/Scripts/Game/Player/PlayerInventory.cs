using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using _20220515_Platform2.Game.Managers;

/*
 * [Namespace] _20220515_Platform2.Game.Player
 * 플레이어와 관련된 내용을 처리합니다.
 */
namespace _20220515_Platform2.Game.Player
{
	/*
	 * [Class] PlayerInventory
	 * 플레이어의 인벤토리를 관리합니다.
	 */
	public class PlayerInventory : MonoBehaviour
	{
		// 플레이어의 인벤토리를 관리
		// - [v] 아이템 주기
		// - [v] 아이템 뺏기
		// - [v] 아이템 초기화(모두 뺏기)
		// - [x] 아이템을 가지고 있는지 확인 (List에 존재함)
		// - [v] 가지고 있는 아이템을 화면에 표시

		public GameObject invRoot; // 인벤토리 UI의 부모 GameObject

		private List<ItemCode> slotItems = new List<ItemCode>(); // 플레이어가 가지고 있는 아이템 정보

		private List<GameObject> slots = new List<GameObject>(); // 플레이어의 인벤토리 GameObject

		private void Start()
		{
			for (int i = 0; i < invRoot.transform.childCount; i++)
			{
				slots.Add(invRoot.transform.GetChild(i).gameObject);
				slotItems.Add(ItemCode.None);
			}
		}

		private void Update()
		{
			// 아이템 데이터가 업데이트 될 때 화면에 업데이트된 내용을 적용
			for (int i = 0; i < slotItems.Count; i++)
			{
				Image itemImage = slots[i].transform.GetChild(0).GetComponent<Image>();

				if (slotItems[i] == ItemCode.None)
				{
					itemImage.sprite = null;
					itemImage.enabled = false;
				}
				else
				{
					itemImage.sprite = ItemManager.Instance.GetItemSprite(slotItems[i]);
					itemImage.enabled = true;
				}
			}
		}

		public void GiveItem(ItemCode code)
		{
			string itemName = ItemManager.Instance.GetItemName(code);

			if (!slotItems.Contains(code))
			{
				for (int i = 0; i < slots.Count; i++)
				{
					if (slotItems[i] == ItemCode.None)
					{
						slotItems[i] = code;
						Debug.Log("플레이어에게 " + itemName + "(을)를 지급하였습니다.");
						break;
					}

					if (i == (slots.Count - 1))
					{
						Debug.LogWarning("플레이어의 인벤토리에 빈 칸이 없어 " + itemName + "(을)를 지급할 수 없습니다!");
					}
				}
			}
			else
			{
				Debug.LogWarning("플레이어가 이미 " + itemName + "(을)를 가지고 있어서 아이템을 지급하지 않습니다.");
			}
		}
	
		public void TakeItem(ItemCode code)
		{
			string itemName = ItemManager.Instance.GetItemName(code);

			if (slotItems.Contains(code))
			{
				for (int i = 0; i < slotItems.Count; i++)
				{
					if (slotItems[i] == code)
					{
						slotItems[i] = ItemCode.None;
						Debug.Log("플레이어로부터 " + itemName + "(을)를 회수하였습니다.");
						break;
					}
				}
			}
			else
			{
				Debug.LogWarning("플레이어가 " + itemName + "(을)를 가지고 있지 않아 아이템을 회수할 수 없습니다.");
			}
		}

		public void TakeAllItems()
		{
			for (int i = 0; i < slotItems.Count; i++)
			{
				slotItems[i] = ItemCode.None;
			}

			Debug.Log("플레이어의 인벤토리를 초기화하였습니다.");
		}
	}
}
