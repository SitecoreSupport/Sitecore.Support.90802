# Sitecore.Support.90802
Allows to render the `title` attribute of an image in the `<img>` tag

## Description
An image is not rendered with the `title` attribute in the `<img>` tag when using:
* `<sc:image>` control in XSL rendering (.xslt)
* `<sc:Image>` control in ASP.NET Web Forms layout or sublayout (.aspx or .ascx)
* `@Html.Sitecore().Field("Image")` helper in ASP.NET MVC rendering (.cshtml)

<br/>
This patch allows to render the mentioned attribute.

## License  
This patch is licensed under the [Sitecore Corporation A/S License for GitHub](https://github.com/sitecoresupport/Sitecore.Support.90802/blob/master/LICENSE).  

## Download  
Downloads are available via [GitHub Releases](https://github.com/sitecoresupport/Sitecore.Support.90802/releases).  
