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
    class LabWorkTemplate : ITemplate
    {
        #region Constructor
        public LabWorkTemplate() : this(Guid.NewGuid()) { }
        public LabWorkTemplate(Guid id)
        {
            _id = id;
        }
        public LabWorkTemplate(Guid id, string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
        }
        public LabWorkTemplate(Guid id, string name, string description, string university, string title, string whoDone, string whoAccepted, string year, string theory, string task, string progressWork, string conclusion)
        {
            _id = id;
            _name = name;
            _description = description;
            _university = university;
            _title = title;
            _whoDone = whoDone;
            _whoAccepted = whoAccepted;
            _year = year;
            _theory = theory;
            _task = task;
            _progressWork = progressWork;
            _conclusion = conclusion;
        }
        #endregion

        #region Fields

        private Guid _id;
        public string _name;
        private string _description; //описание
        private string _university;
        private string _title;
        private string _whoDone;
        private string _whoAccepted;
        private string _year;
        private string _theory;
        private string _task;
        private string _progressWork;
        private string _conclusion;
        #endregion

        #region Metgods
        public void CreateTemplate(LabWorkTemplate template)
        {
            var connect = "INSERT INTO LabWork" + "(ID, Name, Description, University, Title, WhoDone, " +
                          "WhoAccepted, Year, Theory, Task, ProgressWork, Conclusion) Values" +
                          $"('{template._id}', '{template._name}', '{template._description}', '{template._university}', '{template._title}', '{template._whoDone}', '{template._whoAccepted}', '{template._year}', '{template._theory}', '{template._task}', '{template._progressWork}', '{template._conclusion}')";
            MethodsForDB.Create(connect);
        }

        public LabWorkTemplate OpenLabTemplate(string name)
        {
            LabWorkTemplate labWorkTemplate = null;
            var connection = MethodsForDB.Connection;
            string query = $"Select * From LabWork WHERE Name = '{name}'";

            var command = new SqlCommand(query, connection);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    labWorkTemplate = new LabWorkTemplate(reader.GetGuid(0))
                    {
                        _name = reader.GetString(1),
                        _description = reader.GetString(2),
                        _university = reader.GetString(3),
                        _title = reader.GetString(4),
                        _whoDone = reader.GetString(5),
                        _whoAccepted = reader.GetString(6),
                        _year = reader.GetString(7),
                        _theory = reader.GetString(8),
                        _task = reader.GetString(9),
                        _progressWork = reader.GetString(10),
                        _conclusion = reader.GetString(11)
                    };
                }
            }
            return labWorkTemplate;
        }

        public void DeleteTemplate(LabWorkTemplate labWork)
        {
            var connect = $"DELETE FROM LabWork WHERE ID = '{labWork._id}'";
            MethodsForDB.Delete(connect);
        }

        void ITemplate.CreateTemplate(DeclarationTemplate template) { }

        DeclarationTemplate ITemplate.OpenDeclarTemplate(string name)
        {
            return null;
        }

        void ITemplate.DeleteTemplate(DeclarationTemplate labWork) { }
        #endregion
    }
}
