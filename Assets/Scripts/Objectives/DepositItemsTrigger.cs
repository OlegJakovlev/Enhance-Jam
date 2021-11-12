using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositItemsTrigger : MonoBehaviour
{
    private Player playerObject = null;

    [SerializeField] private Transform _spawner;

    [SerializeField] private GameObject _smallCube;
    [SerializeField] private GameObject _bigCube;
    [SerializeField] private GameObject _enormousCube;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            playerObject = player;
            StartCoroutine(Spawner());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerObject = null;
    }

    private IEnumerator Spawner()
    {
        while (playerObject != null)
        {
            StartCoroutine(SpawnCube(playerObject.GetCube()));
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator SpawnCube(string cube)
    {
        GameObject minifiedObject = null;

        if (cube == "Small")
        {
            minifiedObject = Instantiate(_smallCube, _spawner);
        }
        else if (cube == "Big")
        {
            minifiedObject = Instantiate(_bigCube, _spawner);
        }
        else if (cube == "Enormous")
        {
            minifiedObject = Instantiate(_enormousCube, _spawner);
        }

        if (minifiedObject)
        {
            yield return new WaitForSeconds(0.1f);

            MoveMinifiedCube script = minifiedObject.GetComponent<MoveMinifiedCube>();
            if (script)
                script.enabled = true;
        }

        yield break;
    }
}
