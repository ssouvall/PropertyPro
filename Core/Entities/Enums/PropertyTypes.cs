using System.ComponentModel;

namespace Core.Entities.Enums
{
    public enum PropertyTypes
    {
        [Description("Single Family Home")]
        SFH,
        [Description("Multi-Family Home")]
        MFH,
        [Description("Condominium")]
        CM,
        [Description("Townhome")]
        TH,
        [Description("Mobile Home")]
        MH,
        [Description("Lot/Land")]
        LL,
        [Description("Other")]
        OTHER,
    }
}