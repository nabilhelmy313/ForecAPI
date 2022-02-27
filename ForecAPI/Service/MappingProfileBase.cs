using AutoMapper;
using System.Collections.Generic;
using System;
using System.Text;

namespace ForecAPI.Application
{
    public class MappingProfileBase : Profile
    {
        public MappingProfileBase()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            ReplaceMemberName("_", "");
        }
        
        public static string GetCurrentLanguage()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
        }

    }
}

