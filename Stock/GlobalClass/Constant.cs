using System;

namespace Stock.GlobalClass
{
    /// <summary>
    /// Some Global constant that can be common and accessible across entire application
    /// </summary>
    public class Constant
    {
        /// <summary>
        /// Path where XMLDocumentation file is resides.
        /// </summary>
        public static string XMLDocPath { get; } = $"{AppDomain.CurrentDomain.BaseDirectory}\\bin\\Stock.XML";
    }
}