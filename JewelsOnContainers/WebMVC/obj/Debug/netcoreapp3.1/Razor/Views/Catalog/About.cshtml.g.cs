#pragma checksum "C:\Users\Admin\source\repos\JewelsOnContainers\WebMVC\Views\Catalog\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc7848765b7ae4fe9f06b3c7e574463d59aabb34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Catalog_About), @"mvc.1.0.view", @"/Views/Catalog/About.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\JewelsOnContainers\WebMVC\Views\_ViewImports.cshtml"
using WebMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\JewelsOnContainers\WebMVC\Views\_ViewImports.cshtml"
using WebMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\source\repos\JewelsOnContainers\WebMVC\Views\Catalog\About.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc7848765b7ae4fe9f06b3c7e574463d59aabb34", @"/Views/Catalog/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d07e873f05b36c9d83cd6a184d4bfbe1720fee4b", @"/Views/_ViewImports.cshtml")]
    public class Views_Catalog_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<h2>Access Token</h2>\r\n<dl>\r\n");
#nullable restore
#line 8 "C:\Users\Admin\source\repos\JewelsOnContainers\WebMVC\Views\Catalog\About.cshtml"
     foreach (var claim in User.Claims)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 10 "C:\Users\Admin\source\repos\JewelsOnContainers\WebMVC\Views\Catalog\About.cshtml"
       Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd>");
#nullable restore
#line 11 "C:\Users\Admin\source\repos\JewelsOnContainers\WebMVC\Views\Catalog\About.cshtml"
       Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 12 "C:\Users\Admin\source\repos\JewelsOnContainers\WebMVC\Views\Catalog\About.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <dt>access token</dt>\r\n    <dd>");
#nullable restore
#line 15 "C:\Users\Admin\source\repos\JewelsOnContainers\WebMVC\Views\Catalog\About.cshtml"
   Write(await ViewContext.HttpContext.GetTokenAsync("access_token"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>refresh token</dt>\r\n    <dd>");
#nullable restore
#line 17 "C:\Users\Admin\source\repos\JewelsOnContainers\WebMVC\Views\Catalog\About.cshtml"
   Write(await ViewContext.HttpContext.GetTokenAsync("refresh_token"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n</dl>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
