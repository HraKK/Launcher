using System.Collections.Generic;
using Application.GUISysytem.Interface;
using UnityEngine;

public class GUISystem : IGUISystem
{
    private List<IGUIView> guiViews = new List<IGUIView>();

    public void AddView(IGUIView guiView)
    {
        guiViews.Add(guiView);
    }

    public void RemoveView(IGUIView guiView)
    {
        guiViews.Remove(guiView);
    }

    public void Draw()
    {
        foreach (var guiView in guiViews)
        {
            guiView.Draw();
        }
    }
}
