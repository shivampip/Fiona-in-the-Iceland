using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This matches the cloth movement to a character, the clothing must be inside the character.
 **/
public class AttachToBody : MonoBehaviour
{

	void Start ()
	{
		int i = 0;
		Transform rootParent = transform.root.transform;
		GameObject target;
		Transform[] bodyBones = null;
		for (i = 0; i < rootParent.GetChildCount (); i++)
		{
			target = rootParent.GetChild (i).gameObject;
			if (target.GetComponent<SkinnedMeshRenderer> () != null)
			{
				bodyBones = target.GetComponent<SkinnedMeshRenderer> ().bones;
				break;
			}
		}

		if (bodyBones == null) 
		{
			Debug.LogError ("Wrong parent body.");
			return;
		}

		GameObject Attachment;

		for(i = 0; i < transform.GetChildCount(); i++)
		{
			Attachment = transform.GetChild(i).gameObject;
			if (Attachment.GetComponent<SkinnedMeshRenderer> () != null) 
			{
				Attachment.GetComponent<SkinnedMeshRenderer> ().bones = bodyBones;
			}
			
		}
	}
}
