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

		public abstract void OnInteract(PlayerInventory inventory);
	}
}
