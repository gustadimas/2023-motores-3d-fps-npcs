using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    public GameObject npc_obj;
    public float npcMoveSpeed = 20f;

    private void Start()
    {
        StartCoroutine(NpcSpawn());
    }

    IEnumerator NpcSpawn()
    {
        while (true)
        {
            var positionX = Random.Range(-15, 15);
            var positionZ = Random.Range(-15, 15);

            GameObject npcInstance = Instantiate(npc_obj, new Vector3(positionX, 1f, positionZ), Quaternion.identity);
            Rigidbody npcRigidbody = npcInstance.GetComponent<Rigidbody>();

            if (npcRigidbody != null)
            {
                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
                npcRigidbody.AddForce(randomDirection * npcMoveSpeed, ForceMode.Impulse);
            }

            yield return new WaitForSeconds(2f);
        }
    }
}
