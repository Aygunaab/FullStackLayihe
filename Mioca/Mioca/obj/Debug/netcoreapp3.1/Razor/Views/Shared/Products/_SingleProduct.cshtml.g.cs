#pragma checksum "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ed7c12117f1216a625afb4d8ae4f4074978fb76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Products__SingleProduct), @"mvc.1.0.view", @"/Views/Shared/Products/_SingleProduct.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\_ViewImports.cshtml"
using Mioca;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\_ViewImports.cshtml"
using Mioca.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\_ViewImports.cshtml"
using Repository.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ed7c12117f1216a625afb4d8ae4f4074978fb76", @"/Views/Shared/Products/_SingleProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94991d457a1828761becb784737d0d36be7bb5c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Products__SingleProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hover-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddBasket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Add To Cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("add-to-cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n    <div class=\"product\">\r\n        <div class=\"product-item  \">\r\n            <div class=\"product-image-box\">\r\n                <a href=\"product-details.html\" class=\"product-img\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6ed7c12117f1216a625afb4d8ae4f4074978fb765906", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 239, "~/assets/images/product-image/", 239, 30, true);
#nullable restore
#line 8 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
AddHtmlAttributeValue("", 269, Model.Photos.First(), 269, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                 if (Model.Photos.Count > 0)
                {

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6ed7c12117f1216a625afb4d8ae4f4074978fb767737", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 399, "~/assets/images/product-image/", 399, 30, true);
#nullable restore
#line 10 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
AddHtmlAttributeValue("", 429, Model.Photos.First(), 429, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 10 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
AddHtmlAttributeValue("", 457, Model.Name, 457, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6ed7c12117f1216a625afb4d8ae4f4074978fb7610080", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 580, "~/assets/images/product-image/", 580, 30, true);
#nullable restore
#line 14 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
AddHtmlAttributeValue("", 610, Model.Photos.First(), 610, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 14 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
AddHtmlAttributeValue("", 638, Model.Name, 638, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 15 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </a>\r\n                <span class=\"product-price-badges\">\r\n");
#nullable restore
#line 20 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                     if (Model.Discount != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"sale\">-");
#nullable restore
#line 22 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                                       Write(Model.Discount.Percentage.ToString("#.##"));

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n");
#nullable restore
#line 23 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                     if (Model.Discount == null && Model.Label != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"new\"");
            BeginWriteAttribute("style", " style=\"", 1081, "\"", 1124, 2);
            WriteAttributeValue("", 1089, "background-color:", 1089, 17, true);
#nullable restore
#line 26 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
WriteAttributeValue("", 1106, Model.Label.Color, 1106, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">New</span>\r\n");
#nullable restore
#line 27 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                </span>
                <div class=""actions"">
                    <a href=""wishlist.html"" class=""action wishlist"" title=""Wishlist"">
                        <i class=""pe-7s-like""></i>
                    </a>
                    <a href=""#"" class=""action quickview"" title=""Quick view"" data-bs-toggle=""modal""
                       data-bs-target=""#staticBackdrop""><i class=""pe-7s-look""></i></a>
                    <a href=""compare.html"" class=""action compare"" title=""Compare"">
                        <i class=""pe-7s-refresh-2""></i>
                    </a>
                </div>
            </div>

            <div class=""content"">
                <div class=""details-rating-wrap"">
                    <div class=""rating-product"">
");
#nullable restore
#line 47 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                         for (int i = 1; i <= 5; i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i");
            BeginWriteAttribute("class", " class=\"", 2045, "\"", 2101, 3);
            WriteAttributeValue("", 2053, "fa", 2053, 2, true);
            WriteAttributeValue(" ", 2055, "fa-star", 2056, 8, true);
#nullable restore
#line 49 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
WriteAttributeValue(" ", 2063, Model.StarCount+1 <=i ?"empty":"" , 2064, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n");
#nullable restore
#line 50 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                    </div>
                    <span class=""rating-number""><a class=""reviews"" href=""#"">( 2 Review )</a></span>
                </div>
                <h5 class=""product-title"">
                    <a href=""product-details.html"">
                        ");
#nullable restore
#line 58 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </a>\r\n                </h5>\r\n                <span class=\"price\">\r\n\r\n");
#nullable restore
#line 63 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                     if (Model.Discount == null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"new\">");
#nullable restore
#line 65 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                                     Write(Model.Price.ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("₼</span>\r\n");
#nullable restore
#line 66 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                    }
                    else
                    {
                        var price = Model.Price - (Model.Price * Model.Discount.Percentage / 100);

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"new\">");
#nullable restore
#line 70 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                                     Write(price.ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <span class=\"old\">");
#nullable restore
#line 71 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                                     Write(Model.Price.ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("₼</span>\r\n");
#nullable restore
#line 72 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                </span>\r\n            </div>\r\n          \r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ed7c12117f1216a625afb4d8ae4f4074978fb7618769", async() => {
                WriteLiteral("\r\n                Add\r\n                To Cart\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 80 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Products\_SingleProduct.cshtml"
                                                              WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n        <!--Product card end  -->\r\n    </div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
