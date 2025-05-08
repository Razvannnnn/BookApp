using BookApp.Repository;
using BookApp.Service;

namespace BookApp;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        IRepoBook repoBook = new RepoBook();
        IRepoBorrower repoBorrower = new RepoBorrower();
        IRepoBorrowRecord repoBorrowRecord = new RepoBorrowRecord();
        Service.Service serviceBook = new Service.Service(repoBook, repoBorrower, repoBorrowRecord);
        Application.Run(new Form1(serviceBook));
    }
}