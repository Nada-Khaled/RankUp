#pragma checksum "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f52ff01740bf60ef836d0f650a7707981898e20b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 1 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\_ViewImports.cshtml"
using RankUp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\_ViewImports.cshtml"
using RankUp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f52ff01740bf60ef836d0f650a7707981898e20b", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55eb3dd419a25f53547f75f9ba95739dede72b17", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RankUp.Models.BoardUsers>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\Admin\Index.cshtml"
  

    Layout = "~/Views/Shared/_navBar.cshtml";
    ViewBag.Title = "RankUp - HR Panel";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""main-panel"">
    <div class=""content-wrapper"">
        <div class=""row"">
            <div class=""col-xl-3 col-sm-6 grid-margin stretch-card"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-9"">
                                <div class=""d-flex align-items-center align-self-start"">
                                    <h3 class=""mb-0"">18</h3>
                                    <p class=""text-success ml-2 mb-0 font-weight-medium"">+3%</p>
                                </div>
                            </div>
                            <div class=""col-3"">
                                <div class=""icon icon-box-success "">
                                    <span class=""mdi mdi-arrow-top-right icon-item""></span>
                                </div>
                            </div>
                        </div>
                        <h6 class=""text-muted f");
            WriteLiteral(@"ont-weight-normal"">Reviews Requests (Last 7 days)</h6>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-sm-6 grid-margin stretch-card"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-9"">
                                <div class=""d-flex align-items-center align-self-start"">
                                    <h3 class=""mb-0"">30</h3>
                                    <p class=""text-success ml-2 mb-0 font-weight-medium"">+2.1%</p>
                                </div>
                            </div>
                            <div class=""col-3"">
                                <div class=""icon icon-box-success"">
                                    <span class=""mdi mdi-arrow-top-right icon-item""></span>
                                </div>
                            </div>
                        </div>
      ");
            WriteLiteral(@"                  <h6 class=""text-muted font-weight-normal"">Reviews Completed (Last 7 days)</h6>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-sm-6 grid-margin stretch-card"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-9"">
                                <div class=""d-flex align-items-center align-self-start"">
                                    <h3 class=""mb-0"">1,300</h3>
                                    <p class=""text-success ml-2 mb-0 font-weight-medium"">+25</p>
                                </div>
                            </div>
                            <div class=""col-3"">
                                <div class=""icon icon-box-success"">
                                    <span class=""mdi mdi-arrow-top-right icon-item""></span>
                                </div>
                            </d");
            WriteLiteral(@"iv>
                        </div>
                        <h6 class=""text-muted font-weight-normal"">Total Numbers of Users</h6>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-sm-6 grid-margin stretch-card"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-9"">
                                <div class=""d-flex align-items-center align-self-start"">
                                    <h3 class=""mb-0"">1.84 Day(s)</h3>
                                    <p class=""text-danger ml-2 mb-0 font-weight-medium"">-0.8% Day(s)</p>
                                </div>
                            </div>
                            <div class=""col-3"">
                                <div class=""icon icon-box-danger "">
                                    <span class=""mdi mdi-arrow-bottom-right icon-item""></span>
                    ");
            WriteLiteral(@"            </div>
                            </div>
                        </div>
                        <h6 class=""text-muted font-weight-normal"">Average response time</h6>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-5 grid-margin stretch-card"">
                <div class=""card"">
                    <div class=""card-body"">
                        <h4 class=""card-title"">Total Reviews History</h4>
                        <canvas id=""transaction-history"" class=""transaction-chart""></canvas>
                    </div>
                </div>
            </div>
            <div class=""col-lg-7 grid-margin stretch-card"">
                <div class=""card"">
                    <div class=""card-body"">
                        <h4 class=""card-title"">Review history details</h4>
                        <canvas id=""linechart-multi"" style=""height:250px""></canvas>
                    </div>
             ");
            WriteLiteral(@"   </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-sm-4 grid-margin"">
                <div class=""card"">
                    <div class=""card-body"">
                        <h5>User Retention</h5>
                        <div class=""row"">
                            <div class=""col-7 col-sm-12 col-xl-8 my-auto"">
                                <div class=""d-flex d-sm-block d-md-flex align-items-center"">
                                    <h2 class=""mb-0"">26 User</h2>
                                    <p class=""text-success ml-2 mb-0 font-weight-medium"">+3.5%</p>
                                </div>
                                <h6 class=""text-muted font-weight-normal"">users re-used RankUp Services.</h6>
                            </div>
                            <div class=""col-5 col-sm-12 col-xl-4 text-center text-xl-right"">
                                <i style=""color: #1DB954;"" class=""icon-lg mdi mdi-account-convert ml-auto""></i>");
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-sm-4 grid-margin"">
                <div class=""card"">
                    <div class=""card-body"">
                        <h5>Active Users</h5>
                        <div class=""row"">
                            <div class=""col-8 col-sm-12 col-xl-8 my-auto"">
                                <div class=""d-flex d-sm-block d-md-flex align-items-center"">
                                    <h2 class=""mb-0"">2,301 User</h2>
                                    <p class=""text-success ml-2 mb-0 font-weight-medium"">+8.3%</p>
                                </div>
                                <h6 class=""text-muted font-weight-normal""> Users that registered and used rankUp Services</h6>
                            </div>
                            <div class=""col-4 col-sm-12 col-xl-4 text-center text-xl-right"">
                         ");
            WriteLiteral(@"       <i style=""color: #1DB954;"" class=""icon-lg mdi mdi-account-star-outline ml-auto""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-sm-4 grid-margin"">
                <div class=""card"">
                    <div class=""card-body"">
                        <h5>Currently Active HR</h5>
                        <div class=""row"">
                            <div class=""col-7 col-sm-12 col-xl-8 my-auto"">
                                <div class=""d-flex d-sm-block d-md-flex align-items-center"">
                                    <h2 class=""mb-0"">18 member</h2>
                                </div>
                                <h6 class=""text-muted font-weight-normal"">Number of active HR Users on the system</h6>
                            </div>
                            <div class=""col-5 col-sm-12 col-xl-4 text-center text-xl-right"">
                                <i s");
            WriteLiteral(@"tyle=""color: #1DB954;"" class=""icon-lg mdi mdi-account-check-outline ml-auto""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-12 grid-margin"">
                <div class=""card"">
                    <div class=""card-body"">
                        <h3 style=""text-align: center;"" class=""card-title"">Users Segmentation</h3>
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <canvas id=""barChartByLevel"" style=""height:350px""></canvas>
                                <!-- <div class=""table-responsive"">
                                  <table class=""table"">
                                    <tbody>
                                      <tr>
                                        <td>
                                          <i class=""flag-icon flag-icon-eg""></i>
");
            WriteLiteral(@"                                        </td>
                                        <td>Egypt</td>
                                        <td class=""text-right""> 1500 </td>
                                        <td class=""text-right font-weight-medium""> 56.35% </td>
                                      </tr>
                                      <tr>
                                        <td>
                                          <i class=""flag-icon flag-icon-sa""></i>
                                        </td>
                                        <td>KSA</td>
                                        <td class=""text-right""> 800 </td>
                                        <td class=""text-right font-weight-medium""> 33.25% </td>
                                      </tr>
                                      <tr>
                                        <td>
                                          <i class=""flag-icon flag-icon-ps""></i>
                                        <");
            WriteLiteral(@"/td>
                                        <td>Palestine</td>
                                        <td class=""text-right""> 760 </td>
                                        <td class=""text-right font-weight-medium""> 15.45% </td>
                                      </tr>
                                    </tbody>
                                  </table>
                                </div> -->
                            </div>
                            <div class=""col-md-6"">
                                <canvas id=""barChart"" style=""height:350px""></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-12 grid-margin stretch-card"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""d-flex flex-row justify-content-between"">
                            ");
            WriteLiteral(@"<h4 class=""card-title mb-1"">Pending Tasks</h4>
                            <p class=""text-muted mb-1"">44 Task</p>
                        </div>
                        <div class=""row"">
                            <div class=""col-12"">
                                <div class=""preview-list"">
                                    <div class=""preview-item border-bottom"">
                                        <svg xmlns=""http://www.w3.org/2000/svg"" width=""40"" height=""40"" fill=""#1DB954"" class=""bi bi-file-earmark-person"" viewBox=""0 0 16 16"">
                                            <path d=""M11 8a3 3 0 1 1-6 0 3 3 0 0 1 6 0z"" />
                                            <path d=""M14 14V4.5L9.5 0H4a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2zM9.5 3A1.5 1.5 0 0 0 11 4.5h2v9.255S12 12 8 12s-5 1.755-5 1.755V2a1 1 0 0 1 1-1h5.5v2z"" />
                                        </svg>
                                        <div class=""preview-item-content d-sm-flex flex-grow"">
                       ");
            WriteLiteral(@"                     <div class=""flex-grow"">
                                                <h6 class=""preview-subject"">CVs to review</h6>
                                                <p class=""text-muted mb-0"">Number of CV Review Requests pending HR Review</p>
                                            </div>
                                            <div class=""mr-auto text-sm-right pt-2 pt-sm-0"">
                                                <h5 class=""preview-subject text-muted mb-0"">30 CVs</h5>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""preview-item border-bottom"">
                                        <svg xmlns=""http://www.w3.org/2000/svg"" width=""40"" height=""40"" fill=""#1DB954"" class=""bi bi-linkedin"" viewBox=""0 0 16 16"">
                                            <path d=""M0 1.146C0 .513.526 0 1.175 0h13.65C15.474 0 16 .513 16 1.146v13.7");
            WriteLiteral(@"08c0 .633-.526 1.146-1.175 1.146H1.175C.526 16 0 15.487 0 14.854V1.146zm4.943 12.248V6.169H2.542v7.225h2.401zm-1.2-8.212c.837 0 1.358-.554 1.358-1.248-.015-.709-.52-1.248-1.342-1.248-.822 0-1.359.54-1.359 1.248 0 .694.521 1.248 1.327 1.248h.016zm4.908 8.212V9.359c0-.216.016-.432.08-.586.173-.431.568-.878 1.232-.878.869 0 1.216.662 1.216 1.634v3.865h2.401V9.25c0-2.22-1.184-3.252-2.764-3.252-1.274 0-1.845.7-2.165 1.193v.025h-.016a5.54 5.54 0 0 1 .016-.025V6.169h-2.4c.03.678 0 7.225 0 7.225h2.4z"" />
                                        </svg>
                                        <div class=""preview-item-content d-sm-flex flex-grow"">
                                            <div class=""flex-grow"">
                                                <h6 class=""preview-subject"">LinkedIn Review</h6>
                                                <p class=""text-muted mb-0"">Number of LinkedIn Review Requests pending HR Review</p>
                                            </div>
                         ");
            WriteLiteral(@"                   <div class=""mr-auto text-sm-right pt-2 pt-sm-0"">
                                                <h5 class=""preview-subject text-muted"">8 LinkedIn Profiles</h5>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""preview-item border-bottom"">
                                        <svg xmlns=""http://www.w3.org/2000/svg"" width=""40"" height=""40"" fill=""#1DB954"" class=""bi bi-person-check"" viewBox=""0 0 16 16"">
                                            <path d=""M6 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H1s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C9.516 10.68 8.289 10 6 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z"" />
                                            <path fill-rule=""evenodd"" d=""M15.854 5.146a.5.5 0 0 1 0 .708l-3 3a.5.5 0 0 1-.708 0l-1.5-1.5a.5.5 0 0 1 .708-.7");
            WriteLiteral(@"08L12.5 7.793l2.646-2.647a.5.5 0 0 1 .708 0z"" />
                                        </svg>
                                        <div class=""preview-item-content d-sm-flex flex-grow"">
                                            <div class=""flex-grow"">
                                                <h6 class=""preview-subject"">IV Simulation</h6>
                                                <p class=""text-muted mb-0"">Number of Interview simulations pending HR schedule.</p>
                                            </div>
                                            <div class=""mr-auto text-sm-right pt-2 pt-sm-0"">
                                                <h5 class=""preview-subject text-muted"">6 Interview(s)</h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>");
            WriteLiteral(@"
                </div>
            </div>
        </div>
        <div class=""row"" id=""ToDoList"">
            <div class=""col-12 grid-margin"">
                <div class=""card"">
                    <div class=""card-body"">
                        <h4 class=""card-title"">To do list</h4>
                        <div class=""add-items d-flex"">
                            <input type=""text"" class=""form-control todo-list-input"" placeholder=""enter task.."">
                            <button class=""add btn btn-primary todo-list-add-btn"">Add</button>
                        </div>
                        <div class=""list-wrapper"" style=""height:300px; overflow-y: auto;"">
                            <ul class=""d-flex flex-column-reverse text-white todo-list todo-list-custom"">
");
#nullable restore
#line 288 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\Admin\Index.cshtml"
                                 if (ViewBag.AllTasks != null)
                                {
                                    foreach (var task in ViewBag.AllTasks)
                                    {
                                        if (task.isDone)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <li class=""completed"">
                                                <div class=""form-check form-check-primary"">
                                                    <label class=""form-check-label"">
                                                        <input class=""checkbox"" type=""checkbox"" checked> ");
#nullable restore
#line 297 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\Admin\Index.cshtml"
                                                                                                    Write(task.task);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                    </label>
                                                </div>
                                                <i class=""remove mdi mdi-close-box""></i>
                                            </li>
");
#nullable restore
#line 302 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\Admin\Index.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <li>
                                                <div class=""form-check form-check-primary"">
                                                    <label class=""form-check-label"">
                                                        <input class=""checkbox"" type=""checkbox""> ");
#nullable restore
#line 308 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\Admin\Index.cshtml"
                                                                                            Write(task.task);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                    </label>
                                                </div>
                                                <i class=""remove mdi mdi-close-box""></i>
                                            </li>
");
#nullable restore
#line 313 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\Admin\Index.cshtml"
                                        }
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <!-- content-wrapper ends -->
    <!-- partial:partials/_footer.html -->
    <footer class=""footer"">
        <div class=""d-sm-flex justify-content-center justify-content-sm-between"">
            <span class=""text-muted d-block text-center text-sm-left d-sm-inline-block"">Copyright © <span style=""color: #1DB954;"">RankUp</span> 2021</span>
        </div>
    </footer>
    <!-- partial -->
</div>

");
#nullable restore
#line 334 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\Admin\Index.cshtml"
Write(Url.Action("AddTask", "BoardUsers", new { taskContent = "test" }));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RankUp.Models.BoardUsers> Html { get; private set; }
    }
}
#pragma warning restore 1591