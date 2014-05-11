using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Collections;
using Sitecore.Diagnostics;
using Sitecore.Web.UI.WebControls;

namespace Fishtank.CustomFields.Markdown.Web
{
    public class Markdown : FieldControl
    {
        public bool? SafeMode { get; set; }
        public bool? ExtraMode { get; set; }
        public bool? MarkdownInHtml { get; set; }
        public bool? AutoHeadingIDs { get; set; }
        public bool? NewWindowForExternalLinks { get; set; }
        public bool? NewWindowForLocalLinks { get; set; }
        public bool? NoFollowLinks { get; set; }
        public string HtmlClassFootnotes { get; set; }
        public string HtmlClassTitledImages { get; set; }
        
        protected override void PopulateParameters(SafeDictionary<string> parameters)
        {
            Assert.ArgumentNotNull((object)parameters, "parameters");
            base.PopulateParameters(parameters);
            if(SafeMode != null)
                parameters.Add(MarkdownRenderer.Options.SafeMode, MarkdownRenderer.BoolToString(SafeMode));
            if (ExtraMode != null)
                parameters.Add(MarkdownRenderer.Options.ExtraMode, MarkdownRenderer.BoolToString(ExtraMode));
            if (MarkdownInHtml != null)
                parameters.Add(MarkdownRenderer.Options.MarkdownInHtml, MarkdownRenderer.BoolToString(MarkdownInHtml));
            if (AutoHeadingIDs != null)
                parameters.Add(MarkdownRenderer.Options.AutoHeadingIDs, MarkdownRenderer.BoolToString(AutoHeadingIDs));
            if (NewWindowForExternalLinks != null)
                parameters.Add(MarkdownRenderer.Options.NewWindowForExternalLinks, MarkdownRenderer.BoolToString(NewWindowForExternalLinks));
            if (NewWindowForLocalLinks != null)
                parameters.Add(MarkdownRenderer.Options.NewWindowForLocalLinks, MarkdownRenderer.BoolToString(NewWindowForLocalLinks));
            if (NoFollowLinks != null)
                parameters.Add(MarkdownRenderer.Options.NoFollowLinks, MarkdownRenderer.BoolToString(NoFollowLinks));
            if(!String.IsNullOrEmpty(HtmlClassFootnotes))
                parameters.Add(MarkdownRenderer.Options.HtmlClassFootnotes, HtmlClassFootnotes);
            if (!String.IsNullOrEmpty(HtmlClassTitledImages))
                parameters.Add(MarkdownRenderer.Options.HtmlClassTitledImages, HtmlClassTitledImages);
        }


    }
}
