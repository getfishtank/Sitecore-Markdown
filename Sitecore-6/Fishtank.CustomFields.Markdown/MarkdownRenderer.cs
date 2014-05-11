using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Collections;

namespace Fishtank.CustomFields.Markdown
{
    public class MarkdownRenderer
    {

        public class Options
        {
            public static readonly string SafeMode = "safemode";
            public static readonly string ExtraMode = "extramode";
            public static readonly string MarkdownInHtml = "markdowninhtml";
            public static readonly string AutoHeadingIDs = "autoheadingids";
            public static readonly string NewWindowForExternalLinks = "newwindowforexternallinks";
            public static readonly string NewWindowForLocalLinks = "newwindowforlocallinks";
            public static readonly string NoFollowLinks = "nofollowlinks";
            public static readonly string HtmlClassFootnotes = "htmlclassfootnotes";
            public static readonly string HtmlClassTitledImages = "htmlclasstitledimages";
        }

        public static string Render(string markdown, SafeDictionary<string> parameters)
        {
            var parser = new MarkdownDeep.Markdown();

            // Default values

            // parses all html
            // parser.ExtraMode = true;
            // parser.SafeMode = true;
            // parser.MarkdownInHtml = true;
            parser.NewWindowForExternalLinks = true;
            // parser.NewWindowForLocalLinks = false;
            // parser.NoFollowLinks = false;
            // parser.AutoHeadingIDs = true;

            parser.HtmlClassFootnotes = "";
            parser.HtmlClassTitledImages = "";
            

            if (HasValue(parameters, Options.ExtraMode))
                parser.ExtraMode = StringToBool(parameters[Options.ExtraMode]);

            if (HasValue(parameters, Options.SafeMode))
                parser.SafeMode = StringToBool(parameters[Options.SafeMode]);

            if (HasValue(parameters, Options.MarkdownInHtml))
                parser.MarkdownInHtml = StringToBool(parameters[Options.MarkdownInHtml]);

            if (HasValue(parameters, Options.AutoHeadingIDs))
                parser.AutoHeadingIDs = StringToBool(parameters[Options.AutoHeadingIDs]);

            if (HasValue(parameters, Options.NewWindowForExternalLinks))
                parser.NewWindowForExternalLinks = StringToBool(parameters[Options.NewWindowForExternalLinks]);

            if (HasValue(parameters, Options.NewWindowForLocalLinks))
                parser.NewWindowForLocalLinks = StringToBool(parameters[Options.NewWindowForLocalLinks]);

            if (HasValue(parameters, Options.NoFollowLinks))
                parser.NoFollowLinks = StringToBool(parameters[Options.NoFollowLinks]);

            if (HasValue(parameters, Options.HtmlClassFootnotes))
                parser.HtmlClassFootnotes = parameters[Options.HtmlClassFootnotes];

            if (HasValue(parameters, Options.HtmlClassTitledImages))
                parser.HtmlClassTitledImages = parameters[Options.HtmlClassTitledImages];

            var output = parser.Transform(markdown);

            return output;
        }

        public static string BoolToString(bool? value)
        {
            if (value == null)
                return String.Empty;
            else if (value == true)
                return "1";
            else
                return "0";
        }

        public static bool StringToBool(string flag)
        {
            return flag == "1";
        }

        private static bool HasValue(SafeDictionary<string> list, string key)
        {
            if (list == null || key == null) return false;

            return !String.IsNullOrEmpty(list[key]);
        }

        public static SafeDictionary<string> MergeSourceValuesWithParameters(string source, SafeDictionary<string> parameters)
        {
            if (parameters == null) return null;
            if (String.IsNullOrWhiteSpace(source)) return parameters;

            var keyPairs = source.Split('&');

            foreach (var kvp in keyPairs)
            {
                var keyValueArray = kvp.Split('=');
                var key = keyValueArray[0];
                var value = keyValueArray[1];
                
                if(String.IsNullOrWhiteSpace(key) || String.IsNullOrWhiteSpace(value) ) continue;

                if (parameters.ContainsKey(key))
                {
                    parameters[key] = value;
                }
                else
                {
                    parameters.Add(key, value);
                }
            }

            return parameters;
        }
    }
}
