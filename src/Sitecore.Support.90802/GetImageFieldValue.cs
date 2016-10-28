using Sitecore.Data.Fields;
using Sitecore.Pipelines.RenderField;
using Sitecore.Xml.Xsl;
using System.Linq;
using System;

namespace Sitecore.Support.Pipelines.RenderField
{
    /// <summary>
    /// Implements the RenderField.
    /// </summary>
    public class GetImageFieldValue
    {
        /// <summary>
        /// Gets the field value.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <contract>
        ///   <requires name="args" condition="none" />
        /// </contract>
        public void Process(RenderFieldArgs args)
        {
            string fieldTypeKey = args.FieldTypeKey;
            if (fieldTypeKey != "image")
            {
                return;
            }
            ImageRenderer imageRenderer = this.CreateRenderer();
            imageRenderer.Item = args.Item;
            imageRenderer.FieldName = args.FieldName;
            imageRenderer.FieldValue = args.FieldValue;
            imageRenderer.Parameters = args.Parameters;
            // Begin of Sitecore.Support.90802
            if (!args.Parameters.Keys.Contains("title"))
            {
                Field innerField = args.Item.Fields[args.FieldName];
                ImageField imageField = new ImageField(innerField, args.FieldValue);
                if (imageField.MediaItem != null)
                {
                    imageRenderer.Parameters.Add("title", imageField.MediaItem.Fields["title"].Value);
                }
            }
            // End of Sitecore.Support.90802
            args.WebEditParameters.AddRange(args.Parameters);
            imageRenderer.Parameters.Add("la", args.Item.Language.Name);
            RenderFieldResult renderFieldResult = imageRenderer.Render();
            args.Result.FirstPart = renderFieldResult.FirstPart;
            args.Result.LastPart = renderFieldResult.LastPart;
            args.DisableWebEditContentEditing = true;
            args.DisableWebEditFieldWrapping = true;
            args.WebEditClick = "return Sitecore.WebEdit.editControl($JavascriptParameters, 'webedit:chooseimage')";
        }

        /// <summary>
        /// Creates the renderer.
        /// </summary>
        /// <returns>The renderer.</returns>
        protected virtual ImageRenderer CreateRenderer()
        {
            return new ImageRenderer();
        }
    }
}