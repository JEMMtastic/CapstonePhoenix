using Capstone.WebUI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.WebUI.Domain.Abstract
{
    public interface CharityInterface
    {
        void AddCharity(Charity charity); //Adds charity
        Charity GetCharityByName(string name); //Get charity by the name
        Charity GetCharityById(int id); //Get charity by id if necessary
        IQueryable<Charity> GetCharities(); //Gets all charities
        void EditCharity(Charity charity); //Saves updated charity in db
        Charity DeleteCharity(int charityId); //Returns charity that was deleted for display and confirmation
    }
}