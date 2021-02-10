using Godot;
using System;

public class GameMenuBack : Button
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    public override void _Pressed()
    {
        GetTree().ChangeScene("res://Rink.tscn");
    }

    // hello
}
