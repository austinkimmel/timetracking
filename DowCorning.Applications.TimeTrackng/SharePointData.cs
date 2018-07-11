using DowCorning.Applications.EstimationListUtilities;
using Microsoft.SharePoint.Client;
using System.Collections.ObjectModel;

namespace DowCorning.Applications.TimeTracking
{
    public class SharePointData
    {
        public static Collection<string> allProjects = Project.AllProjects();

        public static void UpdateActualHours(int sharePointItemId, double actualHours)
        {
            if (sharePointItemId != -1)
            {
                ClientContext myContext = SharePointUtilities.AppDevTeamroomContext();

                List projectList = myContext.Web.Lists.GetByTitle(SharePointUtilities.ProjectTasksListName);
                ListItem myItem = projectList.GetItemById(sharePointItemId); //Getting item again, since previous item was created by different context, not sure if can update it here...
                myContext.Load(myItem);
                myContext.ExecuteQuery();

                myItem["Actual_x0020_Hours"] = actualHours;
                myItem.Update();
                myContext.ExecuteQuery();
            }
        }
    }
}