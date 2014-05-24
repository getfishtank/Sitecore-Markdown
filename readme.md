How To Use
-----

When the installation is complete select the **Markdown** field type in your template.  Use the *Source* attribute of the field located in the items template to configure.  This way, your attributes are applied using *<sc:RenderField />* and when indexed/accessed via the ContentSearch API.  


![Markdown Field in Sitecore](/~/media/images/fishtank/markdown-01-field-in-sitecore.jpg "Markdown ")

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

* = with **extramode** enabled

The most frequently used options are **safemode** & **extramode**.  Options are declared in a query string format:  

```
// The settings used for this blog post!
safemode=0&extramode=1&markdowninhtml=0

// Markdown only please, safemode=1 is great to constrain content authoring
safemode=1&extramode=1&markdowninhtml=0&htmlclassfootnotes=footnote-class
```

Use it in a page like any other field:

```HTML
&lt;sc:renderField FieldName="YourMarkdownField" runat="server" /&gt;
```

OOTB the *Fishtank.Markdown.config* adds a line to *<mapFieldByTypeName>* so Markdown fields are handled by the ContentSearch API as well.

```XML
&lt;contentSearch&gt;
  &lt;configuration&gt;
	&lt;defaultIndexConfiguration&gt;
	  &lt;fieldReaders&gt;
		&lt;mapFieldByTypeName&gt;
		  &lt;fieldReader fieldTypeName="markdown" fieldReaderType="Fishtank.CustomFields.Markdown.FieldReaders.MarkdownFieldReader, Fishtank.CustomFields.Markdown" /&gt;
		&lt;/mapFieldByTypeName&gt;
	  &lt;/fieldReaders&gt;
	&lt;/defaultIndexConfiguration&gt;
  &lt;/configuration&gt;
&lt;/contentSearch&gt;
```

Markdown Syntax
---

Markdown for Sitecore is built on top of [MarkdownDeep](http://www.toptensoftware.com/markdowndeep/).  For syntax on how to author Markdown content I'd recommend:

* [PHP Markdown Extra](http://michelf.ca/projects/php-markdown/extra/) (Markdown for Sitecore does not support [special attributes](http://michelf.ca/projects/php-markdown/extra/#spe-attr) yet)
* [Markdown Syntax](http://daringfireball.net/projects/markdown/syntax)

Quick &amp; Easy Installation
----

To get up and running quickly download and install package for your Sitecore version below. Select **merge/merge** if prompted during install.

* [Sitecore-7-Markdown-1.0.zip](https://github.com/getfishtank/Sitecore-Markdown/raw/master/ready-to-install/Markdown-For-Sitecore-7-1.0.zip)
* [Sitecore-6-Markdown-1.0.zip](https://github.com/getfishtank/Sitecore-Markdown/raw/master/ready-to-install/Markdown-For-Sitecore-6-1.0.zip)

Each Sitecore package contains:

Type|Location|
-----|---------
Item|core:///sitecore/system/Field types/Custom Types
Item|core://sitecore/system/Field types/Custom Types/Markdown
Config|/App_Config/Include/Fishtank.Markdown.config
DLL|/bin/Fisthank.CustomFields.Markdown.dll

Advanced Installation
----

To build your own version of Markdown for Sitecore and integrate into your Visual Studio solution, you can [find it's Github repo here](https://github.com/getfishtank/Sitecore-Markdown/) as well as the [Sitecore 7](https://github.com/getfishtank/Sitecore-Markdown/tree/master/Sitecore-7) and [Sitecore 6](https://github.com/getfishtank/Sitecore-Markdown/tree/master/Sitecore-6) versions respectively. 

Here is a high-level overview of the steps to integrate it into your solution:

* Install the sitecore package
* Add the project to your existing solution
* Add appropriate Sitecore references (*Sitecore.Kernel.dll*, *Sitecore.ContentSearch*) to the project
* Add the *Fishtank.Markdown.config* to your */App_Config/Include*
