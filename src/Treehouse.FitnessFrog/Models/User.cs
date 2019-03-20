using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Treehouse.FitnessFrog.Models
{
    public class User : IdentityUser
    {

        //And that's all that we have to do for our model class! All of the model's 
        //properties are provided by the IdentityUser base class, 
        //which inherits from the IdentityUser<TKey, TLogin, TRole, TClaim> generic class.

    }
}