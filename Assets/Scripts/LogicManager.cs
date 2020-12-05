using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : NetworkManager {

    public readonly List<Scheme> color_schemes = new List<Scheme>{
        CustomColors.scheme_grey,
        CustomColors.scheme_red,
        CustomColors.scheme_yellow_vibrant,
        CustomColors.scheme_green,
        CustomColors.scheme_cyan_vibrant,
        CustomColors.scheme_blue,
        CustomColors.scheme_magenta_vibrant,
    };

    public GameObject background;
    //public SettingsButton settings_button;
    public GameObject host_join_panel;
    public GameObject waiting_panel;
    public GameObject game_panel;
    public InfoButton info_button;
    //public ColorDropdown colour_dropdown;
    public GridButton[] grid_buttons;
    public GameObject[] strikethroughs;

    private bool settings_are_shown;
    private string current_player;
    private int turn_counter;

    public override void Awake()
    {
        base.Awake();
        Debug.Log("Waking " + this.name);

        settings_are_shown = false;

        // Give each button a reference to the this class, so they can call its public functions when clicked.
        info_button.SetLogicManager(this);
        foreach (GridButton grid_button in grid_buttons) { grid_button.SetLogicManager(this); }
        //settings_button.SetSceneManager(this);
        //colour_dropdown.SetLogicManager(this);
    }

    public override void Start()
    {
        base.Start();
        game_panel.SetActive(false);
    }

    public void HostLocalGame()
    {
        Debug.Log("Hosting local game.");
        StartHost();  // Careful! StartHost will activate all GameObjects with a network identity!
    }

    public void JoinLocalGame()
    {
        Debug.Log("Joining local game.");
        StartClient();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        Debug.Log("Client started.");
        host_join_panel.SetActive(false);
        waiting_panel.SetActive(true);
    }

    // Detects when either player connects to the server.
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Debug.Log("Player " + conn + " connected.");
        if (NetworkServer.connections.Count == this.maxConnections)
        {
            waiting_panel.SetActive(false);
            game_panel = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "GamePanel"));
        }
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.Log("Connected to server.");
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("Disconnected from " + conn);
        waiting_panel.SetActive(false);
        host_join_panel.SetActive(true);
    }

    public void StartNewGame()
    {
        Debug.Log("Starting a new game.");
        current_player = "X";
        turn_counter = 0;
        info_button.Show(current_player + " goes first!");
        info_button.Disable();
        //settings_button.gameObject.SetActive(true);
        Deactivate(strikethroughs);
        ResetGridButtons();

        Debug.Log("Resetting current_player and turn_counter.");
    }

    public void SetColourScheme(int selection)
    {
        if (selection <= 0) { return; }
        Debug.Log("Setting colour scheme to " + color_schemes[selection].Name());
        background.GetComponent<Image>().color = color_schemes[selection].Background();
        //settings_button.SetColourScheme(colour_schemes[selection]);
        //settings_panel.GetComponent<Image>().color = colour_schemes[selection].Normal();
        //settings_panel.GetComponentInChildren<Text>().color = colour_schemes[selection].Text();
        //colour_dropdown.SetColourScheme(color_schemes[selection]);
        info_button.SetColourScheme(color_schemes[selection]);
        foreach (GridButton grid_button in grid_buttons) { grid_button.SetColourScheme(color_schemes[selection]); }
        foreach (GameObject strikethrough in strikethroughs) { strikethrough.GetComponent<Image>().color = color_schemes[selection].Text(); }
    }

    private void ResetGridButtons ()
    {
        Debug.Log("Resetting grid_buttons.");
        foreach (GridButton grid_button in grid_buttons)
        {
            grid_button.SetText("");
            grid_button.Enable();
        }
    }

    private void Deactivate (GameObject[] game_objects)
    {
        foreach (GameObject game_object in game_objects) { game_object.SetActive(false); }
    }

    /* Determines whether the game ends */
    public void TurnEnds ()
    {
        turn_counter++;
        Debug.Log("Ending turn " + turn_counter);

        // Horizontal conditions
        if (grid_buttons[0].GetText() == current_player && grid_buttons[1].GetText() == current_player && grid_buttons[2].GetText() == current_player) { GameEnds(current_player, 0); }
        else if (grid_buttons[3].GetText() == current_player && grid_buttons[4].GetText() == current_player && grid_buttons[5].GetText() == current_player) { GameEnds(current_player, 1); }
        else if (grid_buttons[6].GetText() == current_player && grid_buttons[7].GetText() == current_player && grid_buttons[8].GetText() == current_player) { GameEnds(current_player, 2); }

        // Vertical conditions
        else if (grid_buttons[0].GetText() == current_player && grid_buttons[3].GetText() == current_player && grid_buttons[6].GetText() == current_player) { GameEnds(current_player, 3); }
        else if (grid_buttons[1].GetText() == current_player && grid_buttons[4].GetText() == current_player && grid_buttons[7].GetText() == current_player) { GameEnds(current_player, 4); }
        else if (grid_buttons[2].GetText() == current_player && grid_buttons[5].GetText() == current_player && grid_buttons[8].GetText() == current_player) { GameEnds(current_player, 5); }

        // Diagonal conditions
        else if (grid_buttons[0].GetText() == current_player && grid_buttons[4].GetText() == current_player && grid_buttons[8].GetText() == current_player) { GameEnds(current_player, 6); }
        else if (grid_buttons[6].GetText() == current_player && grid_buttons[4].GetText() == current_player && grid_buttons[2].GetText() == current_player) { GameEnds(current_player, 7); }

        // Draw condition.
        else if (turn_counter >= 9) { GameEnds("?", -1); }

        else
        {
            // Switch players.
            current_player = (current_player == "X") ? "O" : "X";
            info_button.Show(current_player + "'s turn.");
        }
    }

    private void GameEnds (string winner, int strikethrough)
    {
        Debug.Log("Game over man!");

        // Disable grid_buttons.
        foreach (GridButton grid_button in grid_buttons) { grid_button.GetComponent<Button>().interactable = false; }

        // Show strikethrough.
        if (strikethrough > -1) { strikethroughs[strikethrough].SetActive(true); }

        // Show and enable restart_button.
        if (winner == "?") { info_button.Show("Draw!\nPlay again?"); }
        else { info_button.Show(winner + " wins!\nPlay again?"); }
        info_button.Enable();
    }

    public void ToggleSettings ()
    {
        Debug.Log("Settings shown = " + settings_are_shown + ". Toggling settings.");
        if (settings_are_shown) { HideSettings(); }
        else { ShowSettings(); }
    }

    private void ShowSettings ()
    {
        Debug.Log("Showing settings.");
        info_button.Hide();
        game_panel.SetActive(false);
        //settings_panel.SetActive(true);
        settings_are_shown = true;
    }

    private void HideSettings ()
    {
        Debug.Log("Hiding settings.");
        //settings_panel.SetActive(false);
        info_button.Show();
        //game_panel.SetActive(true);
        settings_are_shown = false;
    }

    public void Say(string message)
    {
        Debug.Log(message);
    }

    public string GetCurrentPlayer () { return current_player; }
}
