using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

namespace TeamUtility.IO.Examples
{
    public class ResetInputConfiguration : MonoBehaviour
    {
        [SerializeField]
        [FormerlySerializedAs("m_defaultInputs")]
        //Holds the default input 
        private TextAsset _defaultInputs;
        [SerializeField]
        [FormerlySerializedAs("m_inputConfigName")]
        private string _inputConfigName;

        public void ResetInputs()
        {
            //Get input configuration for proper input type (KeyboardAndMouse, Gamepad)
            InputConfiguration inputConfig = InputManager.GetInputConfiguration(_inputConfigName);
            InputConfiguration defInputConfig = null;

            //Reads in the default input (_defaultInputs) and puts it in defInputConfig
            using (StringReader reader = new StringReader(_defaultInputs.text))
            {
                InputLoaderXML loader = new InputLoaderXML(reader);
                defInputConfig = loader.LoadSelective(_inputConfigName);
            }


            if (defInputConfig != null)
            {
                if (defInputConfig.axes.Count == inputConfig.axes.Count)
                {
                    //Replaces the current config xml with the default xml 
                    // for the respective _inputConfigName.
                    for (int i = 0; i < defInputConfig.axes.Count; i++)
                    {
                        inputConfig.axes[i].Copy(defInputConfig.axes[i]);
                    }

                    //Sets last used text for keyDescriptions
                    InputManager.SetConfigurationDirty(_inputConfigName);
                }
                else
                {
                    Debug.LogError("Current and default input configurations don't have the same number of axes");
                }
            }
            else
            {
                Debug.LogError(string.Format(@"Default input profile doesn't contain an input configuration named '{0}'", _inputConfigName));
            }
        }
    }
}