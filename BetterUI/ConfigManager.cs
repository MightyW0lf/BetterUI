﻿using BepInEx;
using BepInEx.Configuration;
using System;
using UnityEngine;

namespace BetterUI
{
    class ConfigManager
    {
        // 1 Misc

        public ConfigEntry<bool> MiscAdvancedDescriptions;
        public ConfigEntry<bool> MiscAdvancedPickupNotifications;
        public ConfigEntry<bool> MiscItemStatsIntegration;
        public ConfigEntry<bool> MiscShowHidden;


        // 2 Command / Scrapper Improvements

        public ConfigEntry<bool> CommandResizeCommandWindow;
        public ConfigEntry<bool> CommandRemoveBackgroundBlur;
        public ConfigEntry<bool> CommandCloseOnEscape;
        public ConfigEntry<bool> CommandCloseOnWASD;
        public ConfigEntry<String> CommandCloseOnCustom;
        public ConfigEntry<bool> CommandTooltipsShow;
        public ConfigEntry<bool> CommandTooltipsItemStatsBeforeAfter;
        public ConfigEntry<bool> CommandCountersShow;
        public ConfigEntry<bool> CommandCountersHideOnZero;
        public ConfigEntry<String> CommandCountersPosition;
        public TMPro.TextAlignmentOptions CommandCountersTextAlignmentOption;
        public ConfigEntry<float> CommandCountersFontSize;
        public ConfigEntry<String> CommandCountersPrefix;

        // 3 DPSMeter

        public ConfigEntry<float> DPSMeterTimespan;
        public ConfigEntry<bool> DPSMeterWindowShow;
        public ConfigEntry<bool> DPSMeterWindowIncludeMinions;
        public ConfigEntry<bool> DPSMeterWindowBackground;
        public ConfigEntry<Vector2> DPSMeterWindowAnchorMin;
        public ConfigEntry<Vector2> DPSMeterWindowAnchorMax;
        public ConfigEntry<Vector2> DPSMeterWindowPosition;
        public ConfigEntry<Vector2> DPSMeterWindowPivot;
        public ConfigEntry<Vector2> DPSMeterWindowSize;
        public ConfigEntry<Vector3> DPSMeterWindowAngle;

        // 4 StatsDisplay
        public ConfigEntry<bool> StatsDisplayEnable;
        public ConfigEntry<String> StatsDisplayStatString;
        public ConfigEntry<bool> StatsDisplayShowScoreboardOnly;
        public ConfigEntry<bool> StatsDisplayPanelBackground;
        public ConfigEntry<bool> StatsDisplayAttachToObjectivePanel;
        public ConfigEntry<Vector2> StatsDisplayWindowAnchorMin;
        public ConfigEntry<Vector2> StatsDisplayWindowAnchorMax;
        public ConfigEntry<Vector2> StatsDisplayWindowPosition;
        public ConfigEntry<Vector2> StatsDisplayWindowPivot;
        public ConfigEntry<Vector2> StatsDisplayWindowSize;
        public ConfigEntry<Vector3> StatsDisplayWindowAngle;

        // 5 Sorting
        public ConfigEntry<bool> SortingSortItemsInventory;
        public ConfigEntry<bool> SortingSortItemsCommand;
        public ConfigEntry<bool> SortingSortItemsScrapper;
        public ConfigEntry<String> SortingTierOrderString;
        public int[] SortingTierOrder;
        public ConfigEntry<String> SortingSortOrder;
        public ConfigEntry<String> SortingSortOrderCommand;
        public ConfigEntry<String> SortingSortOrderScrapper;




