using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomManager : MonoBehaviour
{
    [Serializable]
    public class BossRoom
    {
        public int roomsToEncounter;
        public Transform bossRoomTeleport;
    }

    [SerializeField] private List<BossRoom> _bossRooms;
    [SerializeField] private Vector3 playerStartPos;

    private void OnEnable()
    {
        EventManager.instance.OnChangeRoom += TeleportToBoss;
    }

    private void OnDisable()
    {
        EventManager.instance.OnChangeRoom -= TeleportToBoss;
    }

    private void TeleportToBoss()
    {
        foreach (var bossRoom in _bossRooms)
        {
            if (RoomCurrency.Instance.roomCounter == bossRoom.roomsToEncounter)
            {
                playerStartPos = PlayerManager.Instance.playerPosition;
                PlayerManager.Instance.playerTransform.position = bossRoom.bossRoomTeleport.position;
                StartCoroutine(TemporaryTestRoutine());
            }
        }
    }

    //FOR TESTING TEMPORARY. When boss is dead this triggers later.
    private IEnumerator TemporaryTestRoutine()
    {
        yield return new WaitForSeconds(10f);
        PlayerManager.Instance.playerTransform.position = playerStartPos;
    }
}
