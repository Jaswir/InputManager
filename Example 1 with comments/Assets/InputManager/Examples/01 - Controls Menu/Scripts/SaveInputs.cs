using UnityEngine;
using UnityEngine.Serialization;

namespace TeamUtility.IO.Examples
{
    public class SaveInputs : MonoBehaviour
    {
        [SerializeField]
        [FormerlySerializedAs("m_exampleID")]
        private int _exampleID;

        public void Save()
        {
            //Finds location of the appropriate input_config.xml 
            string saveFolder = PathUtility.GetInputSaveFolder(_exampleID);
            if (!System.IO.Directory.Exists(saveFolder))
                System.IO.Directory.CreateDirectory(saveFolder);

            //Other classes and methods used to do the real saving
            InputSaverXML saver = new InputSaverXML(saveFolder + "/input_config.xml");
            InputManager.Save(saver);
        }
    }
}