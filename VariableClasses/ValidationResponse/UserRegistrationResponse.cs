using System;
using System.Collections.Generic;
using System.Text;

namespace VariableClasses.ValidationResponse
{
    public class UserRegistrationResponse
    {
        public bool Valid { get; set; } = false;
        public bool UserNameError { get; set; }
        public bool EmailError { get; set; }
    }
}
