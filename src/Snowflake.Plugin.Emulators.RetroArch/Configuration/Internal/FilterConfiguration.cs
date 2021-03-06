using Snowflake.Configuration;
using Snowflake.Configuration.Attributes;

//autogenerated using generate_retroarch.py

namespace Snowflake.Plugin.Emulators.RetroArch.Configuration.Internal
{
    /// <summary>
    ///     Have no discernable effect on Windows and are disabled immediately
    ///     (XBOX Only Setting?)
    /// </summary>
    [ConfigurationSection("flicker", "Filter Options")]
    public interface FilterConfiguration : IConfigurationSection<FilterConfiguration>
    {
        [ConfigurationOption("flicker_filter_enable", false, DisplayName = "Flicker Filter Enable", Private = true)]
        bool FlickerFilterEnable { get; set; }

        //todo check max
        [ConfigurationOption("flicker_filter_index", 0, DisplayName = "Flicker Filter Index", Private = true)]
        int FlickerFilterIndex { get; set; }

        [ConfigurationOption("soft_filter_enable", false, DisplayName = "Soft Filter Enable", Private = true)]
        bool SoftFilterEnable { get; set; }

        //todo check max
        [ConfigurationOption("soft_filter_index", 0, DisplayName = "Soft Filter Index", Private = true)]
        int SoftFilterIndex { get; set; }
    }
}