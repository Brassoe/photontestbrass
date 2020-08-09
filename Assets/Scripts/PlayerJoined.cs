using UnityEngine;

public class PlayerJoined : Bolt.EntityBehaviour<ICustomCubeState>
{

    public Camera entityCamera;
    public override void Attached()
    {
        var evnt = PlayerJoinedEvent.Create();
        evnt.Message = "Hello there";
        evnt.Send();

        //if (entity.IsOwner)
        //{
        //    entityCamera.gameObject.SetActive(true);
        //}
    }

    private void Update()
    {
        if (entity.IsOwner && entityCamera.gameObject.activeInHierarchy == false)
        {
            entityCamera.gameObject.SetActive(true);
        }
    }

}
