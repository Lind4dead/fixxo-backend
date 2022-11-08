namespace fixxo_backend.Models.Entities
{
    public class ClassificationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AdditionalInformationEntity> AdditionalInformation { get; set; }

    }
}