        public ConfigManager(BetterUI mod)
        {
            ConfigFile ConfigFileMisc = new ConfigFile(Paths.ConfigPath + "\\BetterUI-Misc.cfg", true);
            ConfigFile ConfigFileCommandImprovements = new ConfigFile(Paths.ConfigPath + "\\BetterUI-CommandImprovements.cfg", true);
            ConfigFile ConfigFileDPSMeter = new ConfigFile(Paths.ConfigPath + "\\BetterUI-DPSMeter.cfg", true);
            ConfigFile ConfigFileStatsDisplay = new ConfigFile(Paths.ConfigPath + "\\BetterUI-StatsDisplay.cfg", true);
            ConfigFile ConfigFileSorting = new ConfigFile(Paths.ConfigPath + "\\BetterUI-Sorting.cfg", true);

            // Misc

            MiscAdvancedDescriptions = ConfigFileMisc.Bind("Misc", "AdvancedDescriptions", true, "Show advanced descriptions when hovering over an item.");

            MiscAdvancedPickupNotifications = ConfigFileMisc.Bind("Misc", "AdvancedPickupNotifications", true, "Show advanced descriptions when picking up an item.");

            MiscItemStatsIntegration = ConfigFileMisc.Bind("Misc", "ItemStatsIntegration", true, "If installed, show item stats from ItemStatsMod where applicable");

            MiscShowHidden = ConfigFileMisc.Bind("Misc", "ShowHidden", false, "Show hidden items in the item inventory");

            // Command / Scrapper Improvements

            CommandResizeCommandWindow = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "ResizeCommandWindow", true, "Resize the command window depending on the number of items.");

            CommandRemoveBackgroundBlur = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "RemoveBackgroundBlur", true, "Remove the blur behind the command window that hides the rest of the UI.");

