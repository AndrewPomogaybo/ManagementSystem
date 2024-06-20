using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Models
{
    public class Task
    {
        public int Task_id { get; set; }
        public string Task_name {  get; set; }
        public string Task_description { get; set;}
        public int Task_user {  get; set; }
    }
}
