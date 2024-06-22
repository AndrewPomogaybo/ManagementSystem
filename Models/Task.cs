
namespace ManagementSystem.Models
{
    public class Task
    {
        public int Task_id { get; set; }
        public string Task_name {  get; set; }
        public string Task_description { get; set;}
        public int Task_user {  get; set; }
        public int Task_status { get; set;}
    }
}
