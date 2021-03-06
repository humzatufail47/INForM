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
    
    public partial class Component
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Component()
        {
            this.ComponentAttibutes = new HashSet<ComponentAttibute>();
            this.ComponentFinances = new HashSet<ComponentFinance>();
            this.ComponentInspections = new HashSet<ComponentInspection>();
            this.PerformanceMeasures = new HashSet<PerformanceMeasure>();
        }
    
        public System.Guid ComponentID { get; set; }
        public string ComponentName { get; set; }
        public string ComponentDescription { get; set; }
        public Nullable<System.Guid> AssetID { get; set; }
        public Nullable<System.DateTime> InstallationDate { get; set; }
        public Nullable<System.DateTime> DisposalDate { get; set; }
        public string Material { get; set; }
        public string Utilisation { get; set; }
        public string EnvironmentalExposure { get; set; }
        public string CompCat { get; set; }
        public string CompCoF { get; set; }
        public Nullable<System.Guid> MaterialID { get; set; }
    
        public virtual Asset Asset { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComponentAttibute> ComponentAttibutes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComponentFinance> ComponentFinances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComponentInspection> ComponentInspections { get; set; }
        public virtual Material Material1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerformanceMeasure> PerformanceMeasures { get; set; }
    }
}
