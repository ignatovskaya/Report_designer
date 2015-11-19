using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer
{
    class ProxyTemplate: ITemplate
    {
        private readonly LabWorkTemplate realTemplate;
        private readonly DeclarationTemplate declarationTemplate;
        public ProxyTemplate()
        {
            realTemplate = new LabWorkTemplate();
            declarationTemplate = new DeclarationTemplate();
        }
        #region Proxy for LabWork
        public void CreateTemplate(LabWorkTemplate template)
        {
            realTemplate.CreateTemplate(realTemplate);
        }
        public LabWorkTemplate OpenLabTemplate(string name)
        {
            return realTemplate.OpenLabTemplate(realTemplate._name);
        }
        public void DeleteTemplate(LabWorkTemplate labWork)
        {
            realTemplate.DeleteTemplate(realTemplate);
        }
        #endregion
        #region Proxy for Declaration
        public void CreateTemplate(DeclarationTemplate template)
        {
            declarationTemplate.CreateTemplate(declarationTemplate);
        }
        public DeclarationTemplate OpenDeclarTemplate(string name)
        {
            return declarationTemplate.OpenDeclarTemplate(declarationTemplate.Name);
        }
        public void DeleteTemplate(DeclarationTemplate labWork)
        {
            declarationTemplate.DeleteTemplate(declarationTemplate);
        }
        #endregion

    }
}
