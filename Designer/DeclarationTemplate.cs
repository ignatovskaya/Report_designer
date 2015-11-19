using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer
{
    public class DeclarationTemplate : ITemplate
    {
        #region Constructors
        public DeclarationTemplate() : this(Guid.NewGuid()) { }
        public DeclarationTemplate(Guid id)
        {
            _id = id;
        }
        public DeclarationTemplate(Guid id, string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
        }
        public DeclarationTemplate(Guid id, string name, string description, string introduction, string mainText)
        {
            _id = id;
            _name = name;
            _description = description;
            _introduction = introduction;
            _mainText = mainText;
        }
        #endregion

        private Guid _id;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _description; //описание
        private string _introduction;
        private string _mainText;

        #region Metgods
        public void CreateTemplate(DeclarationTemplate template)
        {
            var connect = string.Format("INSERT INTO Declaration" +
                                        "(ID, Name, Description, Introduction, MainText) Values" +
                                        "('{0}', '{1}', '{2}', '{3}', '{4}')",
                                        template._id, template._name, template._description, template._introduction,
                                        template._mainText);


            MethodsForDB.Create(connect);

        }

        public DeclarationTemplate OpenDeclarTemplate(string name)
        {
            var connection = MethodsForDB.Connection;
            string query = $"Select * From LabWork WHERE Name = '{name}'";
            var command = new SqlCommand(query, connection);
            connection.Open();
            DeclarationTemplate declarationTemplate = null;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    declarationTemplate = new DeclarationTemplate(reader.GetGuid(0))
                    {
                        _name = reader.GetString(1),
                        _description = reader.GetString(2),
                        _introduction = reader.GetString(3),
                        _mainText = reader.GetString(4)
                    };
                }
            }

            return declarationTemplate;
        }

        public void DeleteTemplate(DeclarationTemplate declaration)
        {
            var connect = $"DELETE FROM Declaration WHERE ID = '{declaration._id}'";
            MethodsForDB.Delete(connect);
        }

        void ITemplate.CreateTemplate(LabWorkTemplate template) { }

        LabWorkTemplate ITemplate.OpenLabTemplate(string name)
        {
            return null;
        }

        void ITemplate.DeleteTemplate(LabWorkTemplate labWork) { }
        #endregion
    }
}
