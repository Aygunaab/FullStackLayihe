#pragma checksum "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f47e86a571b59727b06caaba0cc551aa8b7c9023"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Basket__NavbarBasket), @"mvc.1.0.view", @"/Views/Shared/Basket/_NavbarBasket.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f47e86a571b59727b06caaba0cc551aa8b7c9023", @"/Views/Shared/Basket/_NavbarBasket.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c16e4871e289cb2a74a5f7660158c90c306208eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Basket__NavbarBasket : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BasketViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "basket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"shop user-btn\">\r\n\r\n    <div class=\"btn-group\">\r\n        <a class=\"btn  dropdown-toggle\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\">\r\n            <i class=\"pe-7s-shopbag\"></i>\r\n");
#nullable restore
#line 7 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
             if (Model != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"header-action-num\">");
#nullable restore
#line 9 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                                           Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 10 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"header-action-num\">0</span>\r\n");
#nullable restore
#line 14 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </a>\r\n        <div class=\"dropdown-menu\">\r\n            <ul class=\"minicart-product\">\r\n");
#nullable restore
#line 20 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                 if (Model != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a href=\"product-details.html\">\r\n                                <figure>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f47e86a571b59727b06caaba0cc551aa8b7c90237863", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 838, "~/Uploads/", 838, 10, true);
#nullable restore
#line 26 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
AddHtmlAttributeValue("", 848, item.MainImage, 848, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</figure>\r\n                                <strong><span>Hand-Made Garlic Mortar</span>");
#nullable restore
#line 27 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                                                                       Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" x ");
#nullable restore
#line 27 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                                                                                        Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong>\r\n                            </a><strong><a class=\"remove-basket\" data-id=\"");
#nullable restore
#line 28 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                                                                     Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-price=\"");
#nullable restore
#line 28 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                                                                                           Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-quantity=\"");
#nullable restore
#line 28 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                                                                                                                       Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" href=\"#\">×</a></strong>\r\n\r\n\r\n                            <hr class=\"dropdown-divider\">\r\n                        </li>\r\n");
#nullable restore
#line 33 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                     
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li><span>Səbətiniz boşdur</span></li>\r\n");
#nullable restore
#line 38 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n\r\n");
#nullable restore
#line 41 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
             if (Model != null)
            {

                decimal subTotal = 0;
                foreach (var item in Model)
                {
                    subTotal += item.Price * item.Quantity;
                }



#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"total-drop\">\r\n                    <div class=\"clearfix\"><strong>Total</strong><span class=\"subTotal\">₼");
#nullable restore
#line 52 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
                                                                                   Write(subTotal.ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f47e86a571b59727b06caaba0cc551aa8b7c902313171", async() => {
                WriteLiteral("View Cart");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<a href=\"checkout.html\" class=\"btn btn-cart checkout\">Checkout</a>\r\n                </div>\r\n");
#nullable restore
#line 55 "C:\Users\Admin\OneDrive\Desktop\Mioca\Mioca\Views\Shared\Basket\_NavbarBasket.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BasketViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
