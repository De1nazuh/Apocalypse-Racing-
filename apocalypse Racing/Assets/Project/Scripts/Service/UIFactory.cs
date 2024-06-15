using Game.UI;
using UnityEngine;
namespace Game
{
    public class UIFactory : MonoBehaviour
    {
        [SerializeField] private UIBase[] _alUIs;

        private void Start () 
        {
            GetUI<MainMenuUI>();
        }

        public UIBase GetUI<SomeUI>()
        {
            UIBase result = null;

            foreach (UIBase ui in _alUIs)
            {
                if (ui is SomeUI == true)
                {
                    result =Instantiate(ui);
                }
            }
            return result;
        }
    }
}
