#pragma checksum "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "850618889e0039eb05c021ad4354c50ef8af77e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CartSummaryPartial), @"mvc.1.0.view", @"/Views/Shared/_CartSummaryPartial.cshtml")]
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
#line 1 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Builder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\_ViewImports.cshtml"
using SushiStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\_ViewImports.cshtml"
using SushiStore.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"850618889e0039eb05c021ad4354c50ef8af77e0", @"/Views/Shared/_CartSummaryPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"765dfd6a5c3e181494383e9b90c41d6fb7a445b1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CartSummaryPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Product Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("product_title"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cart-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CheckOut", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cart-btn buy"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"shoppingBag\">\r\n    <div class=\"bag-content\">\r\n        <div class=\"bag-title\">");
#nullable restore
#line 3 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                          Write(Localizer["Cart"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (<span id=\"cart-summary-count\">");
#nullable restore
#line 3 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                                                            Write(ViewData["CartCount"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>)</div>\r\n        <div class=\"basket_products\">\r\n");
#nullable restore
#line 5 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
             foreach (CartProduct product in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"basket-product\" data-key=\"");
#nullable restore
#line 7 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                                 Write(product.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                    <div class=\"product__image\" data-link=\"https://www.bakenroll.az/en/dish/sushi-tort\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "850618889e0039eb05c021ad4354c50ef8af77e08297", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 500, "~/assets/images/products/", 500, 25, true);
#nullable restore
#line 9 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
AddHtmlAttributeValue("", 525, product.Image, 525, 14, false);

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
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"product__info\">\r\n                        <div class=\"left-col\">\r\n                            <p class=\"cart-text\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "850618889e0039eb05c021ad4354c50ef8af77e010116", async() => {
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 16 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                               Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
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
#line 14 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                                                                 WriteLiteral(product.ProductId);

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
            WriteLiteral("\r\n                            </p>\r\n                            <p class=\"cart-text count\">");
#nullable restore
#line 19 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                                  Write(Localizer["Count"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(": <span id=\"summary-count\">");
#nullable restore
#line 19 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                                                                                Write(product.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </p>\r\n                        </div>\r\n                        <div class=\"right-col\">\r\n                            <p class=\"cart-text price current-price\">");
#nullable restore
#line 22 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                                                Write(product.CurrentPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" AZN</p>\r\n                            <div data-id=\"");
#nullable restore
#line 23 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                     Write(product.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-count=\"");
#nullable restore
#line 23 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                                                     Write(product.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"del-btn cart-summary-del-btn\"><i class=\"fas fa-trash-alt\"></i></div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 27 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"basket_footer\">\r\n            <div class=\"cart-row col-12 total-price-row\">\r\n                <p class=\"cart-text column-4\">");
#nullable restore
#line 31 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                         Write(Localizer["Total"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p><span class=\"cart-summary-total\">");
#nullable restore
#line 32 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                               Write(ViewData["TotalPrice"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> AZN</p>\r\n            </div>\r\n            <div class=\"delivery-info\">\r\n                <div class=\"cart-row\">\r\n                    <p>");
#nullable restore
#line 36 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                  Write(Localizer["MinAmount"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>10 AZN</p>\r\n                </div>\r\n            </div>\r\n            <div class=\"cart-row col-12\">\r\n                <div class=\"btn-box\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "850618889e0039eb05c021ad4354c50ef8af77e016636", async() => {
#nullable restore
#line 41 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                                                                             Write(Localizer["ShowBasket"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n                <div class=\"btn-box\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "850618889e0039eb05c021ad4354c50ef8af77e018415", async() => {
#nullable restore
#line 43 "C:\Users\ayvaz\OneDrive\Рабочий стол\SushiStore\SushiStore\Views\Shared\_CartSummaryPartial.cshtml"
                                                                                   Write(Localizer["Buy"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOptions<RequestLocalizationOptions> LocOptions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
