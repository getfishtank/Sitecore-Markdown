using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Collections;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.FieldReaders;
using Sitecore.Data;
using Sitecore.Data.Fields;

namespace Fishtank.CustomFields.Markdown.FieldReaders
{
    public class MarkdownFieldReader : FieldReader
    {
        public override object GetFieldValue(IIndexableDataField indexableField)
        {
            Field field = (Field) (indexableField as SitecoreItemDataField);

            string fieldSource = field.Source;
            SafeDictionary<string> parameters = MarkdownRenderer.MergeSourceValuesWithParameters(fieldSource, new SafeDictionary<string>());


            string renderedMarkdown = MarkdownRenderer.Render(field.Value, parameters);

            return (object) renderedMarkdown;            
        }
    }
    
}
