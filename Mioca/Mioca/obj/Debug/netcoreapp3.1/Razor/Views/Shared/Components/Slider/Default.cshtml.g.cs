#pragma checksum "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f89d8dd9462aa34a06d608d0eaaf5043d870242e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Slider_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Slider/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f89d8dd9462aa34a06d608d0eaaf5043d870242e", @"/Views/Shared/Components/Slider/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8d58bb93cebf93ee8f308b91fb50a7c73c76a36", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Slider_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SliderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("slider-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<section class=\"hero arrow\"\r\n         style=\"background-image: url(assets/images/slider-image/slider-bg-1.jpg); padding-top: 100px;padding-bottom: 100px;\">\r\n    <div class=\"hero-slider\">\r\n\r\n");
#nullable restore
#line 6 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""single-slider"">
                <div class=""container align-self-center"">
                    <div class=""row"">
                        <div class=""col-xl-6 col-md-6 col-sm-6 align-self-center"">
                            <div class=""slider-content"">
                                <h2 class=""slider-title bg-gif"">");
#nullable restore
#line 13 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml"
                                                           Write(Html.Raw(item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br></h2>\r\n\r\n                                <span class=\"product-price\">\r\n                                    <span class=\"old-price\">\r\n                                        <span class=\"text-decoration-line-through\">$");
#nullable restore
#line 17 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml"
                                                                               Write(item.DiscountPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </span>\r\n                                    <span class=\"new-price primary-color\">- ");
#nullable restore
#line 19 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml"
                                                                       Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </span>\r\n\r\n");
#nullable restore
#line 22 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml"
                                 if (!string.IsNullOrEmpty(item.Endpoint))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 1224, "\"", 1245, 1);
#nullable restore
#line 24 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml"
WriteAttributeValue("", 1231, item.Endpoint, 1231, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn primary-button m-auto text-uppercase \">");
#nullable restore
#line 24 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml"
                                                                                                          Write(item.ActionText);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n");
#nullable restore
#line 25 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                               
                            </div>
                        </div>
                        <div class=""col-xl-6  col-md-6 col-sm-6 d-flex justify-content-center position-relative"">
                            <div class=""image-block"">
                                <div class=""hero-slide-image"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f89d8dd9462aa34a06d608d0eaaf5043d870242e7392", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1736, "~/assets/images/slider-image/", 1736, 29, true);
#nullable restore
#line 32 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml"
AddHtmlAttributeValue("", 1765, item.Image, 1765, 11, false);

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
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 39 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Slider\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SliderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591