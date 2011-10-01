using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NzbMatrix
{
    public enum Categories
    {
        All = 0,

        Movies_DVD = 1,
        Movies_DivxXvid = 2,
        Movies_BRRip = 54,
        Movies_HDx264 = 42,
        Movies_HDImage = 50,
        Movies_WMVHD = 48,
        Movies_SVCDVCD = 3,
        Movies_Other = 4,

        TV_DVD = 5,
        TV_DivxXvid = 6,
        TV_HD = 41,
        TV_SportEnt = 7,
        TV_Other = 8,

        Documentaries_STD = 9,
        Documentaries_HD = 53,

        Games_PC = 10,
        Games_PS2 = 11,
        Games_PS3 = 43,
        Games_PSP = 12,
        Games_Xbox = 13,
        Games_Xbox360 = 14,
        Games_Xbox360Other = 56,
        Games_PS1 = 15,
        Games_Dreamcast = 16,
        Games_Wii = 44,
        Games_WiiVC = 51,
        Games_DS = 45,
        Games_GameCube = 46,
        Games_Other = 17,

        Apps_PC = 18,
        Apps_Mac = 19,
        Apps_Portable = 52,
        Apps_Linux = 20,
        Apps_Phone = 55,
        Apps_Other = 21,

        Music_MP3Albums = 22,
        Music_MP3Singles = 47,
        Music_Loseless = 23,
        Music_DVD = 24,
        Music_Video = 25,
        Music_Other = 27,

        Anime = 28,

        Other_AudioBooks = 49,
        Other_Emulation = 33,
        Other_PPCPDA = 34,
        Other_Radio = 26,
        Other_EBooks = 36,
        Other_Images = 37,
        Other_MobilePhone = 38,
        Other_ExtraParsFills = 39,
        Other_Other = 40
    }
}
