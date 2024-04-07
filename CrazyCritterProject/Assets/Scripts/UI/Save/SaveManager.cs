using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveManager : MonoBehaviour
{
    private player player;

    private void Awake()
    {
        player = GameObject.FindAnyObjectByType<player>();
        Load();
    }

    public void Save()
    {
        Debug.Log("Saving");

        FileStream file = new FileStream(Application.persistentDataPath + "/CrazyCritters.dat", FileMode.OpenOrCreate);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, player.MyStats);
        }

        catch (SerializationException error)
        {
            Debug.LogError("Issue with serializing data: " + error.Message);
        }

        finally
        {
            file.Close();
        }
    }

    public void Load()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/CrazyCritters.dat", FileMode.Open);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            player.MyStats = (Stats)formatter.Deserialize(file);
        }
        catch (SerializationException error)
        {
            Debug.LogError("Error with deserializing data: " + error.Message);
        }
        finally
        {
            file.Close();
        }

    }
}
