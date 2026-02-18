using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Kits.Utils.Scripts
{
    public static class SceneManagerUtils
    {
        public static void LoadSceneByName(string name)
        {
            var introSceneIdx = SceneUtility.GetBuildIndexByScenePath($"Assets/Scenes/{name}.unity");
            if (introSceneIdx > 0)
            {
                SceneManager.LoadSceneAsync(introSceneIdx);
            }
            else
            {
                Debug.Log($"The scene is not added to the build profile");
            }
        }
    }
}
