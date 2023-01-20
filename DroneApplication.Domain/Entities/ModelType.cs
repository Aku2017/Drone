using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DroneApplication.Domain.Entities
{
   public enum ModelType
    {
        [Description("LightWeight")]
        Lightweight, 
        [Description("Middleweight")]
        Middleweight, 
        [Description("Curiserweight")]   
        Curiserweight, 
        [Description("Heavyweight")]     
        Heavyweight
    }

    public enum State
    {
        [Description("Idle")]
        Idle,
        [Description("Loading")]
        Loading,
        [Description("Loaded")]
        Loaded,
        [Description("Delivering")]
        Delivering,
        [Description("Delivered")]
        Delivered
    }

}
