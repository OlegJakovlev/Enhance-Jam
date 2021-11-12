using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithdrawItems : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "small")
        {
            player.IncrementOnlyScore(5);
            Destroy(collider.transform.parent.gameObject);
        }
        if (collider.tag == "big")
        {
            player.IncrementOnlyScore(15);
            Destroy(collider.transform.parent.gameObject);
        }
        if (collider.tag == "enormous")
        {
            player.IncrementOnlyScore(35);
            Destroy(collider.transform.parent.gameObject);
        }
    }
}
