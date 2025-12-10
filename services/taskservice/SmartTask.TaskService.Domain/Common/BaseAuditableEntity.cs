namespace SmartTask.TaskService.Domain
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }
    }
}
