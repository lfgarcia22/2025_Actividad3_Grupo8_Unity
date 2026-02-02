using Assets.Kits.Utils.Scripts;
using UnityEngine;

namespace Assets.Kits.LevelDesign.ICommon.Scripts
{
    public class MainMenuController : MonoBehaviour
    {

        private GameObject continueButton;

        void Awake()
        {
            // TODO: Add logic to verify if there's a saved checkpoint
            continueButton = GameObject.FindGameObjectWithTag("UI_ContinueCheckpoint");
            continueButton.SetActive(false);
        }

        public void StartGame()
        {
            SceneManagerUtils.LoadSceneByName("01_Introduction");
        }

        public void ContinueFromCheckpoint()
        {
            // TODO: Apply logic to load game from a saved checkpoint
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