            CommandCloseOnEscape = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "CloseOnEscape", true, "Close the command/scrapper window when you press escape.");

            CommandCloseOnWASD = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "CloseOnWASD", true, "Close the command/scrapper window when you press W, A, S or D");

            CommandCloseOnCustom = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "CloseOnCustom", "", "Close the command/scrapper window when you press the key selected here.\n" +
                "Example: space\n" +
                "Must be lowercase. Leave blank to disable");

            CommandTooltipsShow = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "TooltipsShow", true, "Show tooltips in the command and scrapper dwindow");

            CommandTooltipsItemStatsBeforeAfter = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "TooltipsItemStatsBeforeAfter", true, "If ItemStatsMod is installed, show the stats before and after picking up the item");

            CommandCountersShow = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "CountersShow", true, "Show counters in the command and scrapper window");

            CommandCountersHideOnZero = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "CountersHideOnZero", false, "Hide counters if they would be zero.");

            CommandCountersPosition = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "CountersPosition", "TopRight",
                "Location of the command item counter\n" +
                "Valid options:\n" +
                "TopLeft\n" +
                "TopRight\n" +
                "BottomLeft\n" +
                "BottomRight\n" +
                "Center\n");

            CommandCountersTextAlignmentOption = (TMPro.TextAlignmentOptions)Enum.Parse(typeof(TMPro.TextAlignmentOptions), CommandCountersPosition.Value, true);

            CommandCountersFontSize = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "CountersFontSize", 20f, "Size of the command item counter text");

            CommandCountersPrefix = ConfigFileCommandImprovements.Bind("Command / Scrapper Improvements", "CountersPrefix", "x", "Prefix for the command item counter. Example 'x' will show x0, x1, x2, etc.\nCan be empty.");

            // DPSMeter

            DPSMeterTimespan = ConfigFileDPSMeter.Bind("DPSMeter", "Timespan", 5f, "Calculate DPS across this many seconds.");

            DPSMeterWindowShow = ConfigFileDPSMeter.Bind("DPSMeter", "WindowShow", true, "Show a dedicated DPSMeter.");

            DPSMeterWindowIncludeMinions = ConfigFileDPSMeter.Bind("DPSMeter", "WindowIncludeMinions", true, "Include minions such as turrets and drones in the DPS meter.");

            DPSMeterWindowBackground = ConfigFileDPSMeter.Bind("DPSMeter", "WindowBackground", true, "Whether or not the DPS window should have a background.");

            DPSMeterWindowAnchorMin = ConfigFileDPSMeter.Bind("DPSMeter", "WindowAnchorMin", new Vector2(0, 0),
                "Minimum position to anchor from. x & y\n" +
                "X: 0 is left of the screen, 1 is right of screen\n" +
                "Y: 0 is bottom of the screen, 1 is top of the screen\n" +
                "default of (0, 0) puts the anchor in the bottom left corner of the screen.");

            DPSMeterWindowAnchorMax = ConfigFileDPSMeter.Bind("DPSMeter", "WindowAnchorMax", new Vector2(0, 0f), "Maximum position to anchor from, see above.");

            DPSMeterWindowPosition = ConfigFileDPSMeter.Bind("DPSMeter", "WindowPosition", new Vector2(120, 240), "Position of the DPSMeter window relative to anchor");

            DPSMeterWindowPivot = ConfigFileDPSMeter.Bind("DPSMeter", "WindowPivot", new Vector2(0, 1), "Pivot of the DPSMeter window.\n" +
                "Window Position is from the anchor to the pivot.");

            DPSMeterWindowSize = ConfigFileDPSMeter.Bind("DPSMeter", "WindowSize", new Vector2(350, 45), "Size of the DPSMeter window");

            DPSMeterWindowAngle = ConfigFileDPSMeter.Bind("DPSMeter", "WindowAngle", new Vector3(0, -6, 0), "Angle of the DPSMeter window");

            // StatsDisplay

            StatsDisplayEnable = ConfigFileStatsDisplay.Bind("StatsDisplay", "Enable", true, "Enable/Disable the StatsDisplay entirely.");

            StatsDisplayStatString = ConfigFileStatsDisplay.Bind("StatsDisplay", "StatString",
                "<color=#FFFFFF>" +
                "<size=18><b>Stats</b></size>\n" +
                "<size=14>Luck: $luck\n" +
                "Base Damage: $dmg\n" +
                "Crit Chance: $crit%\n" +
                "Attack Speed: $atkspd\n" +
                "Armor: $armor\n" +
                "Regen: $regen\n" +
                "MoveSpeed: $movespeed\n" +
                "Jumps: $jumps/$maxjumps\n" +
                "Kills: $killcount",
                "You may format the StatString using formatting tags such as color, size, bold, underline, italics. See Readme for more\n" +
                "Valid Parameters:\n" +
                "$exp $level $luck\n" +
                "$dmg $crit $atkspd\n" +
                "$hp $maxhp $shield $maxshield $barrier $maxbarrier\n" +
                "$armor $regen\n" +
                "$movespeed $jumps $maxjumps\n" +
                "$killcount $multikill\n" +
                "$dps $dpscharacter $dpsminions\n");

            StatsDisplayShowScoreboardOnly = ConfigFileStatsDisplay.Bind("StatsDisplay", "ShowOnlyScoreboard", false, "Only show the StatsDisplay when the scoreboard is open");

            StatsDisplayPanelBackground = ConfigFileStatsDisplay.Bind("StatsDisplay", "PanelBackground", true, "Whether or not the StatsDisplay panel should have a background.");

            StatsDisplayAttachToObjectivePanel = ConfigFileStatsDisplay.Bind("StatsDisplay", "AttachToObjectivePanel", true, "Whether to attach the stats display to the objective panel.\n" +
                "If not, it will be a free-floating window that can be moved with the options below.");

            StatsDisplayWindowAnchorMin = ConfigFileStatsDisplay.Bind("StatsDisplay", "WindowAnchorMin", new Vector2(1, 0.5f),
                "Minimum position to anchor from. x & y\n" +
                "X: 0 is left of the screen, 1 is right of the screen\n" +
                "Y: 0 is bottom of the screen, 1 is top of the screen\n" +
                "default of (1, 0.5) puts the anchor in the middle of the right side of the screen.\n");

            StatsDisplayWindowAnchorMax = ConfigFileStatsDisplay.Bind("StatsDisplay", "WindowAnchorMax", new Vector2(1, 0.5f), "Maximum position to anchor from, see above.");

            StatsDisplayWindowPosition = ConfigFileStatsDisplay.Bind("StatsDisplay", "WindowPosition", new Vector2(-210, 100), "Position of the StatsDisplay window relative to anchor");

            StatsDisplayWindowPivot = ConfigFileStatsDisplay.Bind("StatsDisplay", "WindowPivot", new Vector2(0, 0.5f), "Pivot of the StatsDisplay window.\n" +
                "Window Position is from the anchor to the pivot.");

            StatsDisplayWindowSize = ConfigFileStatsDisplay.Bind("StatsDisplay", "WindowSize", new Vector2(200, 600), "Size of the StatsDisplay window");

            StatsDisplayWindowAngle = ConfigFileStatsDisplay.Bind("StatsDisplay", "WindowAngle", new Vector3(0,6,0), "Angle of the StatsDisplay window");

            // Sorting

            SortingSortItemsInventory = ConfigFileSorting.Bind("Sorting", "SortItemsInventory", true, "Sort items in the inventory and scoreboard");

            SortingSortItemsCommand = ConfigFileSorting.Bind("Sorting", "SortItemsCommand", true, "Sort items in the command window");

            SortingSortItemsScrapper = ConfigFileSorting.Bind("Sorting", "SortItemsScrapper", true, "Sort items in the scrapper window");

            SortingTierOrderString = ConfigFileSorting.Bind("Sorting", "TierOrder", "012345", "Tiers in ascending order, left to right \n0 = White, 1 = Green, 2 = Red, 3 = Lunar, 4 = Boss, 5 = NoTier");

            SortingTierOrder = new int[]
            {
                SortingTierOrderString.Value.IndexOf('0'),
                SortingTierOrderString.Value.IndexOf('1'),
                SortingTierOrderString.Value.IndexOf('2'),
                SortingTierOrderString.Value.IndexOf('3'),
                SortingTierOrderString.Value.IndexOf('4'),
                SortingTierOrderString.Value.IndexOf('5'),
            };

            SortingSortOrder = ConfigFileSorting.Bind("Sorting", "SortOrder", "S134",
                    "What to sort the items by, most important to least important.\n" +
                    "Find the full details and an example in the Readme on Thunderstore/Github\n" +
                    "0 = Tier Ascending\n" +
                    "1 = Tier Descending\n" +
                    "2 = Stack Size Ascending\n" +
                    "3 = Stack Size Descending\n" +
                    "4 = Pickup Order\n" +
                    "5 = Pickup Order Reversed\n" +
                    "6 = Alphabetical\n" +
                    "7 = Alphabetical Reversed\n" +
                    "8 = Random\n" +
                    "i = ItemIndex\n" +
                    "I = ItemIndex Descending\n" +
                    "\n" +
                    "Tag Based:\n" +
                    "s = Scrap First\n" +
                    "S = Scrap Last\n" +
                    "d = Damage First\n" +
                    "D = Damage Last\n" +
                    "h = Healing First\n" +
                    "H = Healing Last\n" +
                    "u = Utility First\n" +
                    "U = Utility Last\n" +
                    "o = On Kill Effect First\n" +
                    "O = On Kill Effect Last\n" +
                    "e = Equipment Related First\n" +
                    "E = Equipment Related Last\n" +
                    "p = Sprint Related First\n" +
                    "P = Sprint Related Last");

            SortingSortOrderCommand = ConfigFileSorting.Bind("Sorting", "SortOrderCommand", "36",
            "Sort order for the command window\n" +
            "The command window has a special sort option \"C\" which will place the last selected item in the middle.\n" +
            "Note: This option must be the last one in the SortOrderCommand option");

            SortingSortOrderScrapper = ConfigFileSorting.Bind("Sorting", "SortOrderScrapper", "134",
            "Sort order for the scrapper window");

        }
    }
}
