using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer
{
    interface ITemplate
    {
        void CreateTemplate(LabWorkTemplate template);
        LabWorkTemplate OpenLabTemplate(string name);
        void DeleteTemplate(LabWorkTemplate labWork);

        void CreateTemplate(DeclarationTemplate template);
        DeclarationTemplate OpenDeclarTemplate(string name);
        void DeleteTemplate(DeclarationTemplate labWork);
    }

}
