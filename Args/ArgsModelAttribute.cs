﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Args
{
    /// <summary>
    /// Decorate a model with this attribute to specifiy its switch delimiter as well as the StringComparison type to use when checking for switch equality
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ArgsModelAttribute : Attribute
    {
        public static ArgsModelAttribute Default
        {
            get { return new ArgsModelAttribute(); }
        }

        public ArgsModelAttribute()
        {
            SwitchDelimiter = "/";
            StringComparison = StringComparison.CurrentCultureIgnoreCase;
        }

        public string SwitchDelimiter { get; set; }
        public StringComparison StringComparison { get; set; }

        public StringComparer StringComparer
        {
            get
            {
                switch (StringComparison)
                {
                    case StringComparison.CurrentCulture:
                        return StringComparer.CurrentCulture;
                    case StringComparison.CurrentCultureIgnoreCase:
                        return StringComparer.CurrentCultureIgnoreCase;
                    case StringComparison.Ordinal:
                        return StringComparer.Ordinal;
                    case StringComparison.OrdinalIgnoreCase:
                        return StringComparer.OrdinalIgnoreCase;
                    default:
                        throw new ArgumentOutOfRangeException("StringComparison");
                }
            }
        }
    }
}
