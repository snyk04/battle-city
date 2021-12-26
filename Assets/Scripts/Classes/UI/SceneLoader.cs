using UnityEngine.SceneManagement;

namespace BattleCity.UI
{
    public class SceneLoader
    {
        public void LoadScene(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }
    }
}