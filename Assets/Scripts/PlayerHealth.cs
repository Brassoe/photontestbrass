using UnityEngine;

public class PlayerHealth : Bolt.EntityBehaviour<ICustomCubeState>
{
    public int localHealth;

    public override void Attached()
    {
        if (entity.IsOwner)
        {
            state.Health = localHealth;
        }
        state.AddCallback("Health", HealthCallback);
    }

    private void HealthCallback()
    {
        localHealth = state.Health;

        if (localHealth <= 0)
        {
            BoltNetwork.Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (entity.IsOwner)
            {
                //state.Health -= 1;
            }
        }
    }

}
