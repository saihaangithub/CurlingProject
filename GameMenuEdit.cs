using Godot;
using System;

public class GameMenuEdit : Control
{

    Player player;

    public override void _Ready()
    {

    }

    /*public void _on_GameMenu_gui_input(Player input)
    {
     player = input;
        this.Visible = true;
        updateTextfields();
    }
    */

    [Signal]

    public delegate void send_set_new_values(Player output);


    public void _on_Set_pressed()
    {
        String LinearForceText = ((LineEdit)GetNode("VBoxContainer/LinearForce_Edit")).Text;
        String TorqueForceText = ((LineEdit)GetNode("VBoxContainer/Torque_Edit")).Text;
        String Friction = ((LineEdit)GetNode("VBoxContainer/Friction_Edit")).Text;

        GlobalVars.Impulse = (int)float.Parse(LinearForceText);
        GlobalVars.friction = (int)float.Parse(Friction);
        GlobalVars.Torque = (int)float.Parse(TorqueForceText);

        //EmitSignal(nameof(send_set_new_values), player);

        //Changes scence back to rink
        GetTree().ChangeScene("res://Rink.tscn");

        this.Visible = false;
    }

    //public void _on_OptionButton_item_selected()
    //{
      //  Direction = ((OptionButton)GetNode("VBoxContainer/OptionButton"));

    //}

    public override void _Process(float delta)
    {

    }

    /*void updateTextfields()
    {

        LineEdit friction = (LineEdit)GetNode("Control/VboxContainer/Friction_Edit");
        LineEdit Impulse = (LineEdit)GetNode("Control/VboxContainer/LinearForce_Edit");

        friction.Text = player.friction.ToString();
        Impulse.Text = player.Impulse.ToString();

    }
    */

}