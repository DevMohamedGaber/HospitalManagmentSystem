﻿using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Identity.Entities;

public class User : IdentityUser<uint>, IBaseEntity
{

}