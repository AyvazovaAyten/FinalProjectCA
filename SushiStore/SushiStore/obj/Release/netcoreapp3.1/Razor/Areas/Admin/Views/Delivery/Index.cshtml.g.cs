#pragma checksum "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\Delivery\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7493d4ac069535da35647d52150c2540653f1d7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Delivery_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Delivery/Index.cshtml")]
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
#line 1 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\_ViewImports.cshtml"
using SushiStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\_ViewImports.cshtml"
using SushiStore.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\_ViewImports.cshtml"
using SushiStore.DTO.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\_ViewImports.cshtml"
using SushiStore.DTO.User;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7493d4ac069535da35647d52150c2540653f1d7c", @"/Areas/Admin/Views/Delivery/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0d9f6466c393b21c13d2b8ae96631c9efa9985e", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Delivery_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Delivery>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\Delivery\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 d-flex align-items-stretch justify-content-end mb-4\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7493d4ac069535da35647d52150c2540653f1d7c4640", async() => {
                WriteLiteral("Update Delivery Page");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>
<div class=""row"">
    <div class=""col-lg-12 grid-margin stretch-card"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title"">Details</h4>
                <div class=""table-responsive pt-3"">
                    <table class=""table table-bordered"" style=""table-layout: fixed;"">
                        <thead>
                            <tr>
                                <th>
                                    Delivery Info
                                </th>
                                <th>
                                    Delivery Details
                                </th>
                            </tr>
                        </thead>
                        <tbody>

                            <tr>
                                <td style=""word-wrap: break-word; width: 200px; white-space:unset; vertical-align:baseline;"">

                                    ");
#nullable restore
#line 35 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\Delivery\Index.cshtml"
                               Write(Html.Raw(Model.Info));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </td>
                                <td style=""word-wrap: break-word; width: 200px; white-space:unset; vertical-align:baseline;"">

                                    <div class=""table-responsive mb-40"">
                                        <table class=""table text-center"">
                                            <thead>
                                                <tr>
                                                    <th>Çatdırılma Ünvanı<br></th>
                                                    <th>Çatdırılma Müddəti<br></th>
                                                    <th>Minimum Sifariş Məbləği<br></th>
                                                </tr>
                                            </thead>
                                            <tbody>
");
#nullable restore
#line 50 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\Delivery\Index.cshtml"
                                                 foreach (DeliveryAdress adress in Model.DeliveryAdresses)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr>\r\n                                                        <td>");
#nullable restore
#line 53 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\Delivery\Index.cshtml"
                                                       Write(adress.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;q.<br></td>\r\n                                                        <td>");
#nullable restore
#line 54 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\Delivery\Index.cshtml"
                                                       Write(adress.Time);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;dəq<br></td>\r\n                                                        <td>");
#nullable restore
#line 55 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\Delivery\Index.cshtml"
                                                       Write(adress.MinAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" AZN<br></td>\r\n                                                    </tr>\r\n");
#nullable restore
#line 57 "C:\Users\Шахвалад\source\repos\SushiStore\SushiStore\Areas\Admin\Views\Delivery\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            </tbody>
                                        </table>
                                    </div>

                                </td>
                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>


");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Delivery> Html { get; private set; }
    }
}
#pragma warning restore 1591
