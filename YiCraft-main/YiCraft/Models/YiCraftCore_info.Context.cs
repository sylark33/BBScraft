﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------


namespace YiCraft.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class YiCraftCoreEntities2 : DbContext
{
    public YiCraftCoreEntities2()
        : base("name=YiCraftCoreEntities2")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<discuss_infos> discuss_infos { get; set; }

    public virtual DbSet<player_infos> player_infos { get; set; }

    public virtual DbSet<reply_infos> reply_infos { get; set; }

    public virtual DbSet<whitelistquestion_infos> whitelistquestion_infos { get; set; }

    public virtual DbSet<yicraft_infos> yicraft_infos { get; set; }

}

}

