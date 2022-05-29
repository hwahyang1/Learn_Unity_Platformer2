using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220515_Platform2.Game.Player;

/*
 * [Namespace] _20220515_Platform2.Game.Prop
 * Prop GameObject와 관련된 내용을 처리합니다.
 */
namespace _20220515_Platform2.Game.Props
{
	/*
	 * [Class] Gate
	 * 문의 상호작용을 관리합니다.
	 */
	public class Gate : EventProp
	{
		[HideInInspector]
		public bool isOpened = false;

		public override void OnInteract(PlayerInventory inventory)
		{
			if (!isOpened)
			{
				script.ShowMesssage("(문이 잠겨있다... 장치를 이용하여 열 수 있을 것 같다.)");
			}
		}
	}
}
