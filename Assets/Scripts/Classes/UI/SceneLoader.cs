using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BattleCity.UI
{
    public class SceneLoader
    {
        private AsyncOperation _asyncLoad;

        public void LoadScene(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }
        public void LoadSceneAsync(int sceneId)
        {
            AsyncLoading(sceneId);
        }
        
        private async Task AsyncLoading(int sceneId)
        {
            _asyncLoad = SceneManager.LoadSceneAsync(sceneId);
            
            while (!_asyncLoad.isDone)
            {
                await Task.Yield();
            }
        }
    }
}