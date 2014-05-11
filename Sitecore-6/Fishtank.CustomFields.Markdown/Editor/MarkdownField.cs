using System.Web.UI.WebControls;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.IO;
using Sitecore.Web.UI.Sheer;
using System;
using System.IO;
using System.Web.UI;
using System.Web;

namespace Fishtank.CustomFields.Markdown.Editor
{
    public class MarkdownField :Sitecore.Web.UI.HtmlControls.Memo
  {
    /// <summary>
    /// Gets or sets the item language.
    /// 
    /// </summary>
    /// 
    /// <value>
    /// The item language.
    /// </value>
    public string ItemLanguage
    {
      get
      {
        return StringUtil.GetString(this.ServerProperties["ItemLanguage"]);
      }
      set
      {
        this.ServerProperties["ItemLanguage"] = (object) value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the Markdown class.
    /// 
    /// </summary>
    public MarkdownField()
    {
      this.Class = "scContentControlMarkdown scContentControlMemo";
      this.Attributes.Add("style" , "height: 600px");
      this.Wrap = "soft";
      this.Activation = true;
    }

    /// <summary>
    /// Handles the message.
    /// 
    /// </summary>
    /// <param name="message">The message.</param>
    public override void HandleMessage(Message message)
    {
      Assert.ArgumentNotNull((object) message, "message");
      base.HandleMessage(message);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
    /// 
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
    protected override void OnPreRender(EventArgs e)
    {
      Assert.ArgumentNotNull((object) e, "e");
      base.OnPreRender(e);
      this.ServerProperties["Value"] = this.ServerProperties["Value"];
      this.Disabled = false;
    }

    /// <summary>
    /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter"/> object, which writes the content to be rendered on the client.
    /// 
    /// </summary>
    /// <param name="output">The <see cref="T:System.Web.UI.HtmlTextWriter"/> object that receives the server control content.</param>
    protected override void DoRender(HtmlTextWriter output)
    {
      this.SetWidthAndHeightStyle();
      output.Write("<textarea" + this.ControlAttributes + ">" + HttpUtility.HtmlEncode(this.Value));
      this.RenderChildren(output);
      output.Write("</textarea>");
    }

  }

}
