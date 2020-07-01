using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class LogDto
    {
        public int Id { get; set; }
        public  DateTime Date { get; set; }
        public string Data { get; set; }
        public string Actor { get; set; }
        public string UseCaseName { get; set; }
    }
}
