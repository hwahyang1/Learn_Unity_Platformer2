using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220515_Platform2.Game.Managers;
using _20220515_Platform2.Game.Player;
using _20220515_Platform2.Game.UI;

/*
 * [Namespace] _20220515_Platform2.Game.Prop
 * Prop GameObject와 관련된 내용을 처리합니다.
 */
namespace _20220515_Platform2.Game.Props
{
	/*
	 * [Class - Parent(Abstract)] EventProp
	 * 이벤트가 발생할 Prop GameObject의 자식 Class를 관리합니다.
	 */
	public abstract class EventProp : MonoBehaviour
	{
		[SerializeField]
		protected bool isUsed = false; // 다중사용 방지여부

		[SerializeField]
		protected ItemCode useItem = ItemCode.None; // 상호작용 할 때 사용할 아이템

		[SerializeField]
		protected List<ItemCode> giveItems = new List<ItemCode>(); // 상호작용 후 지급할 아이템

		protected ScriptView script;

		protected virtual void Start()
		{
			// GameObject.FindObject(s)OfType<>와 달리 프로젝트 전체를 뒤짐 (비활성화 된 애들도 검색 가능)
			ScriptView[] objs = Resources.FindObjectsOfTypeAll<ScriptView>();
			script = objs[0];
		}

		protected void GiveAllItems(PlayerInventory inventory)
		{
			for (int i = 0; i < giveItems.Count; i++)
			{
				inventory.GiveItem(giveItems[i]);
			}

			Debug.LogWarning("플레이어가 상호작용해서 모든 아이템을 지급하였습니다.");
		}

		protected void UseItem(PlayerInventory inventory)
		{
			inventory.TakeItem(useItem);
			Debug.LogWarning("플레이어가 상호작용을 위해 " + ItemManager.Instance.GetItemName(useItem) + "(을)를 사용하였습니다.");
		}

		public abstract void OnInteract(PlayerInventory inventory);
	}
}
