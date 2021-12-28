using UnityEngine;

namespace BattleCity.UI
{
    public class SceneLoaderComponent : MonoBehaviour
    {
        public SceneLoader SceneLoader { get; private set; }

        private void Awake()
        {
            SceneLoader = new SceneLoader();
        }

        public void LoadScene(int sceneId)
        {
            SceneLoader.LoadScene(sceneId);
        }
        public void LoadSceneAsync(int sceneId)
        {
            SceneLoader.LoadSceneAsync(sceneId);
        }
    }
}