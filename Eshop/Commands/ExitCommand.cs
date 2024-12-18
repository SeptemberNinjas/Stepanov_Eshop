﻿using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Commands
{
    internal static class ExitCommand
    {
        public const string Name = "Выход";

        public static string GetInfo()
        {
            return "Выйти из программы.";
        }

        public static string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
