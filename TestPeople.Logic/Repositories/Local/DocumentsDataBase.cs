using System;
using System.Collections.Generic;
using System.Linq;
using Couchbase.Lite;
using Couchbase.Lite.Query;
using Newtonsoft.Json;
using TestPeople.Logic.Business.Contracts;
using TestPeople.Logic.Business.Dtos;

namespace TestPeople.Logic.Repositories.Local
{
    public class DocumentsDataBase : IDocumentsDataBase
    {
        private string ConstantDocument { get => "Document"; }
        private string ConstantPerson { get => "Person"; }
        private Database database;

        private static DocumentsDataBase instance;

        public static DocumentsDataBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DocumentsDataBase();
                }

                return instance;
            }
        }

        public DocumentsDataBase()
        {
            if (database == null)
            {
                database = new Database(ConstantDocument);
            }
        }
        
        public bool ExistPeople()
        {
            bool exist = false;

            using (var query = QueryBuilder.Select(SelectResult.All()).From(DataSource.Database(database)))
            {
                exist = query.Execute().AllResults().Any();
            }

            return exist;
        }

        public List<People> GetPeople()
        {
            List<People> people = new List<People>();

            using (var query = QueryBuilder.Select(SelectResult.All()).From(DataSource.Database(database)))
            {
                foreach (Result item in query.Execute())
                {
                    var dict = item.GetDictionary(database.Name);

                    string value = dict?.GetString(ConstantPerson);

                    if (!string.IsNullOrEmpty(value))
                    {
                        people.Add(JsonConvert.DeserializeObject<People>(value));
                    }
                }
            }

            return people;
        }

        public void UpSerPerson(People person)
        {
            var document = database.GetDocument(person.Id.ToString());
            document = document ?? new MutableDocument(person.Id.ToString());

            using (var mutableDoc = document.ToMutable())
            {
                mutableDoc.SetString(ConstantPerson, JsonConvert.SerializeObject(person));
                database.Save(mutableDoc);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (database != null)
            {
                database.Close();
            }
        }
    }
}
