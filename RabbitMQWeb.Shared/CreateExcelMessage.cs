using System;

namespace RabbitMQWeb.Shared
{
    public class CreateExcelMessage
    {
        public string UserId { get; set; }
        public int FileId { get; set; }
    }
}
