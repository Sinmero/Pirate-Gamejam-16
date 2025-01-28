using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameLists : MonoBehaviour
{
    public List<string> _names = new List<string>

    {

        "Bumble",

        "Gnomey",

        "Nibbles",

        "Tink",

        "Wizzle",

        "Gimble",

        "Pip",

        "Snick",

        "Ziggy",

        "Dabble",

        "Twiddle",

        "Boggle",

        "Peeple",

        "Wobble",

        "Jingle",

        "Puddle",

        "Sprocket",

        "Tweak",

        "Gadget",

        "Noodle",

        "Blinky",

        "Fumble",

        "Wizzle",

        "Doodle",

        "Tinker",

        "Bumblebee",

        "Fizzlebang",

        "Snappy",

        "Wiggle",

        "Pipkin",

        "Glimmer",

        "Twinkle",

        "Nimble",

        "Sizzle",

        "Wobbleton",

        "Dizzy",

        "Fiddlesticks",

        "Jibber",

        "Puff",

        "Zappy",

        "Blinky",

        "Frolic",

        "Tumble",

        "Wiggles",

        "Sproing",

        "Dabble",

        "Fizzlepop",

        "Nibbler",

        "Tinkertop",

        "Wizzlewort",

        "Bumblefoot",

        "Fiddler",

        "Snicker",

        "Zigzag",

        "Doodlebug",

        "Twiddler",

        "Gimbletock",

        "Pipwhistle",

        "Sprockethead",

        "Wobblewink",

        "Froth",

        "Jinglebell",

        "Puddlejumper",

        "Tweakster",

        "Gadgeteer",

        "Noodlehead",

        "Blinkywink",

        "Fumblefoot",

        "Wizzlepop",

        "Dizzywig",

        "Fiddlestomp",

        "Jibberjabber",

        "Puffball",

        "Zappytoes",

        "Bumblebop",

        "Frolicfoot",

        "Tumbleweed",

        "Wiggleworm",

        "Sproingy",

        "Dabblepot",

        "Fizzlewhip",

        "Nibblesnap",

        "Tinkertwist",

        "Wizzlewhirl",

        "Bumblebreeze",

        "Fiddlestitch",

        "Snickerdoodle",

        "Ziggle",

        "Doodlewhirl",

        "Twiddlespark",

        "Gimblefizz",

        "Pipwhirl",

        "Sprocketwink",

        "Wobblefizz",

        "Frothwhistle",

        "Jinglepuff",

        "Puddlewhirl",

        "Tweakfizz",

        "Gadgetwhirl",

        "Noodlefizz"

    };



    public List<string> _lastNames = new List<string>

{

    "Ironfist",

    "Stonebeard",

    "Goldenshield",

    "Thunderforge",

    "Firehammer",

    "Deepdelver",

    "Battleaxe",

    "Grimstone",

    "Frostbeard",

    "Blackrock",

    "Coppervein",

    "Mithrilheart",

    "Steelgrip",

    "Runehammer",

    "Stonebreaker",

    "Ironfoot",

    "Goldensong",

    "Brassbrow",

    "Shadowforge",

    "Brightaxe",

    "Gravelheart",

    "Ironshield",

    "Stonewhisper",

    "Frostforge",

    "Deepstone",

    "Thunderstone",

    "Fireforge",

    "Goldenshield",

    "Mithrilforge",

    "Steelbrow",

    "Runeclaw",

    "Ironhand",

    "Stonefist",

    "Blackstone",

    "Copperstone",

    "Grimforge",

    "Frosthammer",

    "Deepforge",

    "Battleborn",

    "Ironbrow",

    "Goldenshield",

    "Brassforge",

    "Shadowstone",

    "Brightstone",

    "Gravelbeard",

    "Ironheart",

    "Stonegrip",

    "Frostbeard",

    "Deepaxe",

    "Thunderheart",

    "Firestone",

    "Goldenshield",

    "Mithrilbrow",

    "Steelhammer",

    "Runeveil",

    "Ironstone",

    "Stonebreaker",

    "Blackforge",

    "Copperhammer",

    "Grimheart",

    "Froststone",

    "Deepbrow",

    "Thunderforge",

    "Firebeard",

    "Goldensong",

    "Brassheart",

    "Shadowaxe",

    "Brightforge",

    "Gravelstone",

    "Ironveil",

    "Stonehand",

    "Frostfist",

    "Deepheart",

    "Battleforge",

    "Ironwhisper",

    "Goldenshield",

    "Brassstone",

    "Shadowheart",

    "Brightbrow",

    "Gravelforge",

    "Ironbreaker",

    "Stoneveil",

    "Frostwhisper",

    "Deepstone",

    "Thunderbrow",

    "Firegrip",

    "Goldenshield",

    "Mithrilstone",

    "Steelveil",

    "Runeheart",

    "Ironforge",

    "Stonehammer",

    "Blackbrow",

    "Copperbeard",

    "Grimstone",

    "Frostforge",

    "Deepfist",

    "Thunderstone",

    "Fireaxe",

    "Goldenshield",

    "Brassveil",

    "Shadowgrip",

    "Brightheart",

    "Gravelhand"

};


    public List<string> _titles = new List<string>

{

    "the First",

    "the Second",

    "the Third",

    "the Fourth",

    "the Fifth",

    "the Sixth",

    "the Seventh",

    "the Eighth",

    "the Ninth",

    "the Tenth",

    "the Whimsy",

    "the Meek",

    "the Brave",

    "the Clever",

    "the Quick",

    "the Wise",

    "the Jolly",

    "the Curious",

    "the Bold",

    "the Merry",

    "the Crafty",

    "the Daring",

    "the Sprightly",

    "the Sly",

    "the Bright",

    "the Fanciful",

    "the Witty",

    "the Adventurous",

    "the Gentle",

    "the Grumpy",

    "the Cheerful",

    "the Cunning",

    "the Diligent",

    "the Eager",

    "the Fuzzy",

    "the Glimmering",

    "the Happy",

    "the Kind",

    "the Lively",

    "the Mischievous",

    "the Noble",

    "the Playful",

    "the Quirky",

    "the Radiant",

    "the Sassy",

    "the Tinkerer",

    "the Unseen",

    "the Valiant",

    "the Whimsical",

    "the Zany",

    "the Agile",

    "the Bashful",

    "the Chipper",

    "the Dapper",

    "the Energetic",

    "the Fanciful",

    "the Giddy",

    "the Hasty",

    "the Ingenious",

    "the Joyful",

    "the Keen",

    "the Luminous",

    "the Merry",

    "the Nifty",

    "the Optimistic",

    "the Ponderous",

    "the Quizzical",

    "the Radiant",

    "the Spry",

    "the Tinkering",

    "the Unpredictable",

    "the Vibrant",

    "the Wily",

    "the Zesty",

    "the Adventurous",

    "the Bashful",

    "the Cheerful",

    "the Daring",

    "the Eccentric",

    "the Fanciful",

    "the Gracious",

    "the Humble",

    "the Ingenious",

    "the Joyous",

    "the Kindhearted",

    "the Lively",

    "the Mirthful",

    "the Nimble",

    "the Outlandish",

    "the Pensive",

    "the Quirky",

    "the Rambunctious",

    "the Sincere",

    "the Tenacious",

    "the Unwavering",

    "the Vibrant",

    "the Whimsical",

    "the Yearning",

    "the Zealous",

    "the Affectionate",

    "the Boisterous",

    "the Cheerful",

    "the Diligent",

    "the Enthusiastic",

    "the Fearless",

    "the Grinning",

    "the Hopeful",

    "the Imaginative",

    "the Joyful",

    "the Keen",

    "the Lively",

    "the Merry",

    "the Nurturing",

    "the Optimistic",

    "the Playful",

    "the Quizzical",

    "the Radiant",

    "the Spirited",

    "the Trusty",

    "the Unseen",

    "the Valiant",

    "the Whimsical",

};
}
