<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Artist.UI.ViewModels.CustomerGridViewModel>" %>

<div class="pager">
<%
    // Create Previous link
    Html.RenderPartial("PagerLink", Model,
                       new ViewDataDictionary
                           {
                               {"Text", "<< Previous"},
                               {"PageIndex", Model.CurrentPageIndex - 1},
                               {"Selected", false},
                               {"Inactive", Model.CurrentPageIndex == 1}
                           });


    // Create numeric links    
    int startPageIndex = Math.Max(1, Model.CurrentPageIndex - Model.NumericPageCount/2);
    int endPageIndex = Math.Min(Model.PageCount, Model.CurrentPageIndex + Model.NumericPageCount/2);

    // Add in initial page numbers, if needed
    if (Model.PageCount > Model.NumericPageCount/2)
    {
        if (startPageIndex > 1)
            Html.RenderPartial("PagerLink", Model,
                               new ViewDataDictionary
                                   {{"Text", "1"}, {"PageIndex", 1}, {"Selected", false}, {"Inactive", false}});
        if (startPageIndex > 2)
            Html.RenderPartial("PagerLink", Model,
                               new ViewDataDictionary
                                   {{"Text", "2"}, {"PageIndex", 2}, {"Selected", false}, {"Inactive", false}});
        if (startPageIndex > 3)
            Html.RenderPartial("PagerLink", Model,
                               new ViewDataDictionary
                                   {{"Text", "..."}, {"PageIndex", 1}, {"Selected", false}, {"Inactive", true}});
    }

    // Add in the numeric pages    
    for (int i = startPageIndex; i <= endPageIndex; i++)
        Html.RenderPartial("PagerLink", Model,
                           new ViewDataDictionary
                               {
                                   {"Text", i},
                                   {"PageIndex", i},
                                   {"Selected", i == Model.CurrentPageIndex},
                                   {"Inactive", false}
                               });


    // Add in trailing page numbers, if needed 
    if (Model.PageCount > Model.NumericPageCount/2)
    {
        if (endPageIndex < Model.PageCount - 2)
            Html.RenderPartial("PagerLink", Model,
                               new ViewDataDictionary
                                   {{"Text", "..."}, {"PageIndex", 1}, {"Selected", false}, {"Inactive", true}});
        if (endPageIndex < Model.PageCount - 1)
            Html.RenderPartial("PagerLink", Model,
                               new ViewDataDictionary
                                   {
                                       {"Text", Model.PageCount - 1},
                                       {"PageIndex", Model.PageCount - 1},
                                       {"Selected", false},
                                       {"Inactive", false}
                                   });
        if (endPageIndex < Model.PageCount)
            Html.RenderPartial("PagerLink", Model,
                               new ViewDataDictionary
                                   {
                                       {"Text", Model.PageCount},
                                       {"PageIndex", Model.PageCount},
                                       {"Selected", false},
                                       {"Inactive", false}
                                   });
    }


    // Create Next link
    Html.RenderPartial("PagerLink", Model,
                       new ViewDataDictionary
                           {
                               {"Text", "Next >>"},
                               {"PageIndex", Model.CurrentPageIndex + 1},
                               {"Selected", false},
                               {"Inactive", Model.CurrentPageIndex == Model.PageCount}
                           });
%>
</div>