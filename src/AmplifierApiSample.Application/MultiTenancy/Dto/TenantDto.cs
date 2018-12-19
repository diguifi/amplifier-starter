using System;
using System.Collections.Generic;
using System.Text;

namespace AmplifierApiSample.Application.MultiTenancy.Dto
{
    public class TenantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
    }
}
