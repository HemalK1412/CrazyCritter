using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveManager : MonoBehaviour
{
    private DataBank databank;

    private void Awake()
    {
        databank = GameObject.FindAnyObjectByType<DataBank>();
        Load();
    }

    public void Save()
    {
        Debug.Log("Saving");

        FileStream file = new FileStream(Application.persistentDataPath + "/CrazyCritters.dat", FileMode.OpenOrCreate);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, databank.MyStats);
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

        string filepath = Application.persistentDataPath + "/CrazyCritters.dat";
        if (File.Exists(filepath))
        {
            FileStream file = new FileStream(Application.persistentDataPath + "/CrazyCritters.dat", FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                databank.MyStats = (Stats)formatter.Deserialize(file);
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
        else
        {
            Debug.Log("Save file does not exist");
        }
    }
}
