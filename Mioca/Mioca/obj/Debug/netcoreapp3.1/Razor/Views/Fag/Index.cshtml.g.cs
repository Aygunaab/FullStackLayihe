#pragma checksum "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Fag\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b34d322f69e19f679f54da127e0f414aef018589"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fag_Index), @"mvc.1.0.view", @"/Views/Fag/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b34d322f69e19f679f54da127e0f414aef018589", @"/Views/Fag/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c16e4871e289cb2a74a5f7660158c90c306208eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Fag_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Fag>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Fag\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>
    <!--breadcrumb section start-->
    <section class=""breadcrumb-section"">
        <div class=""container"">
            <div class=""row align-items-center justify-content-center"">
                <div class=""col-12 text-center"">
                    <h1 class=""page-name "">Fag</h1>
                    <nav class=""d-flex justify-content-center"" aria-label=""breadcrumb"">
                        <ol class=""breadcrumb"">
                            <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b34d322f69e19f679f54da127e0f414aef0185894859", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                            <li class=""breadcrumb-item active"" aria-current=""page"">Fag</li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!--breadcrumb section end-->
    <section class=""section-style-two"">
        <div class=""container"">
            <div class=""row justify-content-center"">
                <div class=""col-9"">
                    <div class=""fag-title-desk"">
                        <h4 class=""title-fag bg-gif"">
                            Below are frequently asked questions, you may find the answer
                            for yourself
                        </h4>
                        <p class=""fag-desk"">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec id erat
                            sagittis, faucibus
                            metus malesuada, eleifend turpis. Mauris semper augue id nisl aliquet, a porta lectus
           ");
            WriteLiteral(@"                 mattis. Nulla at tortor augue. In eget enim diam.
                            Donec gravida tortor sem, ac fermentum nibh rutrum sit amet. Nulla convallis mauris
                            vitae congue consequat. Donec interdum nunc purus, vitae vulputate arcu fringilla quis.
                            Vivamus iaculis euismod dui.
                        </p>
                    </div>
                    <div id=""fag-accordion"" class=""mt-5"">
");
#nullable restore
#line 44 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Fag\Index.cshtml"
                          int i = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Fag\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3 class=\"mt-2\">\r\n                                <span class=\"number\">");
#nullable restore
#line 48 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Fag\Index.cshtml"
                                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</span><a href=\"#\">\r\n                                   ");
#nullable restore
#line 49 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Fag\Index.cshtml"
                              Write(item.Question);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </a>\r\n                            </h3>\r\n                            <div >\r\n                                <p>\r\n                                   ");
#nullable restore
#line 54 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Fag\Index.cshtml"
                              Write(Html.Raw(item.Answer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n                            </div>\r\n");
#nullable restore
#line 57 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Fag\Index.cshtml"
                                { i++; }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</main>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Fag>> Html { get; private set; }
    }
}
#pragma warning restore 1591