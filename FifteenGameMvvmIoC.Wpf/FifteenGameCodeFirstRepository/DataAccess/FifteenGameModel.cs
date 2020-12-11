using FifteenGameCodeFirstRepository.DataModels;
using System;
using System.Data.Entity;
using System.Linq;

namespace FifteenGameCodeFirstRepository.DataAccess
{
    public class FifteenGameModel : DbContext
    {
        // Your context has been configured to use a 'FifteenGameModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FifteenGameCodeFirstRepository.DataAccess.FifteenGameModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FifteenGameModel' 
        // connection string in the application configuration file.
        public FifteenGameModel()
            : base("name=FifteenGameModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<CurrentGame> CurrentGames { get; set; }

        public virtual DbSet<CurrentGameCell> CurrentGameCells { get; set; }

        public virtual DbSet<FinishedGame> FinishedGames { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}