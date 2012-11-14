﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhonePowerTools
{
    public class About
    {

        #region Singleton

        private static About _theOne;

        public static About Current
        {
            get {
                if (_theOne == null)
                {
                    _theOne = new About();
                }

                return _theOne;
            }
        }

        #endregion

        public string AppName { get { return "Windows Phone Power Tools"; } }

        public bool Beta { get { return true; } }

        public string Version { get; private set; }

        public string FullVersionString { get; private set; }

        private About()
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;

            // I don't like the build.revision number since it's long and unweildly. Instead lets fold revision into build
            // revisions increment every ~ 2 seconds so...
            string buildWithRevision = string.Format(CultureInfo.InvariantCulture, @"{0}{1}", v.Build, (v.Revision * 2) * 100 / (24 * 60 * 60));

            Version = string.Format(CultureInfo.InvariantCulture, @"{0}.{1:d2}.{2}", v.Major, v.Minor, buildWithRevision);
            FullVersionString = string.Format(CultureInfo.InvariantCulture, @"{0} Version {1}", AppName, Version);
        }


    }
}
