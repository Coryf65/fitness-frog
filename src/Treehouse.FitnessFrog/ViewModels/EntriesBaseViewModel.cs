using System.Web.Mvc;
using Treehouse.FitnessFrog.Data;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.ViewModels
{
    public abstract class EntriesBaseViewModel
    {
        public Entry Entry { get; set; } = new Entry();

        public SelectList ActivitiesSelectListItems { get; set; }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public void Init(ActivitiesRepository activitiesRepository)
        {
            ActivitiesSelectListItems = new SelectList(
                activitiesRepository.GetList(), "Id", "Name");
        }
    }
}