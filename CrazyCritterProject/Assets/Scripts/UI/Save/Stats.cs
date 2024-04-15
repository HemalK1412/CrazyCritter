using UnityEngine;

[System.Serializable]
public struct SerializableVector3
{
    public float x, y, z;
    
    public Vector3 GetPos()
    {
        return new Vector3(x, y, z);
    }
}

[System.Serializable]
public class Stats
{
    public int DayCount;
    public int Nuts;

    public int MinigamesCompleted;

    public SerializableVector3 p_Position;
    public SerializableVector3 Bouncer_Position;

    // If any power ups have been collected. Check for variable == true and enable the powerup
    public bool Speedpowerups;
    
}
