//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IN4MDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class LookupWorkOrderPriority
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LookupWorkOrderPriority()
        {
            this.WorkOrders = new HashSet<WorkOrder>();
        }
    
        public System.Guid WorkOrderPriorityID { get; set; }
        public string WorkOrderPriorityStatus { get; set; }
        public string WorkOrderPriorityStatusDescription { get; set; }
        public Nullable<int> WorkOrderPriorityResponseTime { get; set; }
        public string WorkOrderPriority { get; set; }
        public string WorkOrderPriorityDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
