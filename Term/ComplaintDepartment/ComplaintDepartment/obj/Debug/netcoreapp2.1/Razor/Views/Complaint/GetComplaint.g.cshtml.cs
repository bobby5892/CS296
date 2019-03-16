#pragma checksum "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a57c6adbe6f37e95abd564bb7f3f35333d7cbaa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Complaint_GetComplaint), @"mvc.1.0.view", @"/Views/Complaint/GetComplaint.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Complaint/GetComplaint.cshtml", typeof(AspNetCore.Views_Complaint_GetComplaint))]
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
#line 1 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\_ViewImports.cshtml"
using ComplaintDepartment;

#line default
#line hidden
#line 2 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\_ViewImports.cshtml"
using ComplaintDepartment.Models;

#line default
#line hidden
#line 4 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a57c6adbe6f37e95abd564bb7f3f35333d7cbaa", @"/Views/Complaint/GetComplaint.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24754aad675f46e9eed7e4ef4f42fa2e6c353e74", @"/Views/_ViewImports.cshtml")]
    public class Views_Complaint_GetComplaint : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ComplaintDepartment.Models.View.ComplaintAndComments>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
  
    ViewData["Title"] = "Get Complaint";

#line default
#line hidden
            BeginContext(111, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(137, 57, true);
            WriteLiteral("<div class=\"complaint\">\r\n    <div class=\"complaint-date\">");
            EndContext();
            BeginContext(195, 36, false);
#line 9 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
                           Write(Model.Complaint.Create.ToLocalTime());

#line default
#line hidden
            EndContext();
            BeginContext(231, 44, true);
            WriteLiteral("</div>\r\n    <div class=\"complaint-contents\">");
            EndContext();
            BeginContext(276, 24, false);
#line 10 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
                               Write(Model.Complaint.Contents);

#line default
#line hidden
            EndContext();
            BeginContext(300, 119, true);
            WriteLiteral("</div>\r\n    <div class=\"complaint-markcomplete\">\r\n        <button class=\"complaint-mark-icon btn btn-primary\" data-id=\"");
            EndContext();
            BeginContext(420, 18, false);
#line 12 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
                                                                Write(Model.Complaint.ID);

#line default
#line hidden
            EndContext();
            BeginContext(438, 4, true);
            WriteLiteral("\">\r\n");
            EndContext();
#line 13 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
             if (!Model.Complaint.Completed)
            {

#line default
#line hidden
            BeginContext(503, 44, true);
            WriteLiteral("                <span>Mark Complete</span>\r\n");
            EndContext();
#line 16 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(595, 46, true);
            WriteLiteral("                <span>Mark Incomplete</span>\r\n");
            EndContext();
#line 20 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
            }

#line default
#line hidden
            BeginContext(656, 133, true);
            WriteLiteral("        </button>\r\n    </div>\r\n    <div class=\"complaint-addcomment\"><button class=\"complaint-mark-comment btn btn-primary\" data-id=\"");
            EndContext();
            BeginContext(790, 18, false);
#line 23 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
                                                                                                 Write(Model.Complaint.ID);

#line default
#line hidden
            EndContext();
            BeginContext(808, 128, true);
            WriteLiteral("\">Comment</button></div>\r\n    <div class=\"complaint-addcomment\"><button class=\"complaint-delete-button btn btn-danger\" data-id=\"");
            EndContext();
            BeginContext(937, 18, false);
#line 24 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
                                                                                                 Write(Model.Complaint.ID);

#line default
#line hidden
            EndContext();
            BeginContext(955, 59, true);
            WriteLiteral("\">Delete</button></div>\r\n    \r\n    <div class=\"comments\">\r\n");
            EndContext();
#line 27 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
         if (Model.Comments.Count == 0)
        {

#line default
#line hidden
            BeginContext(1066, 36, true);
            WriteLiteral("            <div>No Comments</div>\r\n");
            EndContext();
#line 30 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
        }
        else
        {
            foreach (var comment in Model.Comments)
            {

#line default
#line hidden
            BeginContext(1206, 83, true);
            WriteLiteral("                <div class=\"comment\">\r\n                    <span>Comment</span><p> ");
            EndContext();
            BeginContext(1290, 16, false);
#line 36 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
                                       Write(comment.Contents);

#line default
#line hidden
            EndContext();
            BeginContext(1306, 66, true);
            WriteLiteral("</p><button class=\"delete-comment-button btn btn-danger\" data-id=\"");
            EndContext();
            BeginContext(1373, 10, false);
#line 36 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
                                                                                                                          Write(comment.ID);

#line default
#line hidden
            EndContext();
            BeginContext(1383, 43, true);
            WriteLiteral("\">Delete</button>\r\n                </div>\r\n");
            EndContext();
#line 38 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(1452, 20, true);
            WriteLiteral("    </div>\r\n</div>\r\n");
            EndContext();
#line 42 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1484, 34, true);
            WriteLiteral("    <div>No such Complaint</div>\r\n");
            EndContext();
#line 46 "C:\code\CS296\Term\ComplaintDepartment\ComplaintDepartment\Views\Complaint\GetComplaint.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ComplaintDepartment.Models.View.ComplaintAndComments> Html { get; private set; }
    }
}
#pragma warning restore 1591
