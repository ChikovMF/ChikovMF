using System;
using System.Collections.Generic;
namespace ChikovMF.Domain;

public class Tag
{
    public int TagId { get; set; }
    public string Title { get; set; } = null!;

    public ICollection<Project>? Projects { get; set; }
}
