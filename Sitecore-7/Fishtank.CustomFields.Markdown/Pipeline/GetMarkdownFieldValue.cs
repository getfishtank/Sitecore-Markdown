using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Collections;
using Sitecore.Pipelines.RenderField;

namespace Fishtank.CustomFields.Markdown.Pipeline
{

    /// <summary>
    /// Implements the RenderField.
    /// 
    /// </summary>
    public class GetMarkdownFieldValue
    {

        /// <summary>
        /// Gets the field value.
        /// 
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void Process(RenderFieldArgs args)
        {
            string fieldTypeKey = args.FieldTypeKey;
            if (fieldTypeKey != "markdown") return;

            // This will have our fields value
            //
            // args.Result.FirstPart 

            args.DisableWebEdit = true;

            string rawMarkdown = args.Result.FirstPart;
            
            // Parameters from the fields source
            var parametersFromSource = MarkdownRenderer.MergeSourceValuesWithParameters(args.GetField().Source, args.Parameters);

            var parameters = parametersFromSource;

            args.Result.FirstPart = MarkdownRenderer.Render(rawMarkdown, parameters);

        }
    }
}