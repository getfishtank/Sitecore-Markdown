Markdown for Sitecore
-----

Created by Dan Cruickshank at [Fishtank](http://getfishtank.ca).

Please see this blog post for the most detailed instructions.

Purpose
----

To introduce a simpler, quicker, more elegant way to author content in Sitecore CMS.  

It's not meant to entirely replace HTML in all cases, but to complement it.  After all HTML is an XML publishing format.  Markdown is pure writing format.

How To Use
-----

When the installation is complete select the **Markdown** field type in your template.  Use the *Source* attribute of the field located in the items template to configure.  This way, your attributes are applied using *&lt;sc:RenderField /&gt;* and when indexed/accessed via the ContentSearch API.  


![Markdown Field in Sitecore](http://getfishtank.ca/~/media/images/fishtank/markdown-01-field-in-sitecore.jpg "Markdown ")

Configurable attributes are all have corresponding 1 (true) or 0 (false) values: 

 Attribute | Description 
------------|--------------
safemode | Allow a whitelisted common HTML tags to be used in authoring
extramode | Allow advanced Markdown authoring for tables, definition lists, fenced code blocks, footnotes, abbreviations & markdown inside of html
markdowninhtml | Allows Markdown syntax to be used inside of HTML elements*
autoheadingids| Headings are assigned IDs based on their text using the Pandoc algorithm*
newwindowforexternallinks | External links are assigned target="_blank"
newwindowforlocallinks | Site links are assigned target="_blank"
nofollowlinks | Adds a rel="nofollow" to links
htmlclassfootnotes | CSS class applied to footnotes*
htmlclasstitledimages | CSS class applied to title images*

\* = with **extramode** enabled

Use it in a page like any other field:

```HTML
<sc:renderField FieldName="YourMarkdownField" runat="server" />
```