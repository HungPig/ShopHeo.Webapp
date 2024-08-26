using Microsoft.Data.OData.Query.SemanticAst;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.System.Users
{
    public class RoleUserRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
