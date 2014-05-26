using Capstone.WebUI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.WebUI.Domain.Abstract
{
    public interface FormInterface
    {
        void AddForm(Form sec3);
        Form GetFormById(int id);
        IQueryable<Form> GetForms();
        void UpdateForm(Form sec3);
        Form DeleteForm(int id);
    }
}
