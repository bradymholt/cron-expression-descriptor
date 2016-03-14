using CronExpressionDescriptor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.Mvc;

namespace CronExpressionDescriptorDemo
{
    public class ViewModel
    {
        private const string ENGLISH_CULTURE = "en-US";

        public string Expression { get; set; }
        public string ExpressionDescription { get; set; }
        public bool Use24HourFormat { get; set; }
        public bool DayOfWeekStartIndexOne { get; set; }
        public bool VerboseDescription { get; set; }
        public string Language { get; set; }

        public string AssemblyVersion
        {
            get
            {
                Assembly assembly = Assembly.GetAssembly(typeof(ExpressionDescriptor));
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fvi.FileVersion;
            }
        }

        public SelectList AvailableLanguages
        {
            get
            {
                List<CultureInfo> cultures = new List<CultureInfo>() { CultureInfo.GetCultureInfo(ENGLISH_CULTURE) };

                string executablePath = HttpRuntime.AppDomainAppPath + "\\bin";
                string[] directories = Directory.GetDirectories(executablePath);
                foreach (string s in directories)
                {
                    try
                    {
                        DirectoryInfo langDirectory = new DirectoryInfo(s);
                        cultures.Add(CultureInfo.GetCultureInfo(langDirectory.Name));
                    }
                    catch { }

                }

                SelectList list = new SelectList(cultures, "Name", "DisplayName");
                return list;
            }
        }
    }
}