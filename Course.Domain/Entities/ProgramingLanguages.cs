using Core.Persistence.Repositories;


namespace Course.Domain.Entities
{
    public class ProgramingLanguages:Entity
    {
        public string Name { get; set; }
        public int? LanguageId { get; set; }
        public virtual Language? Language { get; set; }

        public ProgramingLanguages()
        {
            
        }

        public ProgramingLanguages(int id, string name, int? languageId):this()
        {
            Name = name;
            LanguageId = languageId;
            Id = id;
        }
    }
}
