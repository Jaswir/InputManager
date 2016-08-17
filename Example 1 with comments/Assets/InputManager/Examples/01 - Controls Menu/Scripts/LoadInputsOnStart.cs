using UnityEngine;

namespace TeamUtility.IO.Examples
{
    public class LoadInputsOnStart : MonoBehaviour
    {
        [SerializeField]
        private int m_exampleID;

        private void Awake()
        {
            //Gets path of data
            string savePath = PathUtility.GetInputSaveFolder(m_exampleID) + "/input_config.xml";

            //InputManager loads the input_configurations
            if (System.IO.File.Exists(savePath))
            {
                InputLoaderXML loader = new InputLoaderXML(savePath);
                InputManager.Load(loader);
            }
        }
    }
}