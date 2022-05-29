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
	 * [Class] TriggerLantern
	 * 랜턴의 상호작용을 관리합니다.
	 */
	public class TriggerLantern : EventProp
	{
		public override void OnInteract(PlayerInventory inventory)
		{
			if (isUsed)
			{
				script.ShowMesssage("(안으로 들어간 보석은 아무리 노력해도 빠지지 않는다.)");
			}
			else
			{
				if (inventory.IsContainsItem(useItem))
				{
					GameObject.Find("Layer2_InteractableStones").SetActive(false);
					script.ShowMesssage("(" + ItemManager.Instance.GetItemName(useItem) + "을 안으로 밀어넣자 어디선가 큰 소리가 났다!)");
					UseItem(inventory);
					isUsed = true;
				}
				else
				{
					script.ShowMesssage("(무언가 넣을 수 있는 공간이 있다. 주변에 있지 않을까?)");
				}
			}
		}
	}
}
