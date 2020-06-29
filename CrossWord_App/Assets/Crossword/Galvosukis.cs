using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Galvosukis
{
        public string zodis { get; set; }
        public string uzduotis { get; set; }
        public string hint { get; set; }
        

    public Galvosukis(string z, string uz, string hint1)
        {
            this.zodis = z;
            this.uzduotis = uz;
            this.hint = hint1;
        }
        public Galvosukis()
        {

        }
}
