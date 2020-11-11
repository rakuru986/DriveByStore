﻿using System.Reflection;

namespace Util.Classes {

    public static class PublicFlagsFor {
        private const BindingFlags p = BindingFlags.Public;
        private const BindingFlags i = BindingFlags.Instance;
        private const BindingFlags s = BindingFlags.Static;
        private const BindingFlags d = BindingFlags.DeclaredOnly;
        public const BindingFlags All = p | i | s;
        public const BindingFlags Instance = p | i;
        public const BindingFlags Static = p | s;
        public const BindingFlags Declared = p | d | i | s;
    }

}




