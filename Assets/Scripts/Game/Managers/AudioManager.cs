using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Namespace] _20220515_Platform2.Game.Managers
 * 
 */
namespace _20220515_Platform2.Game.Managers {
	/*
	* [Class] AudioManager
	* 소리의 재생을 관리합니다.
	*/
	[RequireComponent(typeof(AudioSource))]
	public class AudioManager : MonoBehaviour
	{
		[Header("재생할 소리 파일")]
		[SerializeField]
		private List<AudioClip> footSound = new List<AudioClip>(); // 캐릭터가 움질일 때 나는 발소리

		[SerializeField]
		private AudioClip backgroundSound; // 자연소리

		[SerializeField]
		[Range(0f, 1f)]
		private float volume = 1f;

		private AudioSource source;

		private void Start() {
			source = GetComponent<AudioSource>();
		}

		public void PlayFootsteps()
		{
			int random = Random.Range(0, footSound.Count);

			source.PlayOneShot(footSound[random], volume);
		}

		public void PlayBackground()
		{
			source.PlayOneShot(backgroundSound, volume);
		}
	}
}
