using System;
using System.Collections.Generic;
using System.Text;

namespace P05.BorderControl
{
    public class Robot : IIdentificator
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get;}
        public string Id { get; set; }
    }
}
