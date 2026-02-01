using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using OWML.Common;
using OWML.ModHelper;

namespace TeleportAndScenes
{
    public class TeleportAndScenes : ModBehaviour
    {
        private Keyboard kb;

        public void Start()
        {
            kb = Keyboard.current;
            ModHelper.Console.WriteLine("Teleport Mod loaded!", MessageType.Success);
        }

        public void Update()
        {

            if (IsKeyComboPressed(Key.F4)) LoadEyeScene();
            if (IsKeyComboPressed(Key.F5)) LoadCreditsScene();
            if (IsKeyComboPressed(Key.F6)) LoadEyeCreditsScene();
            if (IsKeyComboPressed(Key.F3)) LoadMainMenuScene();
            if (IsKeyComboPressed(Key.F2)) LoadSolarSystemScene();
        }

        private bool IsKeyComboPressed(params Key[] keys)
        {
            if (kb == null) return false;

            // All must be pressed this frame
            return keys.All(k => kb[k].isPressed);
        }

        private void LoadEyeScene()
        {
            LoadManager.LoadScene(OWScene.EyeOfTheUniverse, LoadManager.FadeType.ToBlack);
        }

        private void LoadCreditsScene()
        {
            LoadManager.LoadScene(OWScene.Credits_Fast, LoadManager.FadeType.ToBlack);
        }

        private void LoadEyeCreditsScene()
        {
            LoadManager.LoadScene(OWScene.Credits_Final, LoadManager.FadeType.ToBlack);
        }

        private void LoadMainMenuScene()
        {
            LoadManager.LoadScene(OWScene.TitleScreen, LoadManager.FadeType.ToBlack);
        }

        private void LoadSolarSystemScene()
        {
            LoadManager.LoadScene(OWScene.SolarSystem, LoadManager.FadeType.ToBlack);
        }  
    }
}
