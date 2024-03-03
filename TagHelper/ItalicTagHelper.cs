using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.web.TagHelpers
{
    public class ItalicTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "i"; // Çıktı olarak <i> etiketi kullanılacak
            output.TagMode = TagMode.StartTagAndEndTag; // Başlangıç ve bitiş etiketi olarak kullanılacak

            // InnerHtml'e <i> etiketi arasına alınacak içeriği ekleyin
            output.PreContent.SetHtmlContent("<i>");
            output.PostContent.SetHtmlContent("</i>");
        }
    }
}
