#pragma checksum "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Blog\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4e191f36d726e6e6a004b50dfa5e1a45a208de5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Blog_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Blog/Default.cshtml")]
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
using Repository.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\_ViewImports.cshtml"
using Repository.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4e191f36d726e6e6a004b50dfa5e1a45a208de5", @"/Views/Shared/Components/Blog/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c16e4871e289cb2a74a5f7660158c90c306208eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Blog_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Blog>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Blog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn primary-button blog-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Blog\Default.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-xl-4 col-lg-4 col-md-6 mb-md-5 mb-sm-5\">\r\n        <div class=\"blog-cart\">\r\n            <div class=\"blog-image\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a4e191f36d726e6e6a004b50dfa5e1a45a208de55535", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 222, "~/Uploads/", 222, 10, true);
#nullable restore
#line 9 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Blog\Default.cshtml"
AddHtmlAttributeValue("", 232, item.Image, 232, 11, false);

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
            WriteLiteral("\r\n            </div>\r\n            <div class=\"blog-content\">\r\n                <div class=\"blog-athor-date\">\r\n                    <span> By,<a class=\"blog-author\" href=\"#\"> ");
#nullable restore
#line 13 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Blog\Default.cshtml"
                                                          Write(item.User.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 13 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Blog\Default.cshtml"
                                                                          Write(item.User.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></span>\r\n                    <span class=\"blog-date\">");
#nullable restore
#line 14 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Blog\Default.cshtml"
                                       Write(item.AddedDate.Date.ToString("dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <h5 class=\"blog-heading\">\r\n                    <a class=\"blog-heading-link\" href=\"#\">\r\n                     ");
#nullable restore
#line 18 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Blog\Default.cshtml"
                Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </a>\r\n                </h5>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4e191f36d726e6e6a004b50dfa5e1a45a208de58705", async() => {
                WriteLiteral(" Read More");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Blog\Default.cshtml"
                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 25 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Components\Blog\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Blog>> Html { get; private set; }
    }
}
#pragma warning restore 1591
