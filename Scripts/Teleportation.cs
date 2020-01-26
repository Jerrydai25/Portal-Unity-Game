using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
	public Transform exit;
    /* where you exit */
	public string otherPortalTag;
    /* name of the other portal */
	public GameObject otherPortal;
    /* concreate */
    /* fields: describe charactoristics */

	private void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			otherPortal = GameObject.FindGameObjectWithTag(otherPortalTag);
			if (otherPortal != null)
			{
				coll.transform.position = otherPortal.GetComponent<Teleportation>().exit.position;
			}
		}
	}    
}
