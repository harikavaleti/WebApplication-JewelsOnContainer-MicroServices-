#pragma checksum "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8843de4dcf18d3b570acd0f72df3a37c4a063f9c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CartList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CartList/Default.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\_ViewImports.cshtml"
using WebMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\_ViewImports.cshtml"
using WebMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8843de4dcf18d3b570acd0f72df3a37c4a063f9c", @"/Views/Shared/Components/CartList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d07e873f05b36c9d83cd6a184d4bfbe1720fee4b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CartList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebMVC.Models.Cart>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
  
    ViewData["Title"] = "My Cart";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n");
#nullable restore
#line 8 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
     if (TempData.ContainsKey("BasketInoperativeMsg"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n        <div class=\"alert alert-warning\" role=\"alert\">\r\n            &nbsp;");
#nullable restore
#line 12 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
             Write(TempData["BasketInoperativeMsg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 14 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <article class=\"esh-basket-titles row\">\r\n            <br />\r\n");
#nullable restore
#line 19 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
             if (TempData.ContainsKey("BasketInoperativeMsg"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-warning\" role=\"alert\">\r\n                    &nbsp;");
#nullable restore
#line 22 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
                     Write(TempData["BasketInoperativeMsg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 24 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <section class=""esh-basket-title col-xs-3"">Product</section>
            <section class=""esh-basket-title col-xs-3 hidden-lg-down""></section>
            <section class=""esh-basket-title col-xs-2"">Price</section>
            <section class=""esh-basket-title col-xs-2"">Quantity</section>
            <section class=""esh-basket-title col-xs-2"">Cost</section>
        </article>
");
#nullable restore
#line 33 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
         for (int i = 0; i < Model.Items.Count; i++)
        {
            var item = Model.Items[i];


#line default
#line hidden
#nullable disable
            WriteLiteral("            <article class=\"esh-basket-items  row\">\r\n                <div>\r\n                    <section class=\"esh-basket-item esh-basket-item--middle col-lg-3 hidden-lg-down\">\r\n                        <img class=\"esh-basket-image\"");
            BeginWriteAttribute("src", " src=\"", 1377, "\"", 1399, 1);
#nullable restore
#line 40 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
WriteAttributeValue("", 1383, item.PictureUrl, 1383, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </section>\r\n                    <section class=\"esh-basket-item esh-basket-item--middle col-xs-3\">");
#nullable restore
#line 42 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
                                                                                 Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n                    <section class=\"esh-basket-item esh-basket-item--middle col-xs-2\">$ ");
#nullable restore
#line 43 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
                                                                                   Write(item.UnitPrice.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n                    <section class=\"esh-basket-item esh-basket-item--middle col-xs-2\">\r\n                        <input type=\"hidden\"");
            BeginWriteAttribute("name", " name=\"", 1814, "\"", 1850, 1);
#nullable restore
#line 45 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
WriteAttributeValue("", 1821, "quantities[" + i +"].Key", 1821, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1851, "\"", 1867, 1);
#nullable restore
#line 45 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
WriteAttributeValue("", 1859, item.Id, 1859, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        <input type=\"number\" class=\"esh-basket-input\" min=\"1\"");
            BeginWriteAttribute("name", " name=\"", 1950, "\"", 1988, 1);
#nullable restore
#line 46 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
WriteAttributeValue("", 1957, "quantities[" + i +"].Value", 1957, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1989, "\"", 2011, 1);
#nullable restore
#line 46 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
WriteAttributeValue("", 1997, item.Quantity, 1997, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </section>\r\n                    <section class=\"esh-basket-item esh-basket-item--middle esh-basket-item--mark col-xs-2\">$ ");
#nullable restore
#line 48 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
                                                                                                         Write(Math.Round(item.Quantity * item.UnitPrice, 2).ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n                </div>\r\n                <div class=\"row\">\r\n\r\n                </div>\r\n            </article>\r\n");
            WriteLiteral("            <div class=\"esh-basket-items--border row\">\r\n");
#nullable restore
#line 56 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
                 if (item.OldUnitPrice != 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-warning esh-basket-margin12\" role=\"alert\">&nbsp;Note that the price of this article changed in our Catalog. The old price when you originally added it to the basket was $ ");
#nullable restore
#line 58 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
                                                                                                                                                                                                                  Write(item.OldUnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n");
#nullable restore
#line 59 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <br />\r\n");
#nullable restore
#line 62 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""container"">
            <article class=""esh-basket-titles esh-basket-titles--clean row"">
                <section class=""esh-basket-title col-xs-10""></section>
                <section class=""esh-basket-title col-xs-2"">Total</section>
            </article>

            <article class=""esh-basket-items row"">
                <section class=""esh-basket-item col-xs-10""></section>
                <section class=""esh-basket-item esh-basket-item--mark col-xs-2"">$ ");
#nullable restore
#line 72 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
                                                                             Write(Model.Total());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</section>
            </article>

            <article class=""esh-basket-items row"">
                <section class=""esh-basket-item col-xs-7""></section>
                <section class=""esh-basket-item col-xs-2"">
                    <button class=""btn esh-basket-checkout"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 3573, "\"", 3581, 0);
            EndWriteAttribute();
            WriteLiteral(@" type=""submit"">[ Update ]</button>
                </section>
                <section class=""esh-basket-item col-xs-3"">
                    <input type=""submit""
                           class=""btn esh-basket-checkout""
                           value=""[ Checkout ]"" name=""action"" />
                </section>
            </article>
        </div>
");
#nullable restore
#line 87 "C:\Users\Admin\Desktop\Git\WebApplication-JewelsOnContainer-MicroServices-\JewelsOnContainers\WebMVC\Views\Shared\Components\CartList\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebMVC.Models.Cart> Html { get; private set; }
    }
}
#pragma warning restore 1591
