namespace Chapter.Command
{
    public class ToggleTurbo : Command
    {
        BikeController _controller;

        public ToggleTurbo(BikeController controller)
        {
            _controller = controller;
        }
        
        public override void Execute()
        {
            _controller.ToggleTurbo();
        }
    }
}