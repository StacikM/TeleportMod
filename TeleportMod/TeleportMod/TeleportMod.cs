using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using OWML.Common;
using OWML.ModHelper;
using UnityEngine.SceneManagement;

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
            SceneManager.sceneLoaded += OnSceneLoaded;
            LoadManager.LoadSceneAsync(OWScene.EyeOfTheUniverse, true, LoadManager.FadeType.ToBlack); // dear person at mobius studio that wrote the LoadManager and didnt make so it returns an AsyncOperation i hate you (with much of love)
        }

        void OnSceneLoaded(Scene tuntuntunsahur, LoadSceneMode mode)
        {
            if (tuntuntunsahur.name == "EyeOfTheUniverse")
            {
                ModHelper.Events.Unity.FireInNUpdates(ForceSuitUp, 60);
            } else { /* we don't care */ }
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

        private void ForceSuitUp()
        {
            var suit = Locator.GetPlayerSuit();
            if (suit == null || suit.IsWearingSuit()) return;

            // (isTrainingSuit, instantSuitUp, putOnHelmet)
            suit.SuitUp(false, true, true);
        }
    }
}
