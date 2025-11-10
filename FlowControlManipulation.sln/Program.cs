namespace FlowControlManipulation.sln
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppModel appModel = new AppModel();
            View mainMenuView = new View();
            Controler controler = new Controler(mainMenuView, appModel);
            controler.run();
        }
    }
}
