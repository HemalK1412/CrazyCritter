using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveManager : MonoBehaviour
{

    private void Awake()
    {
        Load();
    }

    public void Save()
    {
        Debug.Log("Saving");

        FileStream file = new FileStream(Application.persistentDataPath + "/CrazyCritters.dat", FileMode.OpenOrCreate);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, DataBank.Instance.MyStats);
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
        if(DataBank.Instance == null)
        {
            Debug.LogWarning("Can't load saved data because DataBank is null");
            return;
        }
        string filepath = Application.persistentDataPath + "/CrazyCritters.dat";
        if (File.Exists(filepath))
        {
            FileStream file = new FileStream(Application.persistentDataPath + "/CrazyCritters.dat", FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataBank.Instance.MyStats = (Stats)formatter.Deserialize(file);
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

    public void WipeSaves()
    {
        string filepath = Application.persistentDataPath + "/CrazyCritters.dat";
        if(File.Exists(filepath))
        {
            File.Delete(filepath);
            Debug.Log("Save has been deleted.");
        }
        else
        {
            Debug.Log("Save file does not exist");
        }

    }
}
