using System;

namespace IotHub.DomainModels.Base
{
    public class BaseEntityWithLog : BaseEntity
    {
        private DateTime createdDate;
        public DateTime CreatedDate 
        { 
            get { return createdDate; } 
            private set { createdDate = DateTime.Now; } 
        } 
        public DateTime LastModifedDate { get; set; }
    }
}
