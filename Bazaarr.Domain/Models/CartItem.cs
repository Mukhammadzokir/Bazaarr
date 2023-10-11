﻿using Bazaarr.Domain.Commons;

namespace Bazaarr.Domain.Models;
public class CartItem : Auditable
{
    public long CartId { get; set; }
    public Cart Cart { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
}
