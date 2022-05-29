using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220515_Platform2.Game.UI;
using _20220515_Platform2.Game.Player;

/*
 * [Namespace] _20220515_Platform2.Game.Prop
 * Prop GameObject와 관련된 내용을 처리합니다.
 */
namespace _20220515_Platform2.Game.Props
{
	/*
	 * [Class] BlockedStones
	 * 막혀있는 돌에 대한 상호작용을 관리합니다.
	 */
	public class BlockedStones : EventProp
	{
		public override void OnInteract(PlayerInventory inventory)
		{
			script.ShowMesssage("(움직이지 않는다.)");
		}
	}
}