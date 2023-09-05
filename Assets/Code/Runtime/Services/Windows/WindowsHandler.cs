using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Code.Runtime.Services.Windows
{
    [Serializable]
    public sealed class WindowsHandler : IWindowsHandler
    {
        private Stack<Window> stackWindows = new(4);
        private Window lastActive;

        private readonly Window[] cachedWindows;

        [Inject]
        public WindowsHandler(Window[] windows)
        {
            this.cachedWindows = windows;
        }

        public void Initialize()
        {
            for (int i = 0; i < cachedWindows.Length; i++)
            {
                cachedWindows[i].Initialize();
                cachedWindows[i].Hide();
            }
        }

        public void Show<T>() where T : Window
        {
            Debug.Log($"Trying to show window");
            for (var i = 0; i < cachedWindows.Length; i++)
            {
                Debug.Log($"Show {cachedWindows[i].name}");

                if (cachedWindows[i].GetType().Equals(typeof(T)))
                {
                    if (lastActive != null)
                    {
                        lastActive.Hide();
                        Debug.Log($"Active window is  {lastActive.name}");
                    }
                    cachedWindows[i].Show();
                    lastActive = cachedWindows[i];
                    stackWindows.Push(lastActive);
                    Debug.Log($"Add to stack {cachedWindows[i].name}");
                    break;
                }
            }
        }

        public void ShowPopUp<T>() where T : Window
        {
            Debug.Log($"Trying to show Pop Up");

            for (var i = 0; i < cachedWindows.Length; i++)
            {
                if (cachedWindows[i].GetType().Equals(typeof(T)))
                {
                    Debug.Log($"Show Pop Up {cachedWindows[i].name}");
                    cachedWindows[i].Show();
                    lastActive = cachedWindows[i];
                    stackWindows.Push(lastActive);
                    Debug.Log($"Add to stack {cachedWindows[i].name}");
                    break;
                }
            }
        }

        public void Pop()
        {
            Debug.Log($"Trying to pop start");

            if (stackWindows.TryPop(out Window window))
            {
                Debug.Log($"Trying to pop up {window.name}");
                window.Hide();

                if (stackWindows.TryPeek(out Window next))
                {
                    Debug.Log($"Trying to set up Next window {next.name}");

                    lastActive = next;
                    lastActive.Show();
                }
            }
        }
    }
}