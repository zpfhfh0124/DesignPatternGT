namespace Chapter.Command
{
    public class TurnLeft : Command
    {
        BikeController _controller;

        public TurnLeft(BikeController controller)
        {
            _controller = controller;
        }
        
        public override void Execute()
        {
            _controller.Turn(BikeController.Direction.Left);
        }
    }
}