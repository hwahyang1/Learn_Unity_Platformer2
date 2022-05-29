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
	 * [Class] TriggerGraveStone
	 * 비석의 상호작용을 관리합니다.
	 */
	public class TriggerGraveStone : EventProp
	{
		public override void OnInteract(PlayerInventory inventory)
		{
			if (isUsed)
			{
				script.ShowMesssage("(비석의 글씨가 사라졌다.)");
			}
			else
			{
				if (inventory.IsContainsItem(useItem))
				{
					GameObject.Find("Layer3_InteractableStone").SetActive(false);
					script.ShowMesssage("(" + ItemManager.Instance.GetItemName(useItem) + "를 들고 비석에 써져 있는 글씨를 읽자 어딘가에서 큰 소리가 났다!)\n\n" + ItemManager.Instance.GetItemName(useItem) + "가 부러졌다..");
					UseItem(inventory);
					isUsed = true;
				}
				else
				{
					script.ShowMesssage("(비석에 무언가가 써져있다. 지팡이가 필요 해 보인다.)");
				}
			}
		}
	}
}
