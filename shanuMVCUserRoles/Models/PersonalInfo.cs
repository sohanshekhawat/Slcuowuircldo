using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shanuMVCUserRoles.Models
{
    public class PersonalInfo
    {
        [Key]
        [Required]
        public string UserId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "City/Village")]
        public int CityId { get; set; }
        [Display(Name = "State")]
        public int StateId { get; set; }
        [Display(Name = "Blood Group")]
        public int BloodGroupId { get; set; }
        [Display(Name = "About")]
        public string Description { get; set; }

        public virtual City City { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        public virtual BloodGroup BloodGroup { get; set; }
    }

    public class State
    {
        public State()
        {
            this.Cities = new HashSet<City>();
        }

        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }

    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }

        public int StateId { get; set; }
        //[ForeignKey("StateId")]
        //public virtual State State { get; set; }
    }

    public class BloodGroup
    {
        [Key]
        public int BloodGroupId { get; set; }
        public string Name { get; set; }
    }

    public class BloodGroupMap
    {
        [Key]
        public int Id { get; set; }
        public int BloodGroupId { get; set; }
        public int DonateTo { get; set; }

        public virtual BloodGroup BloodGroup { get; set; }
    }
}