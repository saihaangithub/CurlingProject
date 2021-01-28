
using Godot;
using System;

public class Rink : Node2D
{
    private PackedScene rockScene;

    public override void _Ready()
    {
        rockScene = GD.Load<PackedScene>("res://Player.tscn");
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        // on click, spawn bullet
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (!mouseEvent.Pressed && mouseEvent.ButtonIndex == (int)ButtonList.Left)
            {
                Player rock = (Player)rockScene.Instance();
                rock.Position = mouseEvent.GlobalPosition;
                rock.Rotation = Mathf.Deg2Rad(270);
                this.AddChild(rock);
                rock.LaunchRock();
                //Hello World
            }
        }
    }
}