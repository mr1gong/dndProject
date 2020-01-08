using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Author : System.Attribute
{
    private string author;
    private string version;

    public Author(string author, string version)
    {
        this.author = author;
        this.version = version;
    }
}
