using Godot;
using System;
using System.Runtime.CompilerServices;

public static partial class NodeExtension
{
    public static T RenameToType<T>(this T node) where T : Node
    {
        node.Name = typeof(T).Name;

        return node;
    }

    public static TComponent GetComponent<TComponent>(this Node node) where TComponent : Node {
        return node.GetNode<TComponent>(typeof(TComponent).Name);
    }

    public static TComponent AddComponent<TComponent>(this Node node, TComponent component) where TComponent : Node
    {
        component.RenameToType();

        node.AddChild(component);

        return component;
    }
}
